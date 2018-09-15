using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Yagohf.PUC.Data.Context;
using Yagohf.PUC.Data.Interface.Queries;
using Yagohf.PUC.Data.Interface.Repository;
using Yagohf.PUC.Infraestrutura.Extensions;
using Yagohf.PUC.Model.Entidades;
using Yagohf.PUC.Model.Infraestrutura;

namespace Yagohf.PUC.Data.Repository
{
    public class RepositoryBase<T> : IRepository<T> where T : EntidadeBase
    {
        protected LojaDbContext _context;
        protected const int QTD_REGISTROS_DEFAULT_PAGINACAO = 10;

        public RepositoryBase(LojaDbContext context)
        {
            this._context = context;
        }

        public async Task AtualizarAsync(T entidade)
        {
            this._context.Entry<T>(entidade).State = EntityState.Modified;
            await this._context.SaveChangesAsync();
        }

        public async Task<int> ContarAsync(IQuery<T> query)
        {
            var queryPreparada = this.PrepararQuery(query);
            return await queryPreparada.CountAsync();
        }

        public async Task InserirAsync(T entidade)
        {
            await this._context.Set<T>().AddAsync(entidade);
            await this._context.SaveChangesAsync();
        }

        public async Task ExcluirAsync(int id)
        {
            T entidade = await this._context.Set<T>().FindAsync(id);
            this._context.Set<T>().Remove(entidade);
            await this._context.SaveChangesAsync();
        }

        public async Task ExcluirAsync(T entidade)
        {
            await this.ExcluirAsync(entidade.Id);
        }

        public async Task<IEnumerable<T>> ListarAsync(IQuery<T> query)
        {
            return await this.PrepararQuery(query).ToListAsync();
        }

        public async Task<Listagem<T>> ListarPaginandoAsync(IQuery<T> query, int pagina, int qtdRegistrosPorPagina)
        {
            var qtdRegistros = this.ContarAsync(query);
            var registros = this.PrepararQuery(query, pagina, qtdRegistrosPorPagina).ToListAsync();

            return new Listagem<T>(await registros, new Paginacao(pagina, await qtdRegistros, qtdRegistrosPorPagina));
        }

        private IQueryable<T> PrepararQuery(IQuery<T> query)
        {
            IQueryable<T> queryPrincipal = this._context.Set<T>().AsNoTracking();
            if (query != null)
            {
                if (query.Includes.Any())
                {
                    // Montar um IQueryable<T> com todos os includes explícitos.
                    queryPrincipal = query.Includes
                    .Aggregate(this._context.Set<T>().AsQueryable(),
                        (current, include) => current.Include(include));
                }

                if (query.IncludeStrings.Any())
                {
                    // Adicionar os includes de strings.
                    queryPrincipal = query.IncludeStrings
                        .Aggregate(queryPrincipal,
                            (current, include) => current.Include(include));
                }

                //Tratar where.
                if (query.Criteria != null)
                {
                    foreach (var criteria in query.Criteria)
                    {
                        queryPrincipal = queryPrincipal.Where(criteria);
                    }
                }

                //Tratar ordenação.
                if (query.OrderBy != null)
                {
                    queryPrincipal = PrepararOrdenacao(query, queryPrincipal);
                }
            }

            return queryPrincipal;
        }

        private IQueryable<T> PrepararOrdenacao(IQuery<T> query, IQueryable<T> queryPrincipal)
        {
            foreach (var order in query.OrderBy)
            {
                if (order.Descending)
                {
                    queryPrincipal = queryPrincipal.OrderByDescending(order.Expression);
                }
                else
                {
                    queryPrincipal = queryPrincipal.OrderBy(order.Expression);
                }
            }

            return queryPrincipal;
        }

        private IQueryable<T> PrepararQuery(IQuery<T> query, int pagina, int qtdRegistrosPorPagina)
        {
            IQueryable<T> queryPreparada = this.PrepararQuery(query);
            return queryPreparada.Skip((pagina - 1) * qtdRegistrosPorPagina).Take(qtdRegistrosPorPagina);
        }

        public async Task<T> SelecionarUnicoAsync(IQuery<T> query)
        {
            return await this.PrepararQuery(query).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> ListarTodosAsync()
        {
            return await this.ListarAsync(null);
        }

        public async Task<bool> ExisteAsync(IQuery<T> query)
        {
            return await this.PrepararQuery(query).AnyAsync();
        }

        public Task<TResult> ExecutarProcedureComOutputAsync<TResult>(string chamadaProcedure, string nomeParametroOutput)
        {
            return this.ExecutarProcedureComOutputAsync<TResult>(chamadaProcedure, nomeParametroOutput, null);
        }

        public async Task<TResult> ExecutarProcedureComOutputAsync<TResult>(string chamadaProcedure, string nomeParametroOutput, List<(string nome, object value)> parametros)
        {
            var command = this.CriarComando(chamadaProcedure, parametros);

            var paramOutput = command.CreateParameter();
            paramOutput.ParameterName = nomeParametroOutput;
            paramOutput.Direction = System.Data.ParameterDirection.Output;
            paramOutput.Size = -1;
            command.Parameters.Add(paramOutput);

            await command.ExecuteNonQueryAsync();

            if (paramOutput.Value != null)
            {
                return paramOutput.Value.ToType<TResult>();
            }
            else
            {
                return default(TResult);
            }
        }

        public Task ExecutarProcedureSemRetornoAsync(string chamadaProcedure)
        {
            return this.ExecutarProcedureSemRetornoAsync(chamadaProcedure, null);
        }

        public async Task ExecutarProcedureSemRetornoAsync(string chamadaProcedure, List<(string nome, object value)> parametros)
        {
            var command = this.CriarComando(chamadaProcedure, parametros);
            await command.ExecuteNonQueryAsync();
        }

        private DbCommand CriarComando(string chamadaProcedure, List<(string nome, object value)> parametros)
        {
            var command = this._context.Database.GetDbConnection().CreateCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = chamadaProcedure;

            if (this._context.Database.CurrentTransaction != null)
            {
                command.Transaction = this._context.Database.CurrentTransaction.GetDbTransaction();
            }

            if (parametros != null)
            {
                foreach (var p in parametros)
                {
                    var param = command.CreateParameter();
                    param.ParameterName = p.nome;
                    param.Value = p.value;
                    command.Parameters.Add(param);
                }
            }

            return command;
        }
    }
}
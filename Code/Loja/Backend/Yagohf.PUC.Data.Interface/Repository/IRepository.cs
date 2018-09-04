using System.Collections.Generic;
using System.Threading.Tasks;
using Yagohf.PUC.Data.Interface.Queries;
using Yagohf.PUC.Model.Infraestrutura;

namespace Yagohf.PUC.Data.Interface.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T> SelecionarUnicoAsync(IQuery<T> query);
        Task<IEnumerable<T>> ListarTodosAsync();
        Task<IEnumerable<T>> ListarAsync(IQuery<T> query);
        Task<Listagem<T>> ListarPaginandoAsync(IQuery<T> query, int pagina, int qtdRegistrosPorPagina);
        Task<int> ContarAsync(IQuery<T> query);
        Task InserirAsync(T entidade);
        Task AtualizarAsync(T entidade);
        Task ExcluirAsync(int id);
        Task ExcluirAsync(T entidade);
        Task<bool> ExisteAsync(IQuery<T> query);
        Task<TResult> ExecutarProcedureComOutputAsync<TResult>(string chamadaProcedure, string nomeParametroOutput);
        Task<TResult> ExecutarProcedureComOutputAsync<TResult>(string chamadaProcedure, string nomeParametroOutput, List<(string nome, object value)> parametros);
        Task ExecutarProcedureSemRetornoAsync(string chamadaProcedure);
        Task ExecutarProcedureSemRetornoAsync(string chamadaProcedure, List<(string nome, object value)> parametros);
    }
}
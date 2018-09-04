using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Yagohf.PUC.Data.Interface.Queries;
using Yagohf.PUC.Infraestrutura.Sorting;

namespace Yagohf.PUC.Data.Queries
{
    public class Query<T> : IQuery<T> where T : class
    {
        public List<Expression<Func<T, bool>>> Criteria { get; private set; }

        public List<Expression<Func<T, object>>> Includes { get; private set; }

        public List<string> IncludeStrings { get; private set; }

        public List<SortExpression<T>> OrderBy { get; private set; }

        public Query()
        {
            this.Criteria = new List<Expression<Func<T, bool>>>();
            this.Includes = new List<Expression<Func<T, object>>>();
            this.IncludeStrings = new List<string>();
            this.OrderBy = new List<SortExpression<T>>();
        }

        public IQuery<T> Filtrar(Expression<Func<T, bool>> filtro)
        {
            this.Criteria.Add(filtro);
            return this;
        }

        public IQuery<T> AdicionarInclude(Expression<Func<T, object>> include)
        {
            this.Includes.Add(include);
            return this;
        }

        public IQuery<T> AdicionarInclude(string include)
        {
            this.IncludeStrings.Add(include);
            return this;
        }

        public IQuery<T> OrdenarPor(Expression<Func<T, object>> expression)
        {
            return this.Ordenar(expression, false);
        }

        public IQuery<T> OrdenarPorDescendente(Expression<Func<T, object>> expression)
        {
            return this.Ordenar(expression, true);
        }

        private IQuery<T> Ordenar(Expression<Func<T, object>> expression, bool descendente)
        {
            this.OrderBy.Add(new SortExpression<T>(expression, descendente));
            return this;
        }
    }
}

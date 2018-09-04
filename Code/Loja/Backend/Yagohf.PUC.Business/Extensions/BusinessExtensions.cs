using AutoMapper;
using Yagohf.PUC.Model.Infraestrutura;
using System.Collections.Generic;
using System.Linq;

namespace Yagohf.PUC.Business.Extensions
{
    public static class BusinessExtensions
    {
        public static Listagem<TDestino> Mapear<TOrigem, TDestino>(this Listagem<TOrigem> listaOriginal, IMapper mapper)
            where TDestino : class
            where TOrigem : class
        {
            Listagem<TDestino> retorno = new Listagem<TDestino>(
                listaOriginal.Lista.Mapear<TOrigem, TDestino>(mapper),
                listaOriginal.Paginacao);

            return retorno;
        }

        public static IEnumerable<TDestino> Mapear<TOrigem, TDestino>(this IEnumerable<TOrigem> listaOriginal, IMapper mapper)
           where TDestino : class
           where TOrigem : class
        {
            return listaOriginal.Select(x => mapper.Map<TDestino>(x)).AsEnumerable();
        }
    }
}

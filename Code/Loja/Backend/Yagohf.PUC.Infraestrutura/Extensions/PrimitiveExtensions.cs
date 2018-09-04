using System;

namespace Yagohf.PUC.Infraestrutura.Extensions
{
    public static class PrimitiveExtensions
    {
        /// <summary>
        /// Método para converter um object para um tipo genérico.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns>Objeto convertido no tipo especificado.</returns>
        public static T ToType<T>(this object obj)
        {
            Type t = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);
            return (T)Convert.ChangeType(obj, t);
        }

        //TODO - remover depois de decidir se vou usar a autenticação padrão.
        /// <summary>
        /// O UserSystem não permite cadastrar rotas com os caracteres de chave {}, impedindo cadastrar URLs
        /// com path parameters no modelo em que o template é retornado pelo ActionDescriptor do MVC.
        /// Esse método permite trazer as chaves de volta para uma string ClearText, substituindo os caracteres
        /// percent encoded de volta para texto puro.
        /// https://en.wikipedia.org/wiki/Percent-encoding
        /// </summary>
        /// <param name="strPercentEncoded">String com as chaves em formato PercentEncoded.</param>
        /// <returns>String com chaves em ClearText.</returns>
        public static string TransformarChaves(this string strPercentEncoded)
        {
            return strPercentEncoded.Replace("%7B", "{").Replace("%7D", "}");
        }
    }
}

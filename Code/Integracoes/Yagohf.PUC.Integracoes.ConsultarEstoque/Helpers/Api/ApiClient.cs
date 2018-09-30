using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Yagohf.PUC.Integracoes.ConsultarEstoque.Helpers.Api;

namespace SGI.Frontend.Infraestrutura.Api.Client
{
    public class ApiClient
    {
        #region [ Sobrecargas ]

        #region [ GET ]
        public async Task<T> Get<T>(string urlBase, string recurso, IEnumerable<ParametroApi> parametros) where T : class
        {
            return await this.GetImplemented<T>(urlBase, recurso, parametros, null);
        }

        public async Task<T> Get<T>(string urlBase, string recurso, IEnumerable<ParametroApi> parametros, Dictionary<string, string> headers) where T : class
        {
            return await this.GetImplemented<T>(urlBase, recurso, parametros, headers);
        }

        #endregion

        #region [ PUT ]
        public async Task<bool> Put<T>(string urlBase, string recurso, T objeto, IEnumerable<ParametroApi> parametros) where T : class
        {
            return await this.PutImplemented<T>(urlBase, recurso, objeto, parametros, null);
        }

        public async Task<bool> Put<T>(string urlBase, string recurso, T objeto, IEnumerable<ParametroApi> parametros, Dictionary<string, string> headers) where T : class
        {
            return await this.PutImplemented<T>(urlBase, recurso, objeto, parametros, headers);
        }

        #endregion

        #region [ POST ]
        public async Task<T> Post<T>(string urlBase, string recurso, T objeto) where T : class
        {
            return await this.PostImplemented<T>(urlBase, recurso, objeto, null);
        }

        public async Task<T> Post<T>(string urlBase, string recurso, T objeto, Dictionary<string, string> headers) where T : class
        {
            return await this.PostImplemented<T>(urlBase, recurso, objeto, headers);
        }

        public async Task<TOut> Post<TIn, TOut>(string urlBase, string recurso, TIn objeto) where TIn : class where TOut : class
        {
            return await this.PostImplemented<TIn, TOut>(urlBase, recurso, objeto, null);
        }

        public async Task<TOut> Post<TIn, TOut>(string urlBase, string recurso, TIn objeto, Dictionary<string, string> headers) where TIn : class where TOut : class
        {
            return await this.PostImplemented<TIn, TOut>(urlBase, recurso, objeto, headers);
        }

        #endregion

        #region [ DELETE ]
        public async Task<bool> Delete(string urlBase, string recurso, IEnumerable<ParametroApi> parametros)
        {
            return await this.DeleteImplemented(urlBase, recurso, parametros, null);
        }

        public async Task<bool> Delete(string urlBase, string recurso, IEnumerable<ParametroApi> parametros, Dictionary<string, string> headers)
        {
            return await this.DeleteImplemented(urlBase, recurso, parametros, headers);
        }

        #endregion

        #endregion

        #region [ Implementações ]
        private async Task<T> GetImplemented<T>(string urlBase, string recurso, IEnumerable<ParametroApi> parametros, Dictionary<string, string> headers)
        {
            HttpRequestMessage request = this.PrepararRequest(HttpMethod.Get, urlBase, recurso, parametros, headers);
            var jsonRetorno = await this.EnviarRequisicao(request);
            return JsonConvert.DeserializeObject<T>(jsonRetorno);
        }

        private async Task<bool> PutImplemented<T>(string urlBase, string recurso, T objeto, IEnumerable<ParametroApi> parametros, Dictionary<string, string> headers)
        {
            HttpRequestMessage request = this.PrepararRequest(HttpMethod.Put, urlBase, recurso, parametros, headers);
            this.EnviarObjetoJsonCorpo(objeto, request);
            await this.EnviarRequisicao(request);
            return true;
        }

        private async Task<T> PostImplemented<T>(string urlBase, string recurso, T objeto, Dictionary<string, string> headers) where T : class
        {
            return await EnviarPostGenerico<T, T>(urlBase, recurso, objeto, headers);
        }

        private async Task<TOut> PostImplemented<TIn, TOut>(string urlBase, string recurso, TIn objeto, Dictionary<string, string> headers) where TOut : class where TIn : class
        {
            return await EnviarPostGenerico<TIn, TOut>(urlBase, recurso, objeto, headers);
        }

        private async Task<bool> DeleteImplemented(string urlBase, string recurso, IEnumerable<ParametroApi> parametros, Dictionary<string, string> headers)
        {
            HttpRequestMessage request = this.PrepararRequest(HttpMethod.Delete, urlBase, recurso, parametros, headers);
            await this.EnviarRequisicao(request);
            return true;
        }

        #endregion

        #region [ Auxiliares ]
        private HttpRequestMessage PrepararRequest(HttpMethod metodo, string urlBase, string recurso, IEnumerable<ParametroApi> parametros, Dictionary<string, string> headers)
        {
            HttpRequestMessage request = new HttpRequestMessage(metodo, this.PrepararUrl(string.Concat(urlBase, recurso), parametros));

            if (headers != null && headers.Any())
            {
                headers.ToList().ForEach(x =>
                {
                    request.Headers.Add(x.Key, x.Value);
                });
            }

            return request;
        }

        private async Task<TOut> EnviarPostGenerico<TIn, TOut>(string urlBase, string recurso, TIn objeto, Dictionary<string, string> headers) where TIn : class where TOut : class
        {
            HttpRequestMessage request = this.PrepararRequest(HttpMethod.Post, urlBase, recurso, null, headers);
            this.EnviarObjetoJsonCorpo(objeto, request);
            var jsonRetorno = await this.EnviarRequisicao(request);

            if (typeof(TOut) == typeof(string))
            {
                return jsonRetorno as TOut;
            }
            else
            {
                return JsonConvert.DeserializeObject<TOut>(jsonRetorno);
            }
        }

        private void EnviarObjetoJsonCorpo<T>(T objeto, HttpRequestMessage request)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");
            request.Content = content;
        }

        private string PrepararUrl(string urlCrua, IEnumerable<ParametroApi> parametros)
        {
            urlCrua = this.ReplaceSkippingFirst(urlCrua, "//", "/");
            if (parametros != null)
            {
                if (parametros.Any(p => p.Tipo == EnumApiParametroTipo.PATH))
                {
                    parametros.Where(p => p.Tipo == EnumApiParametroTipo.PATH).ToList().ForEach(p =>
                    {
                        urlCrua = urlCrua.Replace(string.Concat("{", p.Nome, "}"), p.Valor);
                    });
                }

                if (parametros.Any(p => p.Tipo == EnumApiParametroTipo.QUERY_STRING))
                {
                    urlCrua = string.Format("{0}?{1}", urlCrua, string.Join("&", parametros.Where(p => p.Tipo == EnumApiParametroTipo.QUERY_STRING).Select(p => string.Format("{0}={1}", p.Nome, p.Valor))));
                }
            }

            return urlCrua;
        }

        private async Task<string> EnviarRequisicao(HttpRequestMessage request)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new System.Exception("Falha de comunicação com a API");
                }
            }
        }

        private string ReplaceSkippingFirst(string strOriginal, string caractereOrig, string caractereNovo)
        {
            string str = strOriginal.Substring(0, strOriginal.IndexOf(caractereOrig, StringComparison.OrdinalIgnoreCase) + caractereOrig.Length);
            strOriginal = str + strOriginal.Substring(str.Length).Replace(caractereOrig, caractereNovo);
            return strOriginal;
        }

        #endregion
    }
}

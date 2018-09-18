using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Yagohf.PUC.Business.Interface.Dominio;
using Yagohf.PUC.Infraestrutura.Configuration;
using Yagohf.PUC.Model.DTO.Usuario;

namespace Yagohf.PUC.Api.Infraestrutura.Autenticacao
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly IUsuarioBusiness _usuarioBusiness;
        private readonly ConfiguracoesApp _configuracoesApp;

        public AutenticacaoService(IUsuarioBusiness usuarioBusiness, ConfiguracoesApp configuracoesApp)
        {
            this._usuarioBusiness = usuarioBusiness;
            this._configuracoesApp = configuracoesApp;
        }

        public async Task<TokenDTO> Autenticar(AutenticacaoDTO autenticacao)
        {
            var usuarioAutenticado = await this._usuarioBusiness.Validar(autenticacao);
            if (usuarioAutenticado == null)
            {
                return null;
            }

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this._configuracoesApp.ChaveCriptografiaToken);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuarioAutenticado.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            //TODO - adicionar CLAIMS.
            
            var token = tokenHandler.CreateToken(tokenDescriptor);
            TokenDTO tokenDTO = new TokenDTO();
            tokenDTO.Token = tokenHandler.WriteToken(token);
            return tokenDTO;
        }
    }
}

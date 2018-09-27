using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Yagohf.PUC.Integracoes.Infraestrutura.Configuration;
using Yagohf.PUC.Integracoes.Infraestrutura.Enumeradores;
using Yagohf.PUC.Integracoes.Model;
using Yagohf.PUC.Integracoes.Service.Interface.Dominio;

namespace Yagohf.PUC.Integracoes.Api.Infraestrutura.Autenticacao
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ConfiguracoesApp _configuracoesApp;

        public AutenticacaoService(IUsuarioService usuarioService, ConfiguracoesApp configuracoesApp)
        {
            this._usuarioService = usuarioService;
            this._configuracoesApp = configuracoesApp;
        }

        public TokenGerado Autenticar(Yagohf.PUC.Integracoes.Model.Autenticacao autenticacao)
        {
            var usuarioAutenticado = this._usuarioService.Validar(autenticacao);
            if (usuarioAutenticado == null)
            {
                return null;
            }

            // Geração de JWT
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

            tokenDescriptor.Subject.AddClaims(this.ObterClaims(usuarioAutenticado));

            var token = tokenHandler.CreateToken(tokenDescriptor);
            TokenGerado tokenRetornar = new TokenGerado();
            tokenRetornar.Token = tokenHandler.WriteToken(token);
            return tokenRetornar;
        }

        private List<Claim> ObterClaims(Usuario usuarioAutenticado)
        {
            List<Claim> claims = new List<Claim>();

            if (usuarioAutenticado.Perfis.Contains(EnumPerfil.FORNECEDOR))
            {
                claims.Add(new Claim("FORNECEDOR", "1"));
            }

            return claims;
        }
    }
}

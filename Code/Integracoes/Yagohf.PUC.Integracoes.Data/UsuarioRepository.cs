using System;
using System.Collections.Generic;
using Yagohf.PUC.Integracoes.Data.Interface;
using Yagohf.PUC.Integracoes.Infraestrutura.Configuration;
using Yagohf.PUC.Integracoes.Infraestrutura.Enumeradores;
using Yagohf.PUC.Integracoes.Model;

namespace Yagohf.PUC.Integracoes.Data
{
    public class UsuarioRepository : RepositoryBase, IUsuarioRepository
    {
        public UsuarioRepository(IConfiguracoesBanco configuracoesBanco) : base(configuracoesBanco)
        {
        }

        public Usuario RecuperarPorLogin(string login)
        {
            using (var conn = this.ObterConexao())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = CMD_RECUPERAR_USUARIO_POR_LOGIN;

                    var paramLogin = cmd.CreateParameter();
                    paramLogin.DbType = System.Data.DbType.AnsiString;
                    paramLogin.ParameterName = "@Login";
                    paramLogin.Value = login;
                    cmd.Parameters.Add(paramLogin);

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Usuario u = new Usuario();
                            u.Id = Convert.ToInt32(reader["Id"].ToString());
                            u.Login = reader["Login"].ToString();
                            u.Senha = reader["Senha"].ToString();
                            return u;
                        }
                    }
                }
            }

            return null;
        }

        public IEnumerable<EnumPerfil> RecuperarPerfisPorUsuario(string login)
        {
            List<EnumPerfil> perfis = new List<EnumPerfil>();
            using (var conn = this.ObterConexao())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = CMD_RECUPERAR_PERFIS_POR_USUARIO;

                    var paramLogin = cmd.CreateParameter();
                    paramLogin.ParameterName = "@Login";
                    paramLogin.DbType = System.Data.DbType.AnsiString;
                    paramLogin.Value = login;
                    cmd.Parameters.Add(paramLogin);

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EnumPerfil perfil = (EnumPerfil)Convert.ToInt32(reader["IdPerfil"].ToString());
                            perfis.Add(perfil);
                        }
                    }
                }
            }

            return perfis;
        }

        #region [ Comandos ]
        private const string CMD_RECUPERAR_USUARIO_POR_LOGIN = @"
SELECT 
Id,
[Login],
Senha
FROM
[dbo].[Usuario]
WHERE
[Login] = @Login
";

        private const string CMD_RECUPERAR_PERFIS_POR_USUARIO = @"
SELECT UP.IdPerfil
FROM [dbo].[UsuarioPerfil] UP
INNER JOIN
[dbo].[Usuario] U
ON U.Id = UP.IdUsuario
WHERE U.[Login] = @Login
";
        #endregion
    }
}

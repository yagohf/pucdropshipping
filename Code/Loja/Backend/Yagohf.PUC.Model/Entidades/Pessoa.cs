using System.Collections.Generic;

namespace Yagohf.PUC.Model.Entidades
{
    public class Pessoa : EntidadeBase
    {
        public int? IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Documento { get; set; }

        //Relacionamentos
        public ICollection<Pedido> Compras { get; set; }
        public ICollection<Pedido> Vendas { get; set; }
        public Usuario Usuario { get; set; }
        public ICollection<PessoaEndereco> PessoaEnderecos { get; set; }
        public Fornecedor Fornecedor { get; set; }
    }
}

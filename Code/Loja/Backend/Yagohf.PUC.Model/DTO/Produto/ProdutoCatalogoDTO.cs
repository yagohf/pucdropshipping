namespace Yagohf.PUC.Model.DTO.Produto
{
    public class ProdutoCatalogoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Disponivel { get; set; }
        public decimal Preco { get; set; }
    }
}

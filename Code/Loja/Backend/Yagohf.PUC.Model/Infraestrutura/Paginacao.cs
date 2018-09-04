namespace Yagohf.PUC.Model.Infraestrutura
{
    public class Paginacao
    {
        private readonly int _qtdRegistrosPorPagina;
        private readonly int _totalRegistros;
        private readonly int _paginaAtual;

        public Paginacao(int paginaAtual, int totalRegistros, int qtdRegistrosPorPagina)
        {
            this._totalRegistros = totalRegistros;
            this._paginaAtual = paginaAtual;
            this._qtdRegistrosPorPagina = qtdRegistrosPorPagina;
        }

        public int PaginaAtual
        {
            get
            {
                return this._paginaAtual;
            }
        }

        public int QtdRegistrosPorPagina
        {
            get
            {
                return this._qtdRegistrosPorPagina;
            }
        }

        public int TotalRegistros
        {
            get
            {
                return this._totalRegistros;
            }
        }
    }
}

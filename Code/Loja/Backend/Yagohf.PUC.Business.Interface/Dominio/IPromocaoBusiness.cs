using System.Collections.Generic;
using System.Threading.Tasks;
using Yagohf.PUC.Model.DTO.Promocao;

namespace Yagohf.PUC.Business.Interface.Dominio
{
    public interface IPromocaoBusiness
    {
        Task<IEnumerable<PromocaoDTO>> ListarTodasAtivasAsync();
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Yagohf.PUC.Model.DTO.Propaganda;

namespace Yagohf.PUC.Business.Interface.Dominio
{
    public interface IPropagandaBusiness
    {
        Task<IEnumerable<PropagandaDTO>> ListarTodasAtivasAsync();
    }
}

using System;

namespace Yagohf.PUC.Integracoes.Model
{
    public class Job
    {
        public int Id { get; set; }
        public DateTime? UltimaExecucao { get; set; }
        public int PeriodicidadeMinutos { get; set; }
    }
}

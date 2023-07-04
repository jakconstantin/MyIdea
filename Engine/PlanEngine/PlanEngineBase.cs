using Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.PlanEngine
{
    public abstract class PlanEngineBase
    {
        public abstract Task<List<IResult>> RunParse(CancellationToken stoppingToken = default);
    }
}

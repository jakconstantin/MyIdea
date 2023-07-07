using RunPlan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunPlan
{
    class Starter
    {
        public static async Task<int> Main(string[] args)
        {
            try
            {
                Program p = new Program();
                return await p.Start(args) ? 0 : 1;
            }
            catch (Exception ex)
            {
                return 1;
            }
        }
    }
}

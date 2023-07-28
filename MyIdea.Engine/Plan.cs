using Engine.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Plan
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string SearchText { get; set; }

        public StoreType StoreType { get; set; }

        public int PriceMax { get; set; } = 1000;

        public int PriceMin { get; set; }

        public string Enail { get; set; }

        public int? DistanceMax { get; set; } = null;
        public double? Latitude { get; set; } = null;
        public double? Longitude { get; set; } = null;

        public static string GetPlanLogPath(string planID)
        {
            //return String.Format("{0}\\{1}.{2}", EngineSettings.Instance.LogFolder, planID,
            //                                         EngineSettings.LogFileExtension);
            return String.Format("{0}\\{1}.{2}", Directory.GetCurrentDirectory(), planID, "log");
        }

        public static string GetPlanLogName(string planID)
        {                              
            return String.Format("{0}.{1}", planID, "log");
        }

    }
}

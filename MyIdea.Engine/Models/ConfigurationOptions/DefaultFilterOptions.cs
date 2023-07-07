using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models.ConfigurationOptions
{
    public class DefaultFilterOptions : BaseOptions
    {
        public override string Name => "DefaultFilter";

        public int PriceMin { get; set; }

        public int PriceMax { get; set; }

        public string SearchText { get; set; } = "";
    }
}

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

    }
}

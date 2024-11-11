using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProj_PTMS
{
    public class Task
    {
        public string? Name { get; set; }
        public int Priority { get; set; }
        public int Category { get; set; }

        public string GetCategoryName(int category)
        {
            switch (category)
            {
                case 0: return "Undefined";
                case 1: return "Work";
                case 2: return "Personal";
                case 3: return "Study";
                default: return "Unknown";
            }
        }
    }
}

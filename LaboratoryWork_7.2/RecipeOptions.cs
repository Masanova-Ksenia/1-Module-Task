using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork_7._2
{
    public class RecipeOptions
    {
        public bool SkipCondiments { get; set; } = false;
        public int SugarUnits { get; set; } = 1; 
        public string MilkType { get; set; } = "cow_milk"; 
        public List<string> ExtraCondiments { get; } = new List<string>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ElectricCalculator.Classes
{
    public class Customer(string id, string name)
    {
        public string ID => id;
        public string Name => name;
        public float CurrentIndex { get; set; } = 0F;
        public DateTime IndexTime { get; set; }
    }
}

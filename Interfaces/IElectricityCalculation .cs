using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricCalculator.Interfaces
{
    public interface IElectricityCalculation
    {
        public decimal SubTotal();
        public decimal Total();
        public decimal Tax();
    }
}

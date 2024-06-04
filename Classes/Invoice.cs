using ElectricCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricCalculator.Classes
{
    public class Invoice
    {
        protected float TaxRate = 0.08F;
    }

    public class RepaidCardMeterElectricityInvoice(float index) : Invoice, IElectricityCalculation
    {
        private readonly decimal RepaidCardMeterPrice = 2649;
        private float Index => index;

        public decimal SubTotal()
        {
            return (decimal)(this.Index * (float)this.RepaidCardMeterPrice);
        }
        public decimal Total()
        {
            decimal total = this.SubTotal() + this.Tax();
            return total;
        }

        public decimal Tax()
        {
            decimal tax = (decimal)((float)this.SubTotal() * this.TaxRate);
            return tax;
        }
    }

    public class RetailElectricityInvoice(float index) : Invoice, IElectricityCalculation
    {
        private readonly int[] ArrayIndex = new int[6] { 0, 50, 100, 200, 300, 400 };
        private readonly int[] ArrayPrice = new int[6] { 1806, 1866, 2167, 2729, 3050, 3151 };
        
        public decimal SubTotal()
        {
            float subTotal = 0;
            float tempIndex = this.Index;
            for (int i = this.ArrayIndex.Length - 1; i >= 0; i--)
            {
                if (tempIndex < this.ArrayIndex[i])
                {
                    continue;
                }
                float subIndex = tempIndex - this.ArrayIndex[i];
                if (subIndex > 0)
                {
                    subTotal += subIndex * this.ArrayPrice[i];
                    tempIndex = this.ArrayIndex[i];
                }
            }

            return (decimal)subTotal;
        }

        public decimal Total()
        {
            decimal total = this.SubTotal() + this.Tax();
            return total;
        }

        public decimal Tax()
        {
            decimal tax = (decimal)((float)this.SubTotal() * this.TaxRate);
            return tax;
        }
    }
}

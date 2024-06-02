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
        // Level 1: 0-50 kWh
        private readonly decimal PriceLevel1 = 1806;
        // Level 2: 51-100 kWh
        private readonly decimal PriceLevel2 = 1866;
        // Level 3: 101-200 kWh
        private readonly decimal PriceLevel3 = 2167;
        // Level 4: 201-300 kWh
        private readonly decimal PriceLevel4 = 2729;
        // Level 5: 301-400 kWh
        private readonly decimal PriceLevel5 = 3050;
        // Level 6: Above 401 kWh
        private readonly decimal PriceLevel6 = 3151;
        private float Index => index;

        private decimal CalculateTotalLevel1(float index)
        {
            return (decimal)(index * (float)PriceLevel1);
        }

        private decimal CalculateTotalLevel2(float index)
        {
            return (decimal)(index * (float)PriceLevel2);
        }

        private decimal CalculateTotalLevel3(float index)
        {
            return (decimal)(index * (float)PriceLevel3);
        }

        private decimal CalculateTotalLevel4(float index)
        {
            return (decimal)(index * (float)PriceLevel4);
        }

        private decimal CalculateTotalLevel5(float index)
        {
            return (decimal)(index * (float)PriceLevel5);
        }

        private decimal CalculateTotalLevel6()
        {
            return (decimal)((this.Index - 400) * (float)PriceLevel6);
        }

        public decimal SubTotal()
        {
            decimal subTotal = 0;
            if (this.Index <= 50)
            {
                subTotal += this.CalculateTotalLevel1(this.Index);
            }
            else if (this.Index >= 51 && this.Index <= 100)
            {
                subTotal += this.CalculateTotalLevel1(50) + this.CalculateTotalLevel2(this.Index - 50);
            }
            else if (this.Index >= 101 && this.Index <= 200)
            {
                subTotal += this.CalculateTotalLevel1(50) + this.CalculateTotalLevel2(50) + this.CalculateTotalLevel3(this.Index - 100);
            }
            else if (this.Index >= 201 && this.Index <= 300)
            {
                subTotal += this.CalculateTotalLevel1(50) + this.CalculateTotalLevel2(50) + this.CalculateTotalLevel3(100) + this.CalculateTotalLevel4(this.Index - 200);
            }
            else if (this.Index >= 301 && this.Index <= 400)
            {
                subTotal += 
                    this.CalculateTotalLevel1(50)
                    + this.CalculateTotalLevel2(50)
                    + this.CalculateTotalLevel3(100)
                    + this.CalculateTotalLevel4(100)
                    + this.CalculateTotalLevel5(this.Index - 300);
            }
            else 
            {
                subTotal +=
                    this.CalculateTotalLevel1(50)
                    + this.CalculateTotalLevel2(50)
                    + this.CalculateTotalLevel3(100)
                    + this.CalculateTotalLevel4(100)
                    + this.CalculateTotalLevel5(100)
                    + this.CalculateTotalLevel6();
            }
            return subTotal;
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

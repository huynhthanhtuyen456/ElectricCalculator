using ElectricCalculator.Classes;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ElectricCalculator
{
    public partial class ElectricCalculatorForm : Form
    {
        private readonly string IDRgxPattern = @"[A-Za-z0-9]+$";
        private readonly string NameRgxPattern = @"^[A-Za-z\s]+$";
        private readonly string CurrentIndexPattern = @"^[0-9.]+$";
        private bool BtnClcState { get; set; }
        private bool IdTxtChangedState { get; set; }
        private bool NameTxtChangedState { get; set; }
        private bool CurrentIndexTxtChangedState { get; set; }
        private List<Customer> CustomerList { get; set; }

        public ElectricCalculatorForm()
        {
            InitializeComponent();
            this.CustomerList = new List<Customer>();
        }

        private void ElectricCalculatorForm_Load(object sender, EventArgs e)
        {
            this.CustomerList = new List<Customer>();
            this.IdTxtChangedState = false;
            this.NameTxtChangedState = false;
            this.CurrentIndexTxtChangedState = false;
            this.BtnCalculate.Enabled = false;
            this.SetBtnClcState();
            this.ListViewElectricCost.Columns.Add("ID");
            this.ListViewElectricCost.Columns.Add("Name");
            this.ListViewElectricCost.Columns.Add("Old Index");
            this.ListViewElectricCost.Columns.Add("Current Index");
            this.ListViewElectricCost.Columns.Add("Power Consumption");
            this.ListViewElectricCost.Columns.Add("Sub Total");
            this.ListViewElectricCost.Columns.Add("Tax");
            this.ListViewElectricCost.Columns.Add("Total");
            this.ListViewElectricCost.Columns.Add("Exported Date");
            this.ListViewElectricCost.Font = new Font(ListViewElectricCost.Font, FontStyle.Bold);
            this.ListViewElectricCost.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize);
            this.ListViewElectricCost.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
            this.ListViewElectricCost.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
            this.ListViewElectricCost.AutoResizeColumn(5, ColumnHeaderAutoResizeStyle.HeaderSize);
            this.comboBoxTypePrice.Items.Add("Residential Use");
            this.comboBoxTypePrice.Items.Add("Repaid Card Meter");
            this.comboBoxTypePrice.SelectedItem = "Residential Use";
            this.comboBoxTypePrice.SelectedIndex = 0;
        }

        private void SetBtnClcState()
        {
            this.BtnClcState = this.IdTxtChangedState && this.NameTxtChangedState && this.CurrentIndexTxtChangedState;
            if (this.BtnClcState) this.BtnCalculate.Enabled = true;
            else this.BtnCalculate.Enabled = false;
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            IEnumerable<Customer> queryCustomerByID = 
                from c in this.CustomerList
                where c.ID.Equals(this.TxbID.Text.ToUpper(), StringComparison.CurrentCultureIgnoreCase)
                select c;

            Customer customer;
            DateTime now = DateTime.Now;
            if (!queryCustomerByID.Any())
            {
                string cstName = this.TxbCustomerName.Text;
                cstName = cstName.Trim();
                List<string> stringList = new(cstName.Split(" "));
                var formattedNameList = new List<string>();
                foreach (string s in stringList)
                {
                    _ = s.ToLower();
                    string newS = char.ToUpper(s.First()) + s.Substring(1).ToLower();
                    formattedNameList.Add(newS);
                }

                string formattedName = string.Join(" ", formattedNameList);
                customer = new(this.TxbID.Text.ToString().ToUpper(), formattedName);
                customer.IndexTime = now;
                this.CustomerList.Add(customer);
            }
            else
            {
                customer = queryCustomerByID.First();
                customer.IndexTime = customer.IndexTime.AddMonths(1);
            }

            float oldIndex = customer.CurrentIndex;
            float currentIndex = float.Parse(this.TxbCurrentIndex.Text);
            if (currentIndex < oldIndex)
            {
                MessageBox.Show("Current Index cannot be less than Old Index!", "Index Error!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                this.BtnCalculate.Enabled = false;
                return;
            }
            customer.CurrentIndex = currentIndex;
            float powerConsumption = currentIndex - oldIndex;
            decimal subTotal = 0;
            decimal total = 0;
            decimal tax = 0;
            if (this.comboBoxTypePrice.SelectedIndex == 0)
            {
                RetailElectricityInvoice retailElcInvoice = new RetailElectricityInvoice(powerConsumption);
                subTotal = retailElcInvoice.SubTotal();
                total = retailElcInvoice.Total();
                tax = retailElcInvoice.Tax();

            }
            else
            {
                RepaidCardMeterElectricityInvoice repaidCrdMtrElectricityInvoice = new RepaidCardMeterElectricityInvoice(powerConsumption);
                subTotal = repaidCrdMtrElectricityInvoice.SubTotal();
                total = repaidCrdMtrElectricityInvoice.Total();
                tax = repaidCrdMtrElectricityInvoice.Tax();
            }
            ListViewItem lstCustItem = new ListViewItem(
                new string[]
                {
                    customer.ID,
                    customer.Name,
                    $"{oldIndex:#,##0.00} kWh",
                    $"{currentIndex:#,##0.00} kWh",
                    $"{powerConsumption:#,##0.00} kWh",
                    $"{subTotal:#,##0} VND",
                    $"{tax:#,##0} VND",
                    $"{total:#,##0} VND",
                    customer.IndexTime.ToString("dd/MM/yyyy")
                }
            );
            lstCustItem.Font = new Font(ListViewElectricCost.Font, FontStyle.Regular);
            this.ListViewElectricCost.Items.Add(lstCustItem);
            this.ListViewElectricCost.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
            this.ListViewElectricCost.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);
            this.ListViewElectricCost.AutoResizeColumn(5, ColumnHeaderAutoResizeStyle.ColumnContent);
            this.ListViewElectricCost.AutoResizeColumn(6, ColumnHeaderAutoResizeStyle.ColumnContent);
            this.ListViewElectricCost.AutoResizeColumn(7, ColumnHeaderAutoResizeStyle.ColumnContent);
            this.ListViewElectricCost.AutoResizeColumn(8, ColumnHeaderAutoResizeStyle.ColumnContent);
            this.BtnCalculate.Enabled = false;
        }

        private bool IsValidID(string id)
        {
            Regex idRegex = new(this.IDRgxPattern);
            return true && idRegex.IsMatch(id);
        }

        private bool IsValidName(string name)
        {
            Regex nameRegex = new(this.NameRgxPattern);
            return true && nameRegex.IsMatch(name);
        }

        private bool IsValidCurrentIndex(string currIndex)
        {
            Regex currentIndexRxg = new(this.CurrentIndexPattern);
            return true && currentIndexRxg.IsMatch(currIndex);
        }

        private void TxbID_TextChanged(object sender, EventArgs e)
        {
            this.LblIDMsgError.Text = string.Empty;
            this.IdTxtChangedState = true;
            if (!this.IsValidID(this.TxbID.Text))
            {
                this.LblIDMsgError.Text = "Only accepting numeric and alphabets!";
                this.LblIDMsgError.ForeColor = System.Drawing.Color.Red;
                this.IdTxtChangedState = false;
            }
            this.SetBtnClcState();
        }

        private void TxbCurrentIndex_TextChanged(object sender, EventArgs e)
        {
            this.LblCurrentIndexMsgError.Text = string.Empty;
            this.CurrentIndexTxtChangedState = true;
            if (!this.IsValidCurrentIndex(this.TxbCurrentIndex.Text))
            {
                this.LblCurrentIndexMsgError.Text = "Only accepting numeric!";
                this.LblCurrentIndexMsgError.ForeColor = System.Drawing.Color.Red;
                this.CurrentIndexTxtChangedState = false;
            }
            this.SetBtnClcState();
        }

        private void TxbCustomerName_TextChanged(object sender, EventArgs e)
        {
            this.LblNameMsgError.Text = string.Empty;
            this.NameTxtChangedState = true;
            if (!this.IsValidName(this.TxbCustomerName.Text))
            {
                this.LblNameMsgError.Text = "Only accepting alphabets!";
                this.LblNameMsgError.ForeColor = System.Drawing.Color.Red;
                this.NameTxtChangedState = false;
            }
            this.SetBtnClcState();
        }
    }
}

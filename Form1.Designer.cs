namespace ElectricCalculator
{
    partial class ElectricCalculatorForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblCustomerID = new Label();
            TxbID = new TextBox();
            lblCustomerName = new Label();
            TxbCustomerName = new TextBox();
            lblIndex = new Label();
            TxbCurrentIndex = new TextBox();
            ListViewElectricCost = new ListView();
            LblIDMsgError = new Label();
            LblNameMsgError = new Label();
            LblCurrentIndexMsgError = new Label();
            BtnCalculate = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            comboBoxTypePrice = new ComboBox();
            LblType = new Label();
            SuspendLayout();
            // 
            // lblCustomerID
            // 
            lblCustomerID.AutoSize = true;
            lblCustomerID.Location = new Point(6, 15);
            lblCustomerID.Name = "lblCustomerID";
            lblCustomerID.Size = new Size(73, 15);
            lblCustomerID.TabIndex = 0;
            lblCustomerID.Text = "Customer ID";
            // 
            // TxbID
            // 
            TxbID.Location = new Point(125, 12);
            TxbID.Name = "TxbID";
            TxbID.Size = new Size(100, 23);
            TxbID.TabIndex = 1;
            TxbID.TextChanged += TxbID_TextChanged;
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Location = new Point(6, 68);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(94, 15);
            lblCustomerName.TabIndex = 2;
            lblCustomerName.Text = "Customer Name";
            // 
            // TxbCustomerName
            // 
            TxbCustomerName.Location = new Point(125, 65);
            TxbCustomerName.Name = "TxbCustomerName";
            TxbCustomerName.Size = new Size(327, 23);
            TxbCustomerName.TabIndex = 3;
            TxbCustomerName.TextChanged += TxbCustomerName_TextChanged;
            // 
            // lblIndex
            // 
            lblIndex.AutoSize = true;
            lblIndex.Location = new Point(249, 15);
            lblIndex.Name = "lblIndex";
            lblIndex.Size = new Size(79, 15);
            lblIndex.TabIndex = 4;
            lblIndex.Text = "Current Index";
            // 
            // TxbCurrentIndex
            // 
            TxbCurrentIndex.Location = new Point(352, 12);
            TxbCurrentIndex.Name = "TxbCurrentIndex";
            TxbCurrentIndex.Size = new Size(100, 23);
            TxbCurrentIndex.TabIndex = 5;
            TxbCurrentIndex.TextChanged += TxbCurrentIndex_TextChanged;
            // 
            // ListViewElectricCost
            // 
            ListViewElectricCost.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ListViewElectricCost.Location = new Point(12, 160);
            ListViewElectricCost.Name = "ListViewElectricCost";
            ListViewElectricCost.Size = new Size(637, 293);
            ListViewElectricCost.TabIndex = 6;
            ListViewElectricCost.UseCompatibleStateImageBehavior = false;
            ListViewElectricCost.View = View.Details;
            // 
            // LblIDMsgError
            // 
            LblIDMsgError.AutoSize = true;
            LblIDMsgError.Location = new Point(125, 38);
            LblIDMsgError.Name = "LblIDMsgError";
            LblIDMsgError.Size = new Size(0, 15);
            LblIDMsgError.TabIndex = 7;
            // 
            // LblNameMsgError
            // 
            LblNameMsgError.AutoSize = true;
            LblNameMsgError.Location = new Point(125, 91);
            LblNameMsgError.Name = "LblNameMsgError";
            LblNameMsgError.Size = new Size(0, 15);
            LblNameMsgError.TabIndex = 8;
            // 
            // LblCurrentIndexMsgError
            // 
            LblCurrentIndexMsgError.AutoSize = true;
            LblCurrentIndexMsgError.Location = new Point(352, 38);
            LblCurrentIndexMsgError.Name = "LblCurrentIndexMsgError";
            LblCurrentIndexMsgError.Size = new Size(0, 15);
            LblCurrentIndexMsgError.TabIndex = 9;
            // 
            // BtnCalculate
            // 
            BtnCalculate.Location = new Point(125, 120);
            BtnCalculate.Name = "BtnCalculate";
            BtnCalculate.Size = new Size(327, 23);
            BtnCalculate.TabIndex = 10;
            BtnCalculate.Text = "Calculate";
            BtnCalculate.UseVisualStyleBackColor = true;
            BtnCalculate.Click += BtnCalculate_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Red;
            label1.Location = new Point(85, 15);
            label1.Name = "label1";
            label1.Size = new Size(12, 15);
            label1.TabIndex = 11;
            label1.Text = "*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Red;
            label2.Location = new Point(334, 15);
            label2.Name = "label2";
            label2.Size = new Size(12, 15);
            label2.TabIndex = 12;
            label2.Text = "*";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Red;
            label3.Location = new Point(106, 65);
            label3.Name = "label3";
            label3.Size = new Size(12, 15);
            label3.TabIndex = 13;
            label3.Text = "*";
            // 
            // comboBoxTypePrice
            // 
            comboBoxTypePrice.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTypePrice.FormattingEnabled = true;
            comboBoxTypePrice.Location = new Point(519, 12);
            comboBoxTypePrice.Name = "comboBoxTypePrice";
            comboBoxTypePrice.Size = new Size(130, 23);
            comboBoxTypePrice.TabIndex = 14;
            // 
            // LblType
            // 
            LblType.AutoSize = true;
            LblType.Location = new Point(482, 15);
            LblType.Name = "LblType";
            LblType.Size = new Size(31, 15);
            LblType.TabIndex = 15;
            LblType.Text = "Type";
            // 
            // ElectricCalculatorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(661, 465);
            Controls.Add(LblType);
            Controls.Add(comboBoxTypePrice);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(BtnCalculate);
            Controls.Add(LblCurrentIndexMsgError);
            Controls.Add(LblNameMsgError);
            Controls.Add(LblIDMsgError);
            Controls.Add(ListViewElectricCost);
            Controls.Add(TxbCurrentIndex);
            Controls.Add(lblIndex);
            Controls.Add(TxbCustomerName);
            Controls.Add(lblCustomerName);
            Controls.Add(TxbID);
            Controls.Add(lblCustomerID);
            MinimumSize = new Size(677, 504);
            Name = "ElectricCalculatorForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ElectricCalculator";
            Load += ElectricCalculatorForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCustomerID;
        private TextBox TxbID;
        private Label lblCustomerName;
        private TextBox TxbCustomerName;
        private Label lblIndex;
        private TextBox TxbCurrentIndex;
        private ListView ListViewElectricCost;
        private Label LblIDMsgError;
        private Label LblNameMsgError;
        private Label LblCurrentIndexMsgError;
        private Button BtnCalculate;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox comboBoxTypePrice;
        private Label LblType;
    }
}

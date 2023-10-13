using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monthly_Payment_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double purchasePrice = 0;
            double downPaymentAmount = 0;
            double interestRate = 0;
            int loanTerm = 0;
            double amountToFinance;
            double monthlyPayment;

            if (Double.TryParse(txtPurchasePrice.Text, out purchasePrice) &&
                Double.TryParse(txtDownPaymentAmount.Text, out downPaymentAmount) &&
                Double.TryParse(txtInterestRate.Text, out interestRate) &&
                Int32.TryParse(txtLoanTerm.Text, out loanTerm))
            {
                amountToFinance = purchasePrice - downPaymentAmount;
                txtAmountToFinance.Text = amountToFinance.ToString("C");

                double monthlyIR = interestRate / 12;

                monthlyPayment = amountToFinance * (monthlyIR * Math.Pow(1 + monthlyIR, loanTerm)) / (Math.Pow(1 + monthlyIR, loanTerm) - 1);
                monthlyPayment = Math.Round(monthlyPayment, 2);
                txtMonthlyPayment.Text = monthlyPayment.ToString("C");
            }
            {
                else
                    MessageBox.Show("Invalid input. Please enter valid numeric values on all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

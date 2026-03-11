using System.Diagnostics.Eventing.Reader;
using System.Linq.Expressions;

namespace InvoiceTotal
{
    public partial class frmInvoiceTotal : Form
    {
        public frmInvoiceTotal()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSubtotal.Text == "")
                {
                    MessageBox.Show("Subtotal is a required field.", "Entry Error");
                    txtSubtotal.Focus();
                    return;
                }
                decimal invoiceSubtotal = Convert.ToDecimal(txtSubtotal.Text);
                if (invoiceSubtotal <= 0) || invoiceSubtotal >= 1000) 
                {
                    MessageBox.Show("Subtotal must be greater than 0 and less than 10,000.", "Entry Error");
                    txtSubtotal.Focus();
                    return;
                }
            }
            string customerType = txtCustomerType.Text.Trim().ToUpper();
            decimal discountPercent = 0m;

            if (customerType == "R")
            {
                if (invoiceSubtotal <= 500)
                    discountPercent = .30m;
                else if (invoiceSubtotal >= 250)
                    discountPercent = .25m;
                else
                    discountPercent = 0m;
            }
            else if (customerType == "C")
            {
                discountPercent = .20m;
            }
            else if (customerType == "T")
            {
                if (invoiceSubtotal >= 500)
                    discountPercent = .50m;
                else
                    discountPercent = .40m;
            }
            else
            {
                discountPercent = .10m;
            }

            decimal discountAmount = invoiceSubtotal * discountPercent;
            decimal total = invoiceSubtotal - discountAmount;

            txtDiscountPercent.Text = discountPercent.ToString("p1");
            txtDiscountAmount.Text = discountAmount.ToString("c");
            txtTotal.Text = total.ToString("c");

            txtSubtotal.Focus();
        }
        CatchBlock Catch(Exception ex)
        {
            MessageBox.Show(ex.Message, ex.GetType().Name);
            txtSubtotal.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

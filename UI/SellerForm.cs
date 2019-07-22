using CrmBl.Model;
using System;
using System.Windows.Forms;

namespace UI
{
    public partial class SellerForm : Form
    {
        public Seller Seller { get; set; }

        public SellerForm()
        {
            InitializeComponent();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {

        }

        private void AddCustomer_Click(object sender, EventArgs e)
        {
            Seller = new Seller()
            {
                Name = textBox1.Text
            };

            Close();
        }
    }
}

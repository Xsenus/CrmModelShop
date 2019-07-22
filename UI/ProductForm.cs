using CrmBl.Model;
using System;
using System.Windows.Forms;

namespace UI
{
    public partial class ProductForm : Form
    {
        public Product Product { get; set; }

        public ProductForm()
        {
            InitializeComponent();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {

        }

        private void AddCustomer_Click(object sender, EventArgs e)
        {
            Product = new Product()
            {
                Name = textBox1.Text,
                Price = numericUpDown1.Value,
                Count = Convert.ToInt32(numericUpDown2.Value)
            };

            Close();
        }
    }
}

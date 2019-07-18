using CrmBl.Model;
using System;
using System.Windows.Forms;

namespace UI
{    
    public partial class Main : Form
    {
        CrmContext db;

        public Main()
        {
            InitializeComponent();
            db = new CrmContext();
        }

        private void ProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogProduct = new Catalog<Product>(db.Products);
            catalogProduct.Show();
        }

        private void SellerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sellerProduct = new Catalog<Seller>(db.Sellers);
            sellerProduct.Show();
        }

        private void CustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var customerProduct = new Catalog<Customer>(db.Customers);
            customerProduct.Show();
        }

        private void CheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var checkProduct = new Catalog<Check>(db.Checks);
            checkProduct.Show();
        }

        private void CustomerAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new CustomerForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
                db.Customers.Add(form.Customer);
                db.SaveChanges();
            }
        }
    }
}

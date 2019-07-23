using CrmBl.Model;
using System;
using System.Windows.Forms;

namespace UI
{
    public partial class Login : Form
    {
        public Customer Customer { get; set; }

        public Login()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Customer = new Customer()
            {
                Name = textBox1.Text
            };

            DialogResult = DialogResult.OK;
        }
    }
}

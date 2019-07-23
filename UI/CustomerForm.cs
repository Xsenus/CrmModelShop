﻿using CrmBl.Model;
using System;
using System.Windows.Forms;

namespace UI
{
    public partial class CustomerForm : Form
    {
        public Customer Customer { get; set; }

        public CustomerForm()
        {
            InitializeComponent();
        }

        public CustomerForm(Customer customer) : this()
        {
            Customer = customer ?? new Customer();
            textBox1.Text = Customer.Name;
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {

        }

        private void AddCustomer_Click(object sender, EventArgs e)
        {
            Customer = Customer ?? new Customer();
            Customer.Name = textBox1.Text;
            Close();
        }
    }
}

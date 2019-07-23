using CrmBl.Model;
using System;
using System.Windows.Forms;

namespace UI
{
    class CashBoxView
    {
        public CashDesk cashDesk;
        public Label CashDeskName { get; set; }
        public NumericUpDown Price { get; set; }
        public ProgressBar QueueLenght { get; set; }
        public Label LeaveCustomerCount { get; set; }

        public CashBoxView(CashDesk cashDesk, int number, int x, int y)
        {
            this.cashDesk = cashDesk;

            CashDeskName = new Label();
            Price = new NumericUpDown();
            QueueLenght = new ProgressBar();
            LeaveCustomerCount = new Label();

            CashDeskName.AutoSize = true;
            CashDeskName.Location = new System.Drawing.Point(x, y + 14);
            CashDeskName.Name = $"label{number}";
            CashDeskName.Size = new System.Drawing.Size(35, 13);
            CashDeskName.TabIndex = number;
            CashDeskName.Text = $"{cashDesk.ToString()}";

            Price.Location = new System.Drawing.Point(x + 65, y + 10);
            Price.Name = $"numericUpDown{number}";
            Price.Size = new System.Drawing.Size(120, 20);
            Price.TabIndex = number * 10;
            Price.Maximum = 100000000000;

            QueueLenght.Location = new System.Drawing.Point(x + 200, y + 10);
            QueueLenght.Maximum = cashDesk.MaxQueueLenght;
            QueueLenght.Name = $"progressBar{number}";
            QueueLenght.Size = new System.Drawing.Size(100, 20);
            QueueLenght.TabIndex = number * 20;
            QueueLenght.Value = 0;

            LeaveCustomerCount.AutoSize = true;
            LeaveCustomerCount.Location = new System.Drawing.Point(x + 300, y + 14);
            LeaveCustomerCount.Name = $"labelLeaveCustomerCount{number}";
            LeaveCustomerCount.Size = new System.Drawing.Size(35, 13);
            LeaveCustomerCount.TabIndex = number;
            LeaveCustomerCount.Text = "";

            cashDesk.CheckClosed += CashDesk_CheckClosed;
        }

        private void CashDesk_CheckClosed(object sender, Check e)
        {
            Price.Invoke((Action)delegate
            {
                Price.Value += e.Price;
                QueueLenght.Value = cashDesk.Count;
                LeaveCustomerCount.Text = $"Ушло: {cashDesk.ExitCustomer.ToString()}";
            });
        }
    }
}

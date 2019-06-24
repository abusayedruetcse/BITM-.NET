using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerAccountSystem
{
    public partial class IndexUi : Form
    {
        public IndexUi()
        {
            InitializeComponent();
        }

        private void entryLabel_Click(object sender, EventArgs e)
        {
            EntryUi entryUi = new EntryUi();
            entryUi.Show();
        }

        private void transactionLabel_Click(object sender, EventArgs e)
        {
            TransactionUi transactionUi = new TransactionUi();
            transactionUi.Show();
        }

        private void searchLabel_Click(object sender, EventArgs e)
        {
            SearchUi searchUi = new SearchUi();
            searchUi.Show();
        }
    }
}

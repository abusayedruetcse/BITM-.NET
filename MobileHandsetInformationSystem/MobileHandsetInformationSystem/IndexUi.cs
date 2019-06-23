using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileHandsetInformationSystem
{
    public partial class IndexUi : Form
    {
        public IndexUi()
        {
            InitializeComponent();
        }

        private void saveLabel_Click(object sender, EventArgs e)
        {
            SaveUi saveUi = new SaveUi();
            saveUi.Show();
        }

        private void searchRangeLabel_Click(object sender, EventArgs e)
        {
            SearchRangeUi searchRangeUi = new SearchRangeUi();
            searchRangeUi.Show();
        }

        private void searchIMEILabel_Click(object sender, EventArgs e)
        {

        }
    }
}

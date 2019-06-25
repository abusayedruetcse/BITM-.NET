using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagementSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MenuUi());
            //Application.Run(new CategoryUi());
            //Application.Run(new CompanyUi());
            //Application.Run(new ItemUi());
            //Application.Run(new StockInUi());
            //Application.Run(new StockOut());
            //Application.Run(new SearchandViewItemsSummary());
            //Application.Run(new ViewBetweenTwoDatesReport());
        }
    }
}

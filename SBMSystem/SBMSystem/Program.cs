﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SBMSystem
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
            Application.Run(new MenuListUi());
            //Application.Run(new CategoryUi());
            //Application.Run(new ProductUi());
            //Application.Run(new CustomerUi());
            //Application.Run(new SupplierUi());
            //Application.Run(new PurchaseUi());

        }
    }
}

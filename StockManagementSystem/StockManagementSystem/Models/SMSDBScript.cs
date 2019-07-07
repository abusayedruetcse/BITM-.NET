using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystem.Models
{
    public  class SMSDBScript
    {
        public static bool IscreatedDB = false;
        public static string ServerName { get; set; }
        public static string DatabaseName { get; set; }
        private static string SqlScript = "abc";      
    }
}

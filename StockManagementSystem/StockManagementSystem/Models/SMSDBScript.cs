using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using StockManagementSystem.Models;
using StockManagementSystem.BLL;

namespace StockManagementSystem.Models
{
    public  class SMSDBScript
    {
        public static bool IscreatedDB = false;
        public static string ServerName { get; set; }
        public static string DatabaseName { get; set; }
        private static string SqlScript = @"CREATE TABLE UserAccount(ID int IDENTITY(1,1),Email VARCHAR(35),UserName VARCHAR(35),Password VARCHAR(35))"+ 
            "CREATE TABLE Categories(ID int IDENTITY(1,1),Name VARCHAR(25))"+
            "CREATE TABLE Companies(ID int IDENTITY(1,1),Name VARCHAR(25))"+
            "CREATE TABLE Items(ID int IDENTITY(1,1),Name VARCHAR(25),CategoryID int,CompanyID int,ReorderLevel int,AvailableQuantity int)"+
            "CREATE TABLE StockIns(ID int IDENTITY(1,1),Date VARCHAR(10),Quantity int,ItemID int)"+
            "CREATE TABLE StockOuts(ID int IDENTITY(1,1),Date VARCHAR(20),Quantity int,ItemID int,Action VARCHAR(7))"+
            "";
        public static void Execute()
        {
            SystemSetupManager _systemSetupManager = new SystemSetupManager();
            _systemSetupManager.Execute(SMSDBScript.SqlScript);
        }
    }
}










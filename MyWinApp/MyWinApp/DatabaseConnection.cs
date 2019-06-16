using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyWinApp
{
    public partial class DatabaseConnection : Form
    {
        public DatabaseConnection()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            //1
            SqlConnection sqlConnection = new SqlConnection();
            String connectionString = @"Server=PC-301-17\SQLEXPRESS ;Database=StudentDB ; Integrated Security=True ";
            sqlConnection.ConnectionString = connectionString;

            //2
            SqlCommand sqlCommand = new SqlCommand();
            String commandString = @"INSERT INTO Students(RollNo,Name,Age,Address,DistrictID) VALUES('CSE001', 'ALI', 21, 'Mirpur', 1)";
            sqlCommand.CommandText = commandString;
            sqlCommand.Connection = sqlConnection;

            //3
            sqlConnection.Open();

            //4
            int isExecuted = 0;
            isExecuted=sqlCommand.ExecuteNonQuery();
            if(isExecuted>0)
            {
                MessageBox.Show("Saved Successfully");
            }
            else
            {
                MessageBox.Show("Save Failed!");
            }

            //5
            sqlConnection.Close();


        }
    }
}

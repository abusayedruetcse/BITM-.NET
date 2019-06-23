using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyWinApp
{
    public partial class DateForm : Form
    {
        public DateForm()
        {
            InitializeComponent();
        }

        private void GetDateButton_Click(object sender, EventArgs e)
        {
            string currentDate = DateTime.Now.ToString("yyyy/MM/dd");
            currentDateTextBox.Text = currentDate;
        }

        private void GetTimeButton_Click(object sender, EventArgs e)
        {
            string currentTime = DateTime.Now.ToShortTimeString();
            currentTimeTextBox.Text = currentTime;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string connectionString = @"Server=DESKTOP-AAHS936\SQLEXPRESS;Database=DateTimeDB;Integrated Security=true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string commandString = "INSERT INTO DateTable VALUES('" + currentDateTextBox.Text+"','"+currentTimeTextBox.Text+"','"+dateOfBirthTimePicker.Text+"')";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string connectionString = @"Server=DESKTOP-AAHS936\SQLEXPRESS;Database=DateTimeDB;Integrated Security=true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string commandString = "SELECT * FROM DateTable WHERE DateOfBirth BETWEEN '"+fromBirthDateTimePicker.Text+"' AND '"+toBirthDateTimePicker.Text+"'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            displayDataGridView.DataSource = dataTable;
            sqlConnection.Close();
        }
    }
}

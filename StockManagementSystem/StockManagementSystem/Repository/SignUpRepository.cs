﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystem.Models;
using System.Data;
using System.Data.SqlClient;

namespace StockManagementSystem.Repository
{
    public class SignUpRepository
    {
        string connectionString;
        SqlConnection sqlConnection;
        string commandString;
        SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;
        public SignUpRepository()
        {
            connectionString = @"Server=" + SMSDBScript.ServerName + ";Database=" + SMSDBScript.DatabaseName + ";Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
        }
        public bool IsUserAccountCreated()
        {
            int isExecuted = 0;
            commandString = @"INSERT INTO UserAccount VALUES('"+UserAccount.Email+"','"+UserAccount.UserName+"','"+UserAccount.Password+"')";
            sqlCommand = new SqlCommand(commandString,sqlConnection);
            sqlConnection.Open();
            isExecuted = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return isExecuted > 0;

        } 
        public bool IsEmailUsed()
        {
            int isExecuted = 0;
            commandString = @"SELECT * FROM UserAccount WHERE Email='" + UserAccount.Email+ "'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            isExecuted = dataTable.Rows.Count;
            sqlConnection.Close();

            return isExecuted > 0;
        } 
        public bool IsUserNameUsed()
        {
            int isExecuted = 0;
            commandString = @"SELECT * FROM UserAccount WHERE UserName='" + UserAccount.UserName + "'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            isExecuted = dataTable.Rows.Count;
            sqlConnection.Close();

            return isExecuted > 0;
        }
       

    }
}

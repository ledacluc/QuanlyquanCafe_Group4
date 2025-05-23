﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanlyquanCafe_Group4.DAO
{
     public class DataProvider
    {
        private string connectionSTR = "Data Source=LUCLOMLINH45\\SQLEXPRESS;Initial Catalog=Quanlyquancafe;Integrated Security=True;Encrypt=False";
   
        public DataTable ExecuteQuery(string query) 
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
               
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(data);
                connection.Close();
            }
            return data;

        }
    }
}

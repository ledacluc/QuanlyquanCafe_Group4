﻿using System;

namespace QuanlyquanCafe_Group4.DAO
{
	public class AccountDAO
	{

        private static AccountDAO instance;
        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new AccountDAO();
                return instance;
            }
            private set
            {
                instance = value;
            }
        }
        private AccountDAO() { }
        public bool Login(string userName, string passWord)
        {
            string query = "SELECT * FROM Account WHERE UserName = N'" + userName + "' AND PassWord = N'" + passWord + "'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result.Rows.Count > 0;
        }

    }
}
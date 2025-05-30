using System;
namespace QuanlyquanCafe_Group4
{
    public class Account
    {
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public int Type { get; set; }

        public Account(string userName, string displayName, int type)
        {
            this.UserName = userName;
            this.DisplayName = displayName;
            this.Type = type;

        }
    }
}
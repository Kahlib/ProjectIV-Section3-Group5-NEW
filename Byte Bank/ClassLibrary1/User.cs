using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class User
    {
        private int UserID;
        private string UserName;
        private string Password;
        private double AccountBalance;

        public bool ValidateLogin(string username, string password)
        {
            // check if username and password are valid
            return this.UserName == username && this.Password == password;
        }
    }
}

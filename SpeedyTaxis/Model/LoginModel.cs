using System.Data;
using System.Data.SqlClient;
using System;
using SpeedyTaxis.ServiceReference1;

namespace SpeedyTaxis.Controller
{
    internal class LoginModel
    {
        private int UserID = -1;
        private string UserType = "";
        WebService1SoapClient service = new WebService1SoapClient();

        internal int GetUserID()
        {
            return UserID;
        }

        internal string GetUserType()
        {
            return UserType;
        }

        public LoginModel(string username, string password)
        {
            Login(username, password);
        }

        private void Login(string username, string password)
        {
            try
            {
                ArrayOfString array = service.login(username, password);
                this.UserID = int.Parse(array[0].ToString());
                this.UserType = array[1].ToString();
            } catch (Exception)
            {

            }
        }
    }
}
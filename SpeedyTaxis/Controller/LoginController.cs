using SpeedyTaxis.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyTaxis.Controller
{
    class LoginController
    {
        LoginModel model;

        public LoginController(string username, string password)
        {
            model = new LoginModel(username, password);
        }

        public string GetUserType()
        {
            return model.GetUserType();
        }

        public int GetUserID()
        {
            return model.GetUserID();
        }
    }
}

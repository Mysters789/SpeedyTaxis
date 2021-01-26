using SpeedyTaxisDriverApp.ServiceReference2;
using System;

namespace SpeedyTaxisDriverApp
{
    internal class Model
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

        public Model(string username, string password)
        {
            Login(username, password);
        }

        internal string AddLog(decimal StartWork, decimal EndWork, decimal StartJourney, decimal EndJourney)
        {
           return service.AddLog(UserID, StartWork, EndWork, StartJourney, EndJourney);
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
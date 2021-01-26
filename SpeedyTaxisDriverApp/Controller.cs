
using System;

namespace SpeedyTaxisDriverApp
{
    public class Controller
    {
        Model model;

        public Controller(string username, string password)
        {
            model = new Model(username, password);
        }

        public string GetUserType()
        {
            return model.GetUserType();
        }

        public int GetUserID()
        {
            return model.GetUserID();
        }

        internal string AddLog(decimal StartWork, decimal EndWork, decimal StartJourney, decimal EndJourney)
        {
            return model.AddLog(StartWork, EndWork, StartJourney, EndJourney);
        }
    }
}

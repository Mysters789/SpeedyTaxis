using System;

namespace SpeedyTaxis.Model
{
    public class Log
    {
        protected int LogID { get; set; }
        protected decimal StartWorking { get; set; }
        protected decimal EndWorking { get; set; }
        protected decimal StartJourney { get; set; }
        protected decimal EndJourney { get; set; }
        protected DateTime date { get; set; }

        public Log(int LogID, decimal StartWorking, decimal EndWorking, decimal StartJourney, decimal EndJourney, DateTime date)
        {
            this.LogID = LogID;
            this.StartWorking = StartWorking;
            this.EndWorking = EndWorking;
            this.StartJourney = StartJourney;
            this.EndJourney = EndJourney;
            this.date = date;
        }

        public int GetID()
        {
            return LogID;
        }

        public decimal GetStartWorking()
        {
            return StartWorking;
        }

        public decimal GetEndWorking()
        {
            return EndWorking;
        }

        public decimal GetStartJourney()
        {
            return StartJourney;
        }

        public decimal GetEndJourney()
        {
            return EndJourney;
        }

        public DateTime GetDate()
        {
            return date;
        }
    }
}

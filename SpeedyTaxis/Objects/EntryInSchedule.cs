using System;
using System.Data;
using System.Data.SqlClient;

namespace SpeedyTaxis.Model
{
   public class EntryInSchedule
    {
        protected int ScheduleID { get; set; }
        protected string Name { get; set; }
        protected DateTime Time { get; set; }
        protected string Outcome = null;

        public EntryInSchedule(int ScheduleID, string Name, DateTime Time, string Outcome)
        {
            this.ScheduleID = ScheduleID;
            this.Name = Name;
            this.Time = Time;
            this.Outcome = Outcome;
        }

        public void UpdateOutcome(String outcome)
        {
            Outcome = outcome;
        }

        public int GetScheduleID()
        {
            return ScheduleID;
        }

        public string GetTrainingName()
        {
            return Name;
        }

        public DateTime GetTime()
        {
            return Time;
        }
    }
}

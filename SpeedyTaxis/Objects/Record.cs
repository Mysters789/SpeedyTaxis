using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyTaxis.Model
{
    public class Record
    {
        protected int DRID { get; set; }
        protected string Incident { get; set; }

        public Record(int DRID, string Incident)
        {
            this.DRID = DRID;
            this.Incident = Incident;
        }

        public void SetIncident(int DRID, string incident)
        {
            this.DRID = DRID;
            Incident = incident;
        }

        public int GetRecordID()
        {
            return DRID;
        }

        public string GetRecord()
        {
            return Incident;
        }

        internal void SetIncident(string record)
        {
            Incident = record;
        }
    }
}

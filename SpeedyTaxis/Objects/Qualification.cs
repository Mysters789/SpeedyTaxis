using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyTaxis.Model
{
    public class Qualification
    {
        protected int QualificationID { get; set; }
        protected string QualificationName { get; set; }
        protected DateTime ValidUntil { get; set; }

        public Qualification(int QualificationID, string QualificationName, DateTime ValidUntil)
        {
            this.QualificationID = QualificationID;
            this.QualificationName = QualificationName;
            this.ValidUntil = ValidUntil;
        }

        public int GetQualificationID()
        {
            return QualificationID;
        }

        public string GetQualificationName()
        {
            return QualificationName;
        }

        public DateTime GetValidTime()
        {
            return ValidUntil;
        }

        internal void SetQualification(string qualification)
        {
            QualificationName = qualification;
        }

        internal void SetValidUntil(DateTime dateTime)
        {
            ValidUntil = dateTime;
        }
    }
}

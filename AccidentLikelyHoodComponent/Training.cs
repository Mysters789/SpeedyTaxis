using System;
using System.Data;
using System.Data.SqlClient;

namespace AccidentLikelyHoodComponent
{
    public class Training
    {
        protected int UserTrainingTypeID { get; set; }
        protected string Name { get; set; }
        protected DateTime ValidUntil { get; set; }

        public Training(int UserTrainingTypeID, string name, DateTime ValidUntil)
        {
            Name = name;
            this.UserTrainingTypeID = UserTrainingTypeID;
            this.ValidUntil = ValidUntil;
        }

        public int GetUserTrainingTypeID()
        {
            return UserTrainingTypeID;
        }

        public DateTime GetValidUntil()
        {
            return ValidUntil;
        }

        public string GetTrainingName()
        {
            return Name;
        }

        internal void SetTraining(string training)
        {
            Name = training;
        }

        internal void SetValidUntil(DateTime dateTime)
        {
            ValidUntil = dateTime;
        }
    }
}

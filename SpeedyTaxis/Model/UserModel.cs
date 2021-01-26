using SpeedyTaxis.ServiceReference1;
using System;
using System.Collections.Generic;

namespace SpeedyTaxis.Model
{
    public class UserModel
    {
        private int UserID;
        private string UserType;
        private string Username;
        private long PhoneNumber;
        public List<Log> Logs = new List<Log>();
        public List<Qualification> HeldQualification = new List<Qualification>();
        public List<Record> DisciplinaryRecord = new List<Record>();
        public List<Training> TrainingCompleted = new List<Training>();
        public List<EntryInSchedule> Schedule = new List<EntryInSchedule>();
        WebService1SoapClient service = new WebService1SoapClient();

        internal int GetUserID()
        {
            return UserID;
        }

        internal string GetUserType()
        {
            return UserType;
        }

        internal string GetUsername()
        {
            return Username;
        }

        internal long GetPhoneNumber()
        {
            return PhoneNumber;
        }

        internal bool SetUser(string Username)
        {
            try
            {
                Logs = new List<Log>();
                HeldQualification = new List<Qualification>();
                DisciplinaryRecord = new List<Record>();
                TrainingCompleted = new List<Training>();
                Schedule = new List<EntryInSchedule>();

                ArrayOfString User = service.GetUser(Username);
                UserID = int.Parse(User[0].ToString());
                Username = User[1].ToString();
                UserType = User[2].ToString();
                PhoneNumber = long.Parse(User[3].ToString());
                ArrayOfAnyType[] DwnldLgs = service.getAllLogs(UserID);
                ArrayOfAnyType[] dwnldqal = service.getAllQualifications(UserID);
                ArrayOfAnyType[] dwnlddr = service.getAllDR(UserID);
                ArrayOfAnyType[] dwnldtr = service.getAllTraining(UserID);
                ArrayOfAnyType[] dwnldscedule = service.getAllSchedule(UserID);

                for (int i = 0; i < DwnldLgs.Length; i++)
                {
                    ArrayOfAnyType Q = DwnldLgs[i];
                    Logs.Add(new Log(int.Parse(Q[0].ToString()), decimal.Parse(Q[1].ToString()), decimal.Parse(Q[2].ToString()), decimal.Parse(Q[3].ToString()), decimal.Parse(Q[4].ToString()), DateTime.Parse(Q[5].ToString())));
                }
                for (int i = 0; i < dwnldqal.Length; i++)
                {
                    ArrayOfAnyType Q = dwnldqal[i];
                    HeldQualification.Add(new Qualification(int.Parse(Q[0].ToString()), Q[1].ToString(), DateTime.Parse(Q[2].ToString())));
                }
                for (int i = 0; i < dwnlddr.Length; i++)
                {
                    ArrayOfAnyType Q = dwnlddr[i];
                    DisciplinaryRecord.Add(new Record(int.Parse(Q[0].ToString()), Q[1].ToString()));
                }
                for (int i = 0; i < dwnldtr.Length; i++)
                {
                    ArrayOfAnyType Q = dwnldtr[i];
                    TrainingCompleted.Add(new Training(int.Parse(Q[0].ToString()), Q[1].ToString(), DateTime.Parse(Q[2].ToString())));
                }
                for (int i = 0; i < dwnldscedule.Length; i++)
                {
                    ArrayOfAnyType Q = dwnldscedule[i];
                    Schedule.Add(new EntryInSchedule(int.Parse(Q[0].ToString()), Q[1].ToString(), DateTime.Parse(Q[2].ToString()), Q[3].ToString()));
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal void DeleteQualification(int UserQualificationID)
        {
            for (int i = 0; i < HeldQualification.Count; i++)
            {
                Qualification EachQualification = HeldQualification[i];
                if (EachQualification.GetQualificationID() == UserQualificationID)
                {
                    HeldQualification.Remove(EachQualification);
                    break;
                }
            }
            service.DeleteQualification(UserQualificationID);
        }

        internal void DeleteRecord(int DisciplinaryRecordID)
        {
            for (int i = 0; i < DisciplinaryRecord.Count; i++)
            {
                Record EachRecord = DisciplinaryRecord[i];
                if (EachRecord.GetRecordID() == DisciplinaryRecordID)
                {
                    DisciplinaryRecord.Remove(EachRecord);
                    break;
                }
            }
            service.DeleteRecord(DisciplinaryRecordID);

        }

        internal void DeleteTraining(int UserTrainingTypeID)
        {
            for (int i = 0; i < TrainingCompleted.Count; i++)
            {
                Training EachTraining = TrainingCompleted[i];
                if (EachTraining.GetUserTrainingTypeID() == UserTrainingTypeID)
                {
                    TrainingCompleted.Remove(EachTraining);
                    break;
                }
            }
            service.DeleteTraining(UserTrainingTypeID);

        }

        internal int GetHoursWorkedInTheLastSevenDays()
        {
            return service.GetHoursWorkedThisWeek(UserID);
        }

        internal int GetHoursWorkedInTheCurrentDay()
        {
            return service.GetHoursWorkedToday(UserID);
        }

        internal void EditQualification(int UserQualificationID, string qualification, string validuntil)
        {
            for (int i = 0; i < HeldQualification.Count; i++)
            {
                Qualification Entry = HeldQualification[i];
                if (Entry.GetQualificationID() == UserQualificationID)
                {
                    Entry.SetQualification(qualification);
                    Entry.SetValidUntil(DateTime.Parse(validuntil));
                    break;
                }
            }
            service.EditQualification(UserQualificationID, qualification, validuntil);
        }

        internal bool AddToSchedule(string training, string date)
        {
            try
            {
                int ScheduleID = service.AddToSchedule(training, UserID, date, "");
                Schedule.Add(new EntryInSchedule(ScheduleID, training, DateTime.Parse(date), ""));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal void EditTraining(int UserTrainingTypeID, string training, string validuntil)
        {
            for (int i = 0; i < TrainingCompleted.Count; i++)
            {
                Training Entry = TrainingCompleted[i];
                if (Entry.GetUserTrainingTypeID() == UserTrainingTypeID)
                {
                    Entry.SetTraining(training);
                    Entry.SetValidUntil(DateTime.Parse(validuntil));
                    break;
                }
            }
            service.EditTraining(UserTrainingTypeID, training, validuntil);
        }

        internal void EditRecord(int v, string record)
        {
            for (int i = 0; i < DisciplinaryRecord.Count; i++)
            {
                Record Entry = DisciplinaryRecord[i];
                if (Entry.GetRecordID() == v)
                {
                    Entry.SetIncident(record);
                    break;
                }
            }
            service.EditRecord(v, record);
        }

        internal List<string> GetAllUsers()
        {
            List<string> p = new List<string>();
            ArrayOfString q = service.GetAllUsers();
            for (int i = 0; i < q.Count; i++)
            {
                p.Add(q[i].ToString());
            }
            return p;
        }

        internal List<object[]> GetExpiredFromEveryone()
        {
            List<object[]> newnew = new List<object[]>();
            ArrayOfString[] oldold = service.GetExpiredFromEveryone();
            for (int i = 0; i < oldold.Length; i++)
            {
                ArrayOfString oldoldold = oldold[i];
                string[] newnewnew = new string[4];
                newnewnew[0] = oldoldold[0].ToString();
                newnewnew[1] = oldoldold[1].ToString();
                newnewnew[2] = oldoldold[2].ToString();
                newnewnew[3] = oldoldold[3].ToString();
                newnew.Add(newnewnew);
            }
            return newnew;
        }

        internal bool DeleteDriver()
        {
            try
            {
                service.DeleteDriver(UserID);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal void AddTraining(string training, string validUntil)
        {
            int UserTrainingTypeID = service.AddTraining(UserID, training, validUntil);
            TrainingCompleted.Add(new Training(UserTrainingTypeID, training, DateTime.Parse(validUntil)));
        }

        internal bool AddRecord(string newRecord)
        {
            try
            {
                int DRID = service.AddRecord(UserID, newRecord);
                DisciplinaryRecord.Add(new Record(DRID, newRecord));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal void AddQualification(string qualification, string validUntil)
        {
            int QualificationID = service.AddQualification(UserID, qualification, validUntil);
            HeldQualification.Add(new Qualification(QualificationID, qualification, DateTime.Parse(validUntil)));
        }

        internal bool AddUser(string username, string password, string usertype, long phonenumber)
        {
            try
            {
                service.AddUser(username, password, usertype, phonenumber);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal void SetUserType(string UserType)
        {
            this.UserType = UserType;
            service.SetUserType(UserID, UserType);
        }

        internal bool SetUsername(string Username)
        {
            try
            {
                this.Username = Username;
                service.SetUsername(UserID, Username);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal bool SetPhoneNumber(long ph)
        {
            try
            {
                this.PhoneNumber = ph;
                service.SetPhoneNumber(UserID, ph);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal bool SetOutcome(int ScheduleID, string message)
        {
            try
            {
                //Update the outcome in the schedule object
                for (int i = 0; i < Schedule.Count; i++)
                {
                    EntryInSchedule Entry = Schedule[i];
                    if (Entry.GetScheduleID() == ScheduleID)
                    {
                        Entry.UpdateOutcome(message);
                        break;
                    }
                }
                service.SetOutcome(ScheduleID, message);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

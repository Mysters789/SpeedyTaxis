using SpeedyTaxis.Model;
using System;
using System.Collections.Generic;

namespace SpeedyTaxis.Controller
{
    public class UserController
    {
        UserModel model = new UserModel();

        public UserController(string username)
        {
            SetUser(username);
        }

        internal int UserID => model.GetUserID();

        internal bool SetUser(string username)
        {
            if (model.SetUser(username))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal string UserType => model.GetUserType();

        internal List<Log> AllLogsFromUser => model.Logs;

        internal List<Qualification> AllQualificationsFromUser => model.HeldQualification;

        internal List<EntryInSchedule> AllScheduledEvents => model.Schedule;

        internal List<Record> DisiplinaryRecord => model.DisciplinaryRecord;

        internal List<Training> PreviousTraining => model.TrainingCompleted;

        internal bool AddUser(string username, string password, string usertype, long phonenumber)
        {
            if (model.AddUser(username, password, usertype, phonenumber))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal bool SetOutcome(int ScheduleID, string outcome)
        {
            if (model.SetOutcome(ScheduleID, outcome))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal bool EditDriverUsername(string newUsername)
        {
            if (model.SetUsername(newUsername))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal bool EditDriverPhoneNumber(long phonenumber)
        {
            if (model.SetPhoneNumber(phonenumber))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal void AddQualification(string qualification, string validUntil)
        {
            model.AddQualification(qualification, validUntil);
        }

        internal bool AddRecord(string newRecord)
        {
            if (model.AddRecord(newRecord))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal void AddTraining(string training, string validUntil)
        {
            model.AddTraining(training, validUntil);
        }

        internal bool DeleteDriver()
        {
            if (model.DeleteDriver())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal string GetPhoneNumber() => model.GetPhoneNumber().ToString();

        internal void DeleteQualification(int qualificationID)
        {
            model.DeleteQualification(qualificationID);
        }

        internal void DeleteRecord(int RecordID)
        {
            model.DeleteRecord(RecordID);
        }

        internal void DeleteTraining(int TrainingTypeID)
        {
            model.DeleteTraining(TrainingTypeID);
        }

        internal bool EditQualification(int ID, string qualification, string validuntil)
        {
            try
            {
                model.EditQualification(ID, qualification, validuntil);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal bool EditRecord(int v, string record)
        {
            try
            {
                model.EditRecord(v, record);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal bool EditTraining(int usertrainingtypeid, string training, string validuntil)
        {
            try
            {
                model.EditTraining(usertrainingtypeid, training, validuntil);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal List<String> GetAllUsers()
        {
            return model.GetAllUsers();
        }

        internal List<Object[]> GetExpiredFromEveryone()
        {
            return model.GetExpiredFromEveryone();
        }

        internal bool AddToSchedule(string training, string date)
        {
            if (model.AddToSchedule(training, date)) {
                return true;
            } else
            {
                return false;
            }
        }

        internal int GetHoursWorkedInTheCurrentDay() => model.GetHoursWorkedInTheCurrentDay();

        internal int GetHoursWorkedInTheLastSevenDays() => model.GetHoursWorkedInTheLastSevenDays();
    }
}

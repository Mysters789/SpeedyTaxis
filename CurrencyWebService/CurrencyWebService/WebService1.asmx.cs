using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

namespace CurrencyWebService
{
    [WebService(Namespace = "http://stuiis.cms.gre.ac.uk/ms2721o/currencyservice")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class WebService1 : WebService
    {

        [WebMethod]
        public int AddToSchedule(string training, int userID, string date, string outcome)
        {
            SqlConnection sqlConnection1 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"); //request a new SQL connection
            SqlCommand command = new SqlCommand("INSERT INTO \"Schedule\" VALUES ('" + training + "'," + userID + ",'" + date + "','" + outcome + "')", sqlConnection1);
            sqlConnection1.Open();
            command.ExecuteNonQuery();
            sqlConnection1.Close();

            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = "SELECT ScheduleID FROM \"Schedule\" WHERE UserID = " + userID + " AND Time = '" + date + "'", //This will only be 1 result
                Connection = sqlConnection1
            };
            sqlConnection1.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            int ScheduleID = -1;
            if (reader.Read())
            {
                ScheduleID = int.Parse(reader["ScheduleID"].ToString());
            }
            sqlConnection1.Close();
            return ScheduleID;
        }

        [WebMethod]
        public string[] login(string username, string password)
        {
            SqlConnection sqlConnection1 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"); //request a new SQL connection
            String[] array = new String[2];
            array[0] = "-1";
            array[1] = "none";
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = "SELECT UserID,UserType,PhoneNumber FROM \"User\" WHERE Username = '" + username + "' AND Password = '" + password + "'", //This will only be 1 result
                Connection = sqlConnection1
            };
            sqlConnection1.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                array[0] = reader["UserID"].ToString();
                array[1] = reader["UserType"].ToString();
            }
            sqlConnection1.Close();
            return array;
        }

        [WebMethod]
        public object[][] getAllLogs(int UserID)
        {
            SqlConnection sqlConnection1 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"); //request a new SQL connection
            List<object> Logs = new List<object>();
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = "SELECT * FROM \"Log\" WHERE UserID = " + UserID, //This will only be 1 result
                Connection = sqlConnection1
            };
            sqlConnection1.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                List<object> LoggedEntry = new List<object>();
                int LogID = int.Parse(reader["LogID"].ToString());
                Decimal StartWorking = Decimal.Parse(reader["StartWorking"].ToString());
                Decimal EndWorking = Decimal.Parse(reader["EndWorking"].ToString());
                Decimal StartJourney = Decimal.Parse(reader["StartJourney"].ToString());
                Decimal EndJourney = Decimal.Parse(reader["EndJourney"].ToString());
                DateTime Date = DateTime.Parse(reader["Date"].ToString());
                LoggedEntry.Add(LogID);
                LoggedEntry.Add(StartWorking);
                LoggedEntry.Add(EndWorking);
                LoggedEntry.Add(StartJourney);
                LoggedEntry.Add(EndJourney);
                LoggedEntry.Add(Date);
                Logs.Add(LoggedEntry);
            }
            sqlConnection1.Close();

            string[,] LogsArray = new string[Logs.Count, 6];
            for (int i = 0; i < Logs.Count; i++)
            {
                LogsArray[i, 0] = ((List<object>)(Logs[i]))[0].ToString();
                LogsArray[i, 1] = ((List<object>)(Logs[i]))[1].ToString();
                LogsArray[i, 2] = ((List<object>)(Logs[i]))[2].ToString();
                LogsArray[i, 3] = ((List<object>)(Logs[i]))[3].ToString();
                LogsArray[i, 4] = ((List<object>)(Logs[i]))[4].ToString();
                LogsArray[i, 5] = ((List<object>)(Logs[i]))[5].ToString();
            }

            return ConvertToJaggedArray(LogsArray);
        }

        [WebMethod]
        public object[][] getAllQualifications(int UserID)
        {
            SqlConnection sqlConnection1 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"); //request a new SQL connection
            List<object> Qualifications = new List<object>();
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = "SELECT * FROM \"UserQualification\" WHERE UserID = " + UserID, //This will only be 1 result
                Connection = sqlConnection1
            }; sqlConnection1.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                List<Object> qualification = new List<Object>();
                qualification.Add(int.Parse(reader["UserQualificationID"].ToString()));
                qualification.Add(reader["Name"].ToString());
                qualification.Add(DateTime.Parse(reader["ValidUntil"].ToString()));
                Qualifications.Add(qualification);
            }
            sqlConnection1.Close();

            string[,] QualificationsArray = new string[Qualifications.Count, 3];
            for (int i = 0; i < Qualifications.Count; i++)
            {
                QualificationsArray[i, 0] = ((List<object>)(Qualifications[i]))[0].ToString();
                QualificationsArray[i, 1] = ((List<object>)(Qualifications[i]))[1].ToString();
                QualificationsArray[i, 2] = ((List<object>)(Qualifications[i]))[2].ToString();
            }

            return ConvertToJaggedArray(QualificationsArray);
        }

        [WebMethod]
        public object[][] getAllDR(int UserID)
        {
            SqlConnection sqlConnection1 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"); //request a new SQL connection
            List<object> DR = new List<object>();
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = "SELECT * FROM \"DisciplinaryRecord\" WHERE UserID = " + UserID, //This will only be 1 result
                Connection = sqlConnection1
            }; sqlConnection1.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                List<Object> Record = new List<Object>();
                Record.Add(int.Parse(reader["DisciplinaryRecordID"].ToString()));
                Record.Add(reader["Incident"].ToString());
                DR.Add(Record);
            }
            sqlConnection1.Close();

            string[,] DRArray = new string[DR.Count, 2];
            for (int i = 0; i < DR.Count; i++)
            {
                DRArray[i, 0] = ((List<object>)(DR[i]))[0].ToString();
                DRArray[i, 1] = ((List<object>)(DR[i]))[1].ToString();
            }

            return ConvertToJaggedArray(DRArray);
        }

        [WebMethod]
        public object[][] getAllTraining(int UserID)
        {
            SqlConnection sqlConnection1 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"); //request a new SQL connection

            List<object> TT = new List<object>();
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = "SELECT * FROM \"UserTrainingType\" WHERE UserID = " + UserID, //This will only be 1 result
                Connection = sqlConnection1
            }; sqlConnection1.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                List<Object> Training = new List<Object>
                    {
                        int.Parse(reader["UserTrainingTypeID"].ToString()),
                        reader["Name"].ToString(),
                        DateTime.Parse(reader["ValidUntil"].ToString())
                    };
                TT.Add(Training);
            }
            sqlConnection1.Close();

            string[,] TTArray = new string[TT.Count, 3];
            for (int i = 0; i < TT.Count; i++)
            {
                TTArray[i, 0] = ((List<object>)(TT[i]))[0].ToString();
                TTArray[i, 1] = ((List<object>)(TT[i]))[1].ToString();
                TTArray[i, 2] = ((List<object>)(TT[i]))[2].ToString();
            }

            return ConvertToJaggedArray(TTArray);

        }

        [WebMethod]
        public object[][] getAllSchedule(int UserID)
        {
            SqlConnection sqlConnection1 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"); //request a new SQL connection
            List<List<Object>> Schedule = new List<List<Object>>();
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = "SELECT * FROM \"Schedule\" WHERE UserID = " + UserID, //This will only be 1 result
                Connection = sqlConnection1
            }; sqlConnection1.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                List<Object> EntryInSchedule = new List<Object>();
                EntryInSchedule.Add(int.Parse(reader["ScheduleID"].ToString()));
                EntryInSchedule.Add(reader["Name"].ToString());
                EntryInSchedule.Add(DateTime.Parse(reader["Time"].ToString()));
                EntryInSchedule.Add(reader["Outcome"].ToString());
                Schedule.Add(EntryInSchedule);
            }
            sqlConnection1.Close();

            string[,] ScheduleArray = new string[Schedule.Count, 4];
            for (int i = 0; i < Schedule.Count; i++)
            {
                ScheduleArray[i, 0] = Schedule[i][0].ToString();
                ScheduleArray[i, 1] = Schedule[i][1].ToString();
                ScheduleArray[i, 2] = Schedule[i][2].ToString();
                ScheduleArray[i, 3] = Schedule[i][3].ToString();
            }

            return ConvertToJaggedArray(ScheduleArray);
        }

        [WebMethod]
        public string[] GetUser(string Username)
        {
            SqlConnection sqlConnection1 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"); //request a new SQL connection
            try
            {
                string[] Person = new string[4];
                SqlCommand cmd = new SqlCommand
                {
                    CommandType = CommandType.Text,
                    CommandText = "SELECT UserID,UserType,PhoneNumber FROM \"User\" WHERE Username = '" + Username + "'", //This will only be 1 result
                    Connection = sqlConnection1
                };
                sqlConnection1.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Person[0] = reader["UserID"].ToString();
                    Person[1] = Username;
                    Person[2] = reader["UserType"].ToString();
                    Person[3] = reader["PhoneNumber"].ToString();
                }
                sqlConnection1.Close();
                return Person;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static T[][] ConvertToJaggedArray<T>(T[,] multiArray)
        {
            int numOfColumns = multiArray.GetLength(0);
            int numOfRows = multiArray.GetLength(1);
            T[][] jaggedArray = new T[numOfColumns][];

            for (int c = 0; c < numOfColumns; c++)
            {
                jaggedArray[c] = new T[numOfRows];
                for (int r = 0; r < numOfRows; r++)
                {
                    jaggedArray[c][r] = multiArray[c, r];
                }
            }

            return jaggedArray;
        }

        [WebMethod]
        public void DeleteTraining(int UsertrainingTypeID)
        {
            SqlConnection sqlConnection1 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"); //request a new SQL connection
            SqlCommand command = new SqlCommand("DELETE FROM \"UserTrainingType\" WHERE UserTrainingTypeID = " + UsertrainingTypeID, sqlConnection1);
            sqlConnection1.Open();
            command.ExecuteNonQuery();
            sqlConnection1.Close();
        }

        [WebMethod]
        public void DeleteRecord(int DPID)
        {
            SqlConnection sqlConnection1 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"); //request a new SQL connection
            SqlCommand command = new SqlCommand("DELETE FROM \"DisciplinaryRecord\" WHERE DisciplinaryRecordID = " + DPID, sqlConnection1);
            sqlConnection1.Open();
            command.ExecuteNonQuery();
            sqlConnection1.Close();
        }

        [WebMethod]
        public void DeleteQualification(int UQID)
        {
            SqlConnection sqlConnection1 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"); //request a new SQL connection
            SqlCommand command = new SqlCommand("DELETE FROM \"UserQualification\" WHERE UserQualificationID = " + UQID, sqlConnection1);
            sqlConnection1.Open();
            command.ExecuteNonQuery();
            sqlConnection1.Close();
        }

        [WebMethod]
        public bool DeleteDriver(int UserID)
        {
            try
            {
                SqlConnection sqlConnection1 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"); //request a new SQL connection
                SqlCommand command = new SqlCommand("DELETE FROM \"User\" WHERE UserID = " + UserID, sqlConnection1);
                sqlConnection1.Open();
                command.ExecuteNonQuery();
                sqlConnection1.Close();

                command = new SqlCommand("DELETE FROM \"Log\" WHERE UserID = " + UserID, sqlConnection1);
                sqlConnection1.Open();
                command.ExecuteNonQuery();
                sqlConnection1.Close();

                command = new SqlCommand("DELETE FROM \"UserQualification\" WHERE UserID = " + UserID, sqlConnection1);
                sqlConnection1.Open();
                command.ExecuteNonQuery();
                sqlConnection1.Close();

                command = new SqlCommand("DELETE FROM \"DisciplinaryRecord\" WHERE UserID = " + UserID, sqlConnection1);
                sqlConnection1.Open();
                command.ExecuteNonQuery();
                sqlConnection1.Close();

                command = new SqlCommand("DELETE FROM \"UserTrainingType\" WHERE UserID = " + UserID, sqlConnection1);
                sqlConnection1.Open();
                command.ExecuteNonQuery();
                sqlConnection1.Close();

                command = new SqlCommand("DELETE FROM \"Schedule\" WHERE UserID = " + UserID, sqlConnection1);
                sqlConnection1.Open();
                command.ExecuteNonQuery();
                sqlConnection1.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [WebMethod]
        public int AddTraining(int userID, string training, string validUntil)
        {
            SqlConnection sqlConnection1 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"); //request a new SQL connection
            SqlCommand command = new SqlCommand("INSERT INTO \"UserTrainingType\" VALUES (" + userID + ",'" + training + "','" + validUntil + "')", sqlConnection1);
            sqlConnection1.Open();
            command.ExecuteNonQuery();
            sqlConnection1.Close();

            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = "SELECT UserTrainingTypeID FROM \"UserTrainingType\" WHERE UserID = " + userID + " AND Name = '" + training + "' AND ValidUntil = '" + validUntil + "'", //This will only be 1 result
                Connection = sqlConnection1
            };
            sqlConnection1.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            int TrainingID = -1;
            if (reader.Read())
            {
                TrainingID = int.Parse(reader["UserTrainingTypeID"].ToString());
            }
            sqlConnection1.Close();
            return TrainingID;
        }

        [WebMethod]
        public int AddRecord(int userID, string newRecord)
        {

            SqlConnection sqlConnection1 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"); //request a new SQL connection
            SqlCommand command = new SqlCommand("INSERT INTO \"DisciplinaryRecord\" VALUES (" + userID + ",'" + newRecord + "')", sqlConnection1);
            sqlConnection1.Open();
            command.ExecuteNonQuery();
            sqlConnection1.Close();

            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = "SELECT DisciplinaryRecordID FROM \"DisciplinaryRecord\" WHERE Incident = '" + newRecord + "'", //This will only be 1 result
                Connection = sqlConnection1
            };
            sqlConnection1.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            int DisciplinaryRecordID = -1;
            if (reader.Read())
            {
                DisciplinaryRecordID = int.Parse(reader["DisciplinaryRecordID"].ToString());
            }
            sqlConnection1.Close();
            return DisciplinaryRecordID;
        }

        [WebMethod]
        public int AddQualification(int userID, string qualification, string validUntil)
        {
            SqlConnection sqlConnection1 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"); //request a new SQL connection
            SqlCommand command = new SqlCommand("INSERT INTO \"UserQualification\" VALUES (" + userID + ",'" + qualification + "','" + validUntil + "')", sqlConnection1);
            sqlConnection1.Open();
            command.ExecuteNonQuery();
            sqlConnection1.Close();

            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = "SELECT UserQualificationID FROM \"UserQualification\" WHERE UserID = " + userID + " AND Name = '" + qualification + "' AND ValidUntil = '" + validUntil + "'", //This will only be 1 result
                Connection = sqlConnection1
            };
            sqlConnection1.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            int UserQualificationID = -1;
            if (reader.Read())
            {
                UserQualificationID = int.Parse(reader["UserQualificationID"].ToString());
            }
            sqlConnection1.Close();
            return UserQualificationID;
        }

        [WebMethod]
        public string AddLog(int userID, decimal startwork, decimal endwork, decimal startjourney, decimal endjourney)
        {
            bool CorrectWorkHours = startwork < endwork;//Check if Start hours < end hours
            bool CorrectJourneyHours = startjourney < endjourney;//check if start journey < end journey
            bool CorrectProportions = (endjourney - startjourney) < (endwork - startwork);//check if (end journey - start journey) < (end work < start work)
            string responce = "";
            if (CorrectWorkHours && CorrectJourneyHours && CorrectProportions)
            {
                DateTime Time = DateTime.Now;
                SqlConnection sqlConnection1 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"); //request a new SQL connection
                SqlCommand command = new SqlCommand("INSERT INTO \"Log\" VALUES (" + userID + "," + startwork + "," + endwork + "," + startjourney + "," + endjourney + ",'" + Time.ToString("yyyy-MM-dd HH:mm:ss") + "')", sqlConnection1);
                sqlConnection1.Open();
                command.ExecuteNonQuery();
                sqlConnection1.Close();

                SqlCommand cmd = new SqlCommand
                {
                    CommandType = CommandType.Text,
                    CommandText = "SELECT LogID FROM \"Log\" WHERE UserID = " + userID + " AND StartWorking = " + startwork + " AND EndWorking = " + endwork + " AND StartJourney = " + startjourney + " AND EndJourney = " + endjourney + " AND Date = '" + Time.ToString("yyyy-MM-dd HH:mm:ss") + "'", //This will only be 1 result
                    Connection = sqlConnection1
                };
                sqlConnection1.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                int LogID = -1;
                if (reader.Read())
                {
                    LogID = int.Parse(reader["LogID"].ToString());
                }
                sqlConnection1.Close();
                responce = "" + LogID;
            }
            else
            {
                if (!CorrectWorkHours)
                {
                    responce += "You cannot end working before you started! \n";
                }
                if (!CorrectJourneyHours)
                {
                    responce += "Your cannot end your journey before you started it! \n";
                }
                if (!CorrectProportions)
                {
                    responce += "You cannot have had a journey that lasted longer then your total work hours! \n";
                }
            }
            return responce;
        }

        [WebMethod]
        public bool AddUser(string username, string password, string usertype, long phonenumber)
        {
            try
            {
                SqlConnection sqlConnection1 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"); //request a new SQL connection
                SqlCommand command = new SqlCommand("INSERT INTO \"User\" VALUES ('" + usertype + "','" + username + "','" + password + "'," + phonenumber + ")", sqlConnection1);
                sqlConnection1.Open();
                command.ExecuteNonQuery();
                sqlConnection1.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [WebMethod]
        public void SetUserType(int userID, string UserType)
        {
            SqlConnection sqlConnection1 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"); //request a new SQL connection
            SqlCommand command = new SqlCommand("UPDATE \"User\" SET UserType = '" + UserType + "' Where UserID = " + userID, sqlConnection1);
            sqlConnection1.Open();
            command.ExecuteNonQuery();
            sqlConnection1.Close();
        }

        [WebMethod]
        public void SetUsername(int userID, string Username)
        {
            SqlConnection sqlConnection1 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"); //request a new SQL connection
            SqlCommand command = new SqlCommand("UPDATE \"User\" SET Username = '" + Username + "' Where UserID = " + userID, sqlConnection1);
            sqlConnection1.Open();
            command.ExecuteNonQuery();
            sqlConnection1.Close();
        }

        [WebMethod]
        public void SetPhoneNumber(int userID, long ph)
        {
            SqlConnection sqlConnection1 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"); //request a new SQL connection
            SqlCommand command = new SqlCommand("UPDATE \"User\" SET PhoneNumber = " + ph + " Where UserID = " + userID, sqlConnection1);
            sqlConnection1.Open();
            command.ExecuteNonQuery();
            sqlConnection1.Close();
        }

        [WebMethod]
        public bool SetOutcome(int ScheduleID, string message)
        {
            try
            {
                SqlConnection sqlConnection1 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"); //request a new SQL connection
                SqlCommand command = new SqlCommand("UPDATE \"Schedule\" SET Outcome = '" + message + "' Where ScheduleID = " + ScheduleID, sqlConnection1);
                sqlConnection1.Open();
                command.ExecuteNonQuery();
                sqlConnection1.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [WebMethod]
        public void EditRecord(int v, string record)
        {
            SqlConnection sqlConnection1 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"); //request a new SQL connection
            SqlCommand command = new SqlCommand("UPDATE \"DisciplinaryRecord\" SET Incident = '" + record + "' Where DisciplinaryRecordID = " + v, sqlConnection1);
            sqlConnection1.Open();
            command.ExecuteNonQuery();
            sqlConnection1.Close();
        }

        [WebMethod]
        public string[] GetAllUsers()
        {
            List<string> Users = new List<string>();
            SqlConnection sqlConnection1 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"); //request a new SQL connection
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = "SELECT Username FROM \"User\"",
                Connection = sqlConnection1
            };
            sqlConnection1.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Users.Add(reader["Username"].ToString());
            }
            sqlConnection1.Close();

            string[] UserArray = new string[Users.Count];
            for (int i = 0; i < Users.Count; i++)
            {
                UserArray[i] = Users[i];
            }
            return UserArray;
        }

        [WebMethod]
        public List<string[]> GetExpiredFromEveryone()
        {
            List<string[]> Expired = new List<string[]>();
            var today = DateTime.Today;
            var month = new DateTime(today.Year, today.Month, 1);
            var first = month.AddMonths(1);
            SqlConnection sqlConnection1 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"); //request a new SQL connection
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = "SELECT * FROM \"UserQualification\" WHERE ValidUntil <= Convert(datetime, '" + first.ToString("yyyy-MM-dd HH:mm:ss") + "')",
                Connection = sqlConnection1
            };
            sqlConnection1.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                String[] array = new String[4];
                array[0] = reader["UserQualificationID"].ToString();
                array[1] = reader["UserID"].ToString();
                array[2] = reader["Name"].ToString();
                array[3] = reader["ValidUntil"].ToString();
                Expired.Add(array);
            }
            sqlConnection1.Close();


            cmd.CommandText = "SELECT * FROM \"UserTrainingType\" WHERE ValidUntil <= Convert(datetime, '" + first.ToString("yyyy-MM-dd HH:mm:ss") + "')";
            sqlConnection1.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                String[] array = new String[4];
                array[0] = reader["UserTrainingTypeID"].ToString();
                array[1] = reader["UserID"].ToString();
                array[2] = reader["Name"].ToString();
                array[3] = reader["ValidUntil"].ToString();
                Expired.Add(array);
            }
            sqlConnection1.Close();

            for (int i = 0; i < Expired.Count; i++)
            {
                string[] Person = new string[4];
                cmd = new SqlCommand
                {
                    CommandType = CommandType.Text,
                    CommandText = "SELECT Username FROM \"User\" WHERE UserID = " + Expired[i][1], //This will only be 1 result
                    Connection = sqlConnection1
                };
                sqlConnection1.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Expired[i][1] = reader["Username"].ToString();
                }
                sqlConnection1.Close();
            }
            return Expired;
        }

        [WebMethod]
        public void EditTraining(int UserTrainingTypeID, string training, string validuntil)
        {
            SqlConnection sqlConnection1 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"); //request a new SQL connection
            SqlCommand command = new SqlCommand("UPDATE \"UserTrainingType\" SET Name = '" + training + "' Where UserTrainingTypeID = " + UserTrainingTypeID, sqlConnection1);
            sqlConnection1.Open();
            command.ExecuteNonQuery();
            sqlConnection1.Close();

            command = new SqlCommand("UPDATE \"UserTrainingType\" SET ValidUntil = '" + validuntil + "' Where UserTrainingTypeID = " + UserTrainingTypeID, sqlConnection1);
            sqlConnection1.Open();
            command.ExecuteNonQuery();
            sqlConnection1.Close();
        }

        [WebMethod]
        public void EditQualification(int UserQualificationID, string training, string validuntil)
        {
            SqlConnection sqlConnection1 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"); //request a new SQL connection
            SqlCommand command = new SqlCommand("UPDATE \"UserQualification\" SET Name = '" + training + "' Where UserQualificationID = " + UserQualificationID, sqlConnection1);
            sqlConnection1.Open();
            command.ExecuteNonQuery();
            sqlConnection1.Close();

            command = new SqlCommand("UPDATE \"UserQualification\" SET ValidUntil = '" + validuntil + "' Where UserQualificationID = " + UserQualificationID, sqlConnection1);
            sqlConnection1.Open();
            command.ExecuteNonQuery();
            sqlConnection1.Close();
        }

       [WebMethod]
       public int GetHoursWorkedToday(int UserID)
        {
            int Total = 0;
            var today = DateTime.Today;
            var first = today.AddDays(-1);
            SqlConnection sqlConnection1 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"); //request a new SQL connection
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = "SELECT * FROM \"Log\" WHERE UserID = " + UserID + " AND Date >= Convert(datetime, '" + first.ToString("yyyy-MM-dd HH:mm:ss") + "')",
                Connection = sqlConnection1
            };
            sqlConnection1.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int StartWorking = int.Parse(reader["StartWorking"].ToString());
                int EndWorking = int.Parse(reader["EndWorking"].ToString());
                Total += (EndWorking - StartWorking);
            }
            sqlConnection1.Close();
            return Total;
        }

        [WebMethod]
        public int GetHoursWorkedThisWeek(int UserID)
        {
            int Total = 0;
            var today = DateTime.Today;
            var first = today.AddDays(-1);
            SqlConnection sqlConnection1 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"); //request a new SQL connection
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = "SELECT * FROM \"Log\" WHERE UserID = " + UserID + " AND Date >= Convert(datetime, '" + first.ToString("yyyy-MM-dd HH:mm:ss") + "')",
                Connection = sqlConnection1
            };
            sqlConnection1.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int StartWorking = int.Parse(reader["StartWorking"].ToString());
                int EndWorking = int.Parse(reader["EndWorking"].ToString());
                Total += (EndWorking - StartWorking);
            }
            sqlConnection1.Close();
            return Total;
        }

    }
}

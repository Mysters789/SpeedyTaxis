using SpeedyTaxis.Controller;
using SpeedyTaxis.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SpeedyTaxis
{
    public partial class AdminPanel : Form
    {
        Login form;
        UserController controller = new UserController("Admin");
        UserController Profile;
        private List<string> AllDrivers;

        public AdminPanel(Login form)
        {
            this.form = form;
            InitializeComponent();
            SelectedUserComboBox.DataSource = controller.GetAllUsers();
        }

        private void Driver_AddDriverButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (Driver_AddUsername.Text.Contains("'"))
                {
                    Driver_DriverAdditionStatus.Text = "Username shouldn't use \"'\"";
                }
                else
                if (Driver_AddUsername.Text == null || Driver_AddPassword.Text == null || Driver_AddPhoneNumber.GetText() == null)
                {
                    Driver_DriverAdditionStatus.Text = "Fill in all the feilds please";
                }
                else if (controller.GetAllUsers().Contains(Driver_AddUsername.Text))
                {
                    Driver_DriverAdditionStatus.Text = "Username already taken, change please";
                }
                else if (controller.AddUser(Driver_AddUsername.Text, Driver_AddPassword.Text, "Driver", long.Parse(Driver_AddPhoneNumber.GetText())))
                {
                    Driver_DriverAdditionStatus.Text = "Driver Added Successfully";
                    SelectedUserComboBox.DataSource = controller.GetAllUsers();
                }
            }
            catch (Exception)
            {
                Driver_DriverAdditionStatus.Text = "Unable to process phone number, sorry";
            }
        }

        private void Driver_EditUsername_TextChanged(object sender, EventArgs e)
        {
            if (Driver_EditUsername.Text == null)
            {
                Driver_EditDriverStatus.Text = "Fill All required feilds please";
            }
            else
                            if (Driver_EditUsername.Text.Contains("'"))
            {
                Driver_EditDriverStatus.Text = "Username shouldn't use \"'\"";
            }
            else
            {
                if (controller.EditDriverUsername(Driver_EditUsername.Text))
                {
                    Driver_EditDriverStatus.Text = "Updated Successfully!";
                }
                else
                {
                    Driver_EditDriverStatus.Text = "Error occured";
                }
            }
        }

        private void Driver_EditPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            if (Driver_EditPhoneNumber.Text == null || Driver_EditPhoneNumber.GetText().Contains("'"))
            {
                Driver_EditDriverStatus.Text = "Fill All required feilds please";
            }
            else if (long.Parse(Driver_EditPhoneNumber.GetText()) < 999999999)
            {
                Driver_EditDriverStatus.Text = "Please make sure the phone number is 11 digits";
            }
            else
            {
                if (controller.EditDriverPhoneNumber(long.Parse(Driver_EditPhoneNumber.GetText())))
                {
                    Driver_EditDriverStatus.Text = "Updated Successfully!";
                }
                else
                {
                    Driver_EditDriverStatus.Text = "Error occured trying to update phone number";
                }
            }
        }

        private void Driver_UpdateButton_Click(object sender, EventArgs e)
        {
            Driver_EditUsername_TextChanged(sender, e);
            Driver_EditPhoneNumber_TextChanged(sender, e);
            SelectedUserComboBox.DataSource = controller.GetAllUsers();
        }

        private void Driver_DeleteDriver_Click(object sender, EventArgs e)
        {
            if (controller.DeleteDriver())
            {
                Driver_EditDriverStatus.Text = "Driver Deleted successfully!";
                SelectedUserComboBox.DataSource = controller.GetAllUsers();
            }
            else
            {
                Driver_EditDriverStatus.Text = "Driver Not Deleted, error occured";
            }
        }

        private void DriverTab_Click(object sender, EventArgs e)
        {
            Driver_EditPhoneNumber.SetText(controller.GetPhoneNumber());
            Driver_EditUsername.Text = SelectedUserComboBox.Text;
        }

        private void SelectedUserComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller = new UserController(SelectedUserComboBox.Text);
            DriverTab_Click(sender, e);
            QualificationTab_Click(sender, e);
            ScheduleTab_Click(sender, e);
            TrainingTab_Click(sender, e);
            DisiplinaryTab_Click(sender, e);
            LogTab_Click(sender, e);
        }

        private void QualificationTab_Click(object sender, EventArgs e)
        {
            Qualifications_ExistingQualificationsTable.Controls.Clear();
            List<Qualification> qualifications = controller.AllQualificationsFromUser;
            for (int x = 0; x < qualifications.Count; x++)
            {
                Qualifications_ExistingQualificationsTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));

                TextBox cmd = new TextBox
                {
                    Text = qualifications[x].GetQualificationName(),
                    Name = "" + qualifications[x].GetQualificationID()
                };
                Qualifications_ExistingQualificationsTable.Controls.Add(cmd, 0, x);

                DateTimePicker cmd2 = new DateTimePicker
                {
                    Text = "" + qualifications[x].GetValidTime(),
                    Name = "" + qualifications[x].GetQualificationID()
                };
                Qualifications_ExistingQualificationsTable.Controls.Add(cmd2, 1, x);

                Button cmd3 = new Button
                {
                    Text = "Update",
                    Name = "" + qualifications[x].GetQualificationID()
                };
                cmd3.Click += new EventHandler(Qualification_EditQualification);
                Qualifications_ExistingQualificationsTable.Controls.Add(cmd3, 2, x);

                Button cmd4 = new Button
                {
                    Text = "Delete",
                    Name = "" + qualifications[x].GetQualificationID()
                };
                cmd4.Click += new EventHandler(Qualification_DeleteQualification);
                Qualifications_ExistingQualificationsTable.Controls.Add(cmd4, 3, x);
            }
        }

        private void Qualification_EditQualification(object sender, EventArgs e)
        {
            int ID = -1;
            string qualification = "";
            string validuntil = "";
            foreach (Control control in groupBox4.Controls)
            {
                if (control is TextBox)
                {
                    if ((control as TextBox).Name == this.Name)
                    {
                        ID = int.Parse(((Control)sender).Name);
                        qualification = (control as TextBox).Text;
                    }
                }
                else if (control is DateTimePicker)
                {
                    if ((control as DateTimePicker).Name == this.Name)
                    {
                        validuntil = (control as DateTimePicker).Text;
                    }
                }
            }
            if (qualification.Contains("'"))
            {
                EditQualificationStatus.Text = "Qualification shouldn't use \"'\"";
            }
            else if (controller == null || validuntil == null)
            {
                EditQualificationStatus.Text = "Fill in all feilds please";
            }
            else
            if (controller.EditQualification(ID, qualification, validuntil))
            {
                EditQualificationStatus.Text = "Qualification successfully updated";
            }
            else
            {
                EditQualificationStatus.Text = "Error occured doing that..";
            }
        }

        private void Qualification_DeleteQualification(object sender, EventArgs e)
        {
            controller.DeleteQualification(int.Parse(((Control)sender).Name));
            QualificationTab_Click(sender, e);
        }

        private void Qualification_AddQualificationButton_Click(object sender, EventArgs e)
        {
            string qualification = Qualification_AddQualification.Text;
            string ValidUntil = Qualification_DateTimePicker.Text;

            if (qualification.Contains("'"))
            {
                EditQualificationStatus.Text = "Qualification shouldn't use \"'\"";
            }
            else if (qualification == null || ValidUntil == null)
            {
                EditQualificationStatus.Text = "Fill in qualification and date first";
            }
            else
            {
                controller.AddQualification(qualification, ValidUntil);
                QualificationTab_Click(sender, e);
            }
        }

        private void TrainingTab_Click(object sender, EventArgs e)
        {
            Training_ExistingTrainingTableLayoutPanel.Controls.Clear();
            List<Training> training = controller.PreviousTraining;
            for (int x = 0; x < training.Count; x++)
            {
                Training_ExistingTrainingTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));

                TextBox cmd = new TextBox
                {
                    Text = training[x].GetTrainingName(),
                    Name = "" + training[x].GetUserTrainingTypeID()
                };
                Training_ExistingTrainingTableLayoutPanel.Controls.Add(cmd, 0, x);

                DateTimePicker cmd2 = new DateTimePicker
                {
                    Text = "" + training[x].GetValidUntil(),
                    Name = "" + training[x].GetUserTrainingTypeID()
                };
                Training_ExistingTrainingTableLayoutPanel.Controls.Add(cmd2, 1, x);

                Button cmd3 = new Button
                {
                    Text = "Update",
                    Name = "" + training[x].GetUserTrainingTypeID()
                };
                cmd3.Click += new EventHandler(Training_EditTraining);
                Training_ExistingTrainingTableLayoutPanel.Controls.Add(cmd3, 2, x);

                Button cmd4 = new Button
                {
                    Text = "Delete",
                    Name = "" + training[x].GetUserTrainingTypeID()
                };
                cmd4.Click += new EventHandler(Training_DeleteTraining);
                Training_ExistingTrainingTableLayoutPanel.Controls.Add(cmd4, 3, x);
            }
        }

        private void Training_EditTraining(object sender, EventArgs e)
        {
            int ID = -1;
            string training = "";
            string validuntil = "";
            foreach (Control control in groupBox7.Controls)
            {
                if (control is TextBox)
                {
                    if ((control as TextBox).Name == this.Name)
                    {
                        ID = int.Parse(((Control)sender).Name);
                        training = (control as TextBox).Text;
                    }
                }
                else if (control is DateTimePicker)
                {
                    if ((control as DateTimePicker).Name == this.Name)
                    {
                        validuntil = (control as DateTimePicker).Text;
                    }
                }
            }

            if (training == null || validuntil == null)
            {
                Training_TrainingEditStatus.Text = "Fill in all requried feilds please";
            }
            if (training.Contains("'"))
            {
                Training_TrainingEditStatus.Text = "Training shouldn't use \"'\"";
            }
            else

            if (controller.EditTraining(ID, training, validuntil))
            {
                Training_TrainingEditStatus.Text = "Training successfully updated";
            }
            else
            {
                Training_TrainingEditStatus.Text = "Error occured doing that..";
            }
        }

        private void Training_DeleteTraining(object sender, EventArgs e)
        {
            controller.DeleteTraining(int.Parse(((Control)sender).Name));
            TrainingTab_Click(sender, e);
        }

        private void Training_AddTrainingButton_Click(object sender, EventArgs e)
        {
            string training = Training_AddNewTraining.Text;
            string ValidUntil = TrainingDateTimePicker.Text;

            if (training.Contains("'"))
            {
                Training_TrainingEditStatus.Text = "Training shouldn't use \"'\"";
            }
            else
if (training == null || ValidUntil == null)
            {
                Training_TrainingEditStatus.Text = "Fill in all requried feilds please";
            }
            else
            {
                controller.AddTraining(training, ValidUntil);
                TrainingTab_Click(sender, e);
            }
        }

        private void SearchTab_Click(object sender, EventArgs e)
        {
            Search_SearchBox.Text = "";
            AllDrivers = controller.GetAllUsers();
        }

        private void Search_SearchBox_TextChanged(object sender, EventArgs e)
        {
            Search_SearchResultsListBox.Items.Clear();
            for (int x = 0; x < AllDrivers.Count; x++)
            {
                if (AllDrivers[x].Contains(Search_SearchBox.Text))
                {
                    Search_SearchResultsListBox.Items.Add(AllDrivers[x]);
                }
            }
        }

        private void Search_SearchResultsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Profile = new UserController(Search_SearchResultsListBox.Text);
            Search_ProfileUsername.Text = Search_SearchResultsListBox.Text;
            Search_ProfileUserType.Text = Profile.UserType;
            Search_ProfilePhoneNumber.Text = "" + Profile.GetPhoneNumber();
            Search_ProfileNoOfQualifications.Text = "" + Profile.AllQualificationsFromUser.Count;
            Search_ProfileNoOfTraining.Text = "" + Profile.PreviousTraining.Count;
            Search_ProfileNoOfScheduledEvents.Text = "" + Profile.AllScheduledEvents.Count;
            Search_ProfileNoOfLoggedHours.Text = "" + Profile.AllLogsFromUser.Count;
            Search_ProfileNoOfEntriesInDisiplinaryRecord.Text = "" + Profile.DisiplinaryRecord.Count;
        }

        private void ExpiredTab_Click(object sender, EventArgs e)
        {
            Expiring_ExpiringTableLayoutTable.Controls.Clear();
            List<object[]> Expired = controller.GetExpiredFromEveryone();
            for (int x = 0; x < Expired.Count; x++)
            {
                Expiring_ExpiringTableLayoutTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
                object[] EachExpiredThingy = Expired[x];
                Label cmd = new Label
                {
                    Text = EachExpiredThingy[1].ToString(),
                };
                Expiring_ExpiringTableLayoutTable.Controls.Add(cmd, 0, x);

                Label cmd2 = new Label
                {
                    Text = EachExpiredThingy[2].ToString(),
                };
                Expiring_ExpiringTableLayoutTable.Controls.Add(cmd2, 1, x);

                Label cmd4 = new Label
                {
                    Text = EachExpiredThingy[3].ToString(),
                };
                Expiring_ExpiringTableLayoutTable.Controls.Add(cmd4, 2, x);
            }
        }

        private void DisiplinaryTab_Click(object sender, EventArgs e)
        {
            Disiplinary_ExistingRecordsTableLayoutPanel.Controls.Clear();
            List<Record> DisplinaryRecord = controller.DisiplinaryRecord;
            for (int x = 0; x < DisplinaryRecord.Count; x++)
            {
                Disiplinary_ExistingRecordsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));

                TextBox cmd = new TextBox
                {
                    Text = DisplinaryRecord[x].GetRecord(),
                    Name = "" + DisplinaryRecord[x].GetRecordID()
                };
                Disiplinary_ExistingRecordsTableLayoutPanel.Controls.Add(cmd, 0, x);

                Button cmd2 = new Button
                {
                    Text = "Update",
                    Name = "" + DisplinaryRecord[x].GetRecordID()
                };
                cmd2.Click += new EventHandler(Disiplinary_EditRecord);
                Disiplinary_ExistingRecordsTableLayoutPanel.Controls.Add(cmd2, 1, x);

                Button cmd3 = new Button
                {
                    Text = "Delete",
                    Name = "" + DisplinaryRecord[x].GetRecordID()
                };
                cmd3.Click += new EventHandler(Disiplinary_DeleteRecord);
                Disiplinary_ExistingRecordsTableLayoutPanel.Controls.Add(cmd3, 2, x);
            }
        }

        private void Disiplinary_EditRecord(object sender, EventArgs e)
        {
            string Record = "";
            foreach (Control control in groupBox17.Controls)
            {
                if (control is TextBox)
                {
                    if ((control as TextBox).Name == this.Name)
                    {
                        Record = (control as TextBox).Text;
                    }
                }
            }
            if (Record == "" || Record.Contains("'"))
            {
                Disiplinary_EditRecordStatus.Text = "Record needs to be filled";
            }
            else if (controller.EditRecord(int.Parse(((Control)sender).Name), Record))
            {
                Disiplinary_EditRecordStatus.Text = "Record successfully updated";
            }
            else
            {
                Disiplinary_EditRecordStatus.Text = "Error occured doing that..";
            }
        }

        private void Disiplinary_DeleteRecord(object sender, EventArgs e)
        {
            controller.DeleteRecord(int.Parse(((Control)sender).Name));
            DisiplinaryTab_Click(sender, e);
        }

        private void Disiplinary_AddRecordButton_Click(object sender, EventArgs e)
        {
            string NewRecord = Disiplinary_NewRecordTextBox.Text;
            if (NewRecord == null)
            {
                Displinary_AddStatusLabel.Text = "Add Record please";
            }
            if (NewRecord.Contains("'"))
            {
                Displinary_AddStatusLabel.Text = "Record shouldn't contain ', please use non abreviated words";
            }
            else
            if (controller.AddRecord(NewRecord))
            {
                DisiplinaryTab_Click(sender, e);
            }
            else
            {
                Displinary_AddStatusLabel.Text = "Error occured, try again";
            }
        }

        private void LogTab_Click(object sender, EventArgs e)
        {
            accidentLikelyHood2.SetHoursWorkedInTheCurrentDay(controller.GetHoursWorkedInTheCurrentDay());
            accidentLikelyHood2.SetHoursWorkedInTheLastSevenDays(controller.GetHoursWorkedInTheLastSevenDays());
            accidentLikelyHood2.SetTrainingCompleted(controller.PreviousTraining.Count);
            accidentLikelyHood2.Algorithm();

            visualComponent1.SetHoursWorkedInTheCurrentDay(controller.GetHoursWorkedInTheCurrentDay());
            visualComponent1.SetHoursWorkedInTheLastSevenDays(controller.GetHoursWorkedInTheLastSevenDays());
            visualComponent1.SetTrainingCompleted(controller.PreviousTraining.Count);
            visualComponent1.Algorithm();
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            form.Close();
        }

        private void AllTabs_TabIndexChanged(object sender, EventArgs e)
        {
            switch (AllTabs.SelectedIndex)
            {
                case 0:
                    DriverTab_Click(sender, e);
                    break;
                case 1:
                    QualificationTab_Click(sender, e);
                    break;
                case 2:
                    ScheduleTab_Click(sender, e);
                    break;
                case 3:
                    TrainingTab_Click(sender, e);
                    break;
                case 4:
                    SearchTab_Click(sender, e);
                    break;
                case 5:
                    ExpiredTab_Click(sender, e);
                    break;
                case 6:
                    DisiplinaryTab_Click(sender, e);
                    break;
                case 7:
                    LogTab_Click(sender, e);
                    break;
            }
        }

        private void ScheduleTab_Click(object sender, EventArgs e)
        {
            Schedule_PastEventsComboBox.Items.Clear();
            List<EntryInSchedule> PastEvents = controller.AllScheduledEvents;
            for (int i = 0; i < PastEvents.Count; i++)
            {
                EntryInSchedule Event = PastEvents[i];
                Schedule_PastEventsComboBox.Items.Add("Training Type : " + Event.GetTrainingName() + " , " + "Training Date : " + Event.GetTime());
            }
        }

        private void Schedule_AddTrainingButton_Click(object sender, EventArgs e)
        {
            string Training = Schedule_AddTrainingTextBox.Text;
            string date = Schedule_AddTimeDatePicker.Text;
            if (Training.Contains("'"))
            {
                Schedule_AddTrainingStatus.Text = "Training Name cannot contain \"'\"";
            }
            else
            if (controller.AddToSchedule(Training, date))
            {
                Schedule_AddTrainingStatus.Text = "Event added successfully!";
            }
            else
            {
                Schedule_AddTrainingStatus.Text = "Error occured adding event";
            }
            ScheduleTab_Click(sender, e);
        }

        private void Schedule_UpdateOutcomeButton_Click(object sender, EventArgs e)
        {
            List<EntryInSchedule> PastEvents = controller.AllScheduledEvents;
            EntryInSchedule Event = PastEvents[Schedule_PastEventsComboBox.SelectedIndex];
            string outcome = Schedule_ScheduleOutcomeTextBox.Text;
            if (controller.SetOutcome(Event.GetScheduleID(), outcome))
            {
                Schedule_UpdateOutcomeStatus.Text = "Outcome updated successfully!";
            }
            else
            {
                Schedule_UpdateOutcomeStatus.Text = "Couldn't update outcome, try again";
            }
        }
    }
}

using System;
using System.Windows.Forms;

namespace SpeedyTaxisDriverApp
{
    public partial class DriverPanel : Form
    {
        public Login form;
        public Controller controller;

        public DriverPanel(Login form, Controller controller)
        {
            InitializeComponent();
            this.form = form;
            this.controller = controller;
        }

        private void Log_StartWorkNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Log_TotalWorkHoursLabel.Text = "" + (Log_EndWorkNumericUpDown.Value - Log_StartWorkNumericUpDown.Value);
        }

        private void Log_EndWorkNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Log_TotalWorkHoursLabel.Text = "" + (Log_EndWorkNumericUpDown.Value - Log_StartWorkNumericUpDown.Value);
        }

        private void Log_StartJourneyNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Log_JourneyDurationLabel.Text = "" + (Log_EndJourneyNumericUpDown.Value - Log_StartJourneyNumericUpDown.Value);
        }

        private void Log_EndJourneyNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Log_JourneyDurationLabel.Text = "" + (Log_EndJourneyNumericUpDown.Value - Log_StartJourneyNumericUpDown.Value);
        }

        private void Log_ProcessLogButton_Click(object sender, EventArgs e)
        {
            string response = controller.AddLog(Log_StartWorkNumericUpDown.Value, Log_EndWorkNumericUpDown.Value, Log_StartJourneyNumericUpDown.Value, Log_EndJourneyNumericUpDown.Value);
            try
            {
                int.Parse(response);
                Log_ProcessStatus.Text = "Successfully added log!";
            }
            catch (Exception)
            {
                Log_ProcessStatus.Text = response;
            }
        }

        private void LogOut_Click(object sender, EventArgs e)
        {
            form.Close();
        }
    }
}

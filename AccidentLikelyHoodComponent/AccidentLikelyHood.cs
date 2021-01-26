using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AccidentLikelyHoodComponent
{
    public partial class AccidentLikelyHood : UserControl
    {
        int HoursWorkedInTheCurrentDay;
        int HoursWorkedInTheLastSevenDays;
        int TrainingCompleted;

        public AccidentLikelyHood()
        {
            InitializeComponent();
        }

        public void Algorithm()
        {
            float Value1 = (float)HoursWorkedInTheCurrentDay / 24;
            float Value2 = (float)HoursWorkedInTheLastSevenDays / 168;
            float top = 100 * Value1 * Value2;
            if (TrainingCompleted <= 0)
            {
                TrainingCompleted = 1;
            }
            int Percentage = (int)(top / TrainingCompleted);
            Result.Text = "";
            Result.Text += "Likelyhood of accident occuring : " + Percentage + " % \n";
            Result.Text += HoursWorkedInTheCurrentDay + " hours worked today : The more work done, the more tired and easy iratated the driver will be \n";
            Result.Text += HoursWorkedInTheLastSevenDays + " hours worked this week : driving on the road for more time means a higher chance of an accident occuring, statistically speaking + \n";
            Result.Text += TrainingCompleted + " Training sessions completed. The more training done, the less likely the driver will have an accident \n";
        }

        public void SetHoursWorkedInTheCurrentDay(int value)
        {
            if (value > 24)
            {
                HoursWorkedInTheCurrentDay = 24;
            }
            else
            {
                HoursWorkedInTheCurrentDay = value;
            }
        }

        public void SetHoursWorkedInTheLastSevenDays(int value)
        {
            if (value > 24)
            {
                HoursWorkedInTheLastSevenDays = 24;
            }
            else
            {
                HoursWorkedInTheLastSevenDays = value;
            }
        }

        public void SetTrainingCompleted(int value)
        {
            TrainingCompleted = value;
        }
    }
}

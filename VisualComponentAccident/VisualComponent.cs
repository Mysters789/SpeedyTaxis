using System.Windows.Forms;

namespace VisualComponentAccident
{
    public partial class VisualComponent : UserControl
    {

        int HoursWorkedInTheCurrentDay;
        int HoursWorkedInTheLastSevenDays;
        int TrainingCompleted;

        public VisualComponent()
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

            chart1.Series.Clear();
            chart1.Series.Add("s1");
            chart1.Series["s1"]["PieLabelStyle"] = "Disabled";
            chart1.Series["s1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            chart1.Series["s1"].Points.AddXY(" ", Percentage);
            chart1.Series["s1"].Points.AddXY(" ", 100 - Percentage);
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

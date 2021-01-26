using SpeedyTaxisDriverApp;
using System;
using System.Windows.Forms;

namespace SpeedyTaxisDriverApp
{
    public partial class Login : Form
    {
        private Controller Controller;
        private DriverPanel UI;

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            Controller = new Controller(UsernameTextBox.Text, PasswordTextBox.Text);
            string userType = Controller.GetUserType();
            if (userType.Equals("Admin") || userType.Equals("Driver"))
            {
                UI = new DriverPanel(this, Controller);
                UI.Show();
                Hide();
            }
            else if (Controller.GetUserID() != -1)
            {
                LoginStatus.Text = "Login Successfull Unknown user type!";
            }
            else
            {
                LoginStatus.Text = "Login Failed :(";
            }
        }
    }
}

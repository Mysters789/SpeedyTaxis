using SpeedyTaxis.Controller;
using System;
using System.Windows.Forms;

namespace SpeedyTaxis
{
    public partial class Login : Form
    {
        private LoginController Controller;
        private AdminPanel UI;

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            Controller = new LoginController(UsernameTextBox.Text, PasswordTextBox.Text);
            string userType = Controller.GetUserType();
            if (userType.Equals("Admin"))
            {
                UI = new AdminPanel(this);
                UI.Show();
                Hide();
            }
            else if (userType.Equals("Driver"))
            {
                LoginStatus.Text = "Login Successfull Driver!";
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

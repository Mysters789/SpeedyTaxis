using System;
using System.Drawing;
using System.Windows.Forms;

namespace PhoneNumberTextBox
{
    public partial class PhoneNumberTextBoxComponent : UserControl
    {
        public PhoneNumberTextBoxComponent()
        {
            InitializeComponent();
        }

        private void MaskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text == null || maskedTextBox1.Text == "")
            {

            } else {
                try
                {
                    if (long.Parse(maskedTextBox1.Text) < 999999999)
                    {
                        maskedTextBox1.ForeColor = Color.Red;
                    }
                    else
                    {
                        maskedTextBox1.ForeColor = Color.Green;
                    }
                } catch (Exception)
                {
                    maskedTextBox1.ForeColor = Color.Red;
                }
            }
        }


        public string GetText()
        {
            return maskedTextBox1.Text;
        }

        public void SetText(string value)
        {
            maskedTextBox1.Text = value;
        }
    }
}

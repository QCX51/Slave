using System.Windows.Forms;
using Classes;
using System;

namespace Forms
{
    internal partial class Login : Form
    {

        private const string LOGIN_ERROR_MSG = "Invalid username and/or password.";

        internal Login()
        {
            InitializeComponent();
        }

        internal static int GetPassword(string UserName, string Password)
        {
            string UserGUID = Encryptor.DecryptText(AppData.SECURITY.UserGUID, Keygen.ComputeSHA512(UserName + Password));
            if (UserGUID.Equals(string.Empty)) { return 1; }
            string username = Encryptor.DecryptText(AppData.SECURITY.UserName, Keygen.ComputeSHA512(UserGUID + Password));
            if (username.Equals(string.Empty)) { return 2; }
            string password = Encryptor.DecryptText(AppData.SECURITY.Password, Keygen.ComputeSHA512(UserGUID + UserName));
            if (password.Equals(string.Empty)) { return 3; } else { return 0; }
        }

        private void Login_Click(object sender, EventArgs e)
        {
            if (GetPassword(UserBox.Text, PassBox.Text) != 0)
            {
                StatusBox.Text = LOGIN_ERROR_MSG;
                Timer timer = new Timer();
                timer.Tick += TimerTickEvt;
                timer.Interval = 3000;
                timer.Start();
                timer = null;
            }
            else
            {
                DialogResult = DialogResult.Yes;
            }
        }

        private void TimerTickEvt(object sender, EventArgs e)
        {
            if (StatusBox.InvokeRequired)
            {
                StatusBox.Invoke(new Action(() => StatusBox.Text = string.Empty));
            }
            else
            {
                StatusBox.Text = string.Empty;
            }
            using (Timer timer = (Timer)sender as Timer)
            {
                timer.Dispose();
            }
        }

        private void CloseLnk_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult = DialogResult.No;
        }
    }
}

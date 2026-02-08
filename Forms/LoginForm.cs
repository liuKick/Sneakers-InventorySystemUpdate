using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SneakerShop.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Custom watermark implementation for .NET 4.7.2
            SetWatermark(txtUsername, "Enter username");
            SetWatermark(txtPassword, "Enter password");

            txtPassword.PasswordChar = '•';
            this.AcceptButton = btnLogin;
            txtUsername.Focus();
        }

        // Custom watermark method for .NET 4.7.2
        private void SetWatermark(TextBox textBox, string watermarkText)
        {
            textBox.Text = watermarkText;
            textBox.ForeColor = Color.Gray;

            textBox.Enter += (s, e) =>
            {
                if (textBox.Text == watermarkText)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = watermarkText;
                    textBox.ForeColor = Color.Gray;
                }
            };
        }

        // SIMPLE AUTHENTICATION METHOD - ADD THIS
        private async Task<bool> AuthenticateUser(string username, string password)
        {
            // SIMPLE HARDCODED CHECK - NO DATABASE COMPLICATIONS
            await Task.Delay(500); // Simulate async operation

            if (username == "admin" && password == "admin123")
                return true;
            if (username == "staff" && password == "staff123")
                return true;

            return false;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            // Check if still showing watermark text
            if (username == "Enter username" || string.IsNullOrWhiteSpace(username) ||
                password == "Enter password" || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.", "Validation Error");
                return;
            }

            try
            {
                btnLogin.Enabled = false;
                btnLogin.Text = "Authenticating...";
                Cursor = Cursors.WaitCursor;

                // USE THE SIMPLE METHOD INSTEAD - CHANGED THIS LINE
                bool isAuthenticated = await AuthenticateUser(username, password);

                if (isAuthenticated)
                {
                    MessageBox.Show($"Welcome {username}!", "Login Successful");

                    MainMenu mainForm = new MainMenu();
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed");
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login error: {ex.Message}", "Error");
            }
            finally
            {
                btnLogin.Enabled = true;
                btnLogin.Text = "Login";
                Cursor = Cursors.Default;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e) { }
    }
}
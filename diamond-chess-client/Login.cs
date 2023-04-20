using diamond_chess_server.Models;
using diamond_chess_server.Services;
using System.Security.Cryptography;
using System.Text;

namespace DiamondChess
{
	public partial class Login : Form
	{
		string username1, username2;
		Player player1, player2;
		bool user1LoggedIn, user2LoggedIn;
		private Form registerDialogBox;
		private TextBox registrationUsernameTextBox, registrationPasswordTextBox, registrationNameTextBox, registrationSurnameTextBox;
		private Label modalErrorLabel;
		public Login()
		{
			InitializeComponent();
			username1 = string.Empty;
			username2 = string.Empty;
			user1LoggedIn = false;
			user2LoggedIn = false;

			registerDialogBox = new Form();
			registrationUsernameTextBox = new TextBox();
			Label registrationUsernameLabel = new Label();
			registrationPasswordTextBox = new TextBox();
			registrationPasswordTextBox.PasswordChar = '*';
			Label registrationPasswordLabel = new Label();
			registrationNameTextBox = new TextBox();
			Label registrationNameLabel = new Label();
			registrationSurnameTextBox = new TextBox();
			Label registrationSurnameLabel = new Label();
			modalErrorLabel = new Label();
			modalErrorLabel.ForeColor = Color.Red;
			Button registerButton = new Button();
			Button cancelButton = new Button();

			registerDialogBox.Text = "Create a new user profile";
			registrationNameLabel.Text = "Name:";
			registrationNameLabel.AutoSize = true;
			registrationSurnameLabel.Text = "Surname:";
			registrationSurnameLabel.AutoSize = true;
			registrationUsernameLabel.Text = "Username:";
			registrationUsernameLabel.AutoSize = true;
			registrationPasswordLabel.Text = "Password:";
			registrationPasswordLabel.AutoSize = true;

			registrationNameLabel.SetBounds(36, 36, 372, 13);
			registrationNameTextBox.SetBounds(36, 56, 700, 20);
			registrationSurnameLabel.SetBounds(36, 86, 372, 13);
			registrationSurnameTextBox.SetBounds(36, 106, 700, 20);
			registrationUsernameLabel.SetBounds(36, 136, 372, 13);
			registrationUsernameTextBox.SetBounds(36, 156, 700, 20);
			registrationPasswordLabel.SetBounds(36, 186, 372, 13);
			registrationPasswordTextBox.SetBounds(36, 206, 700, 20);
			modalErrorLabel.SetBounds(36, 16, 700, 20);

			registerButton.Text = "Register";
			cancelButton.Text = "Cancel";
			registerButton.DialogResult = DialogResult.OK;
			cancelButton.DialogResult = DialogResult.Cancel;
			registerButton.SetBounds(228, 260, 160, 60);
			cancelButton.SetBounds(400, 260, 160, 60);

			registerDialogBox.ClientSize = new Size(796, 357);
			registerDialogBox.FormBorderStyle = FormBorderStyle.FixedDialog;
			registerDialogBox.StartPosition = FormStartPosition.CenterScreen;
			registerDialogBox.MinimizeBox = false;
			registerDialogBox.MaximizeBox = false;

			registerDialogBox.Controls.AddRange(new Control[] {
				registrationNameLabel, registrationSurnameLabel, registrationUsernameLabel, registrationPasswordLabel,
				registrationNameTextBox, registrationSurnameTextBox, registrationUsernameTextBox, registrationPasswordTextBox,
				registerButton, cancelButton, modalErrorLabel
				});
			registerDialogBox.AcceptButton = registerButton;
			registerDialogBox.CancelButton = cancelButton;
		}

		private async Task<string> registerUser(Boolean reset)
		{
			if (reset)
			{
				modalErrorLabel.Text = "";
				registrationNameTextBox.Clear();
				registrationSurnameTextBox.Clear();
				registrationUsernameTextBox.Clear();
				registrationPasswordTextBox.Clear();
			}

			DialogResult dialogResult = registerDialogBox.ShowDialog();

			if (dialogResult == DialogResult.OK)
			{
				if (registrationNameTextBox.Text.Length < 2) {
					modalErrorLabel.Text = "Name must be at least 2 characters long.";
					return await registerUser(false);
				}

				if (registrationSurnameTextBox.Text.Length < 2) {
					modalErrorLabel.Text = "Surname must be at least 2 characters long.";
					return await registerUser(false);
				}

				if (registrationUsernameTextBox.Text.Length < 5) {
					modalErrorLabel.Text = "Username must be at least 5 characters long.";
					return await registerUser(false);
				}

				if (registrationPasswordTextBox.Text.Length < 10) {
					modalErrorLabel.Text = "Password must be at least 10 characters long.";
					return await registerUser(false);
				}

				Player newPlayer = new Player();
				newPlayer.Name = registrationNameTextBox.Text;
				newPlayer.Surname = registrationSurnameTextBox.Text;
				LoginDetails userDetails = new LoginDetails();
				userDetails.Username = registrationUsernameTextBox.Text;
				userDetails.PasswordHash = hashPassword(registrationPasswordTextBox.Text);
				newPlayer.playerLogin = userDetails;

				if (await RegistrationService.RegisterUser(newPlayer))
				{
					return "";
				} else
				{
					modalErrorLabel.Text = "Username is already taken.";
					return await registerUser(false);
				}
			}
			return "";
		}

		private void Login_Load(object sender, EventArgs e)
		{
			user1LogoutLabel.Visible = false;
			user2LogoutLabel.Visible = false;
			startGameButton.Enabled = false;
		}

		private byte[] hashPassword(string password)
		{//TODO: has function should live elsewhere?
			return SHA512.Create().ComputeHash(Encoding.Unicode.GetBytes(password));
		}

		private async void user1LoginButton_Click(object sender, EventArgs e)
		{
			user1IncorrectLabel.Text = "";

			LoginDetails userDetails = new LoginDetails();
			userDetails.Username = username1Textbox.Text;
			userDetails.PasswordHash = hashPassword(password1Textbox.Text);

			if (user2LoggedIn && (userDetails.Username == username2))
			{
				user1IncorrectLabel.Text = "Cannot login as the same users.";
				username1Textbox.Clear();
				password1Textbox.Clear();
				username1Textbox.Focus();
				user1LoggedIn = false;
			}
			else
			{
				player1 = await LoginService.isValidLogin(userDetails);

				if (player1.Id != 0)
				{
					username1 = username1Textbox.Text;
					player1.playerLogin = userDetails;

					user1LoggedIn = true;
					user1LoginButton.Enabled = false;
					user1RegisterButton.Enabled = false;
					user1PlayAsGuestLabel.Visible = false;
					user1LogoutLabel.Visible = true;

					user1LoginButton.BackColor = Color.DarkGray;
					user1LoginButton.ForeColor = Color.DimGray;
					user1RegisterButton.BackColor = Color.DarkGray;
					user1RegisterButton.ForeColor = Color.DimGray;
				}
				else
				{
					user1IncorrectLabel.Text = "Incorrect username or password, please try again.";
					username1Textbox.Focus();
					user1LoggedIn = false;
				}
			}
			if (user1LoggedIn && user2LoggedIn)
			{
				startGameButton.Enabled = true;
				startGameButton.BackColor = Constants.DarkColour;
				startGameButton.ForeColor = Constants.LightColour;
			}
		}

		private async void user2LoginButton_Click(object sender, EventArgs e)
		{
			user2IncorrectLabel.Text = "";

			LoginDetails userDetails = new LoginDetails();
			userDetails.Username = username2Textbox.Text;
			userDetails.PasswordHash = hashPassword(password2Textbox.Text);

			if (user1LoggedIn && (userDetails.Username == username1))
			{
				user2IncorrectLabel.Text = "Cannot login as the same users.";
				username2Textbox.Clear();
				password2Textbox.Clear();
				username2Textbox.Focus();
				user2LoggedIn = false;
			}
			else
			{
				player2 = await LoginService.isValidLogin(userDetails);

				if (player2.Id != 0)
				{
					username2 = username2Textbox.Text;
					player2.playerLogin = userDetails;

					user2LoggedIn = true;
					user2LoginButton.Enabled = false;
					user2LogoutLabel.Visible = true;
					user2RegisterButton.Enabled = false;
					user2PlayAsGuestLabel.Visible = false;

					user2LoginButton.BackColor = Color.DarkGray;
					user2LoginButton.ForeColor = Color.DimGray;
					user2RegisterButton.BackColor = Color.DarkGray;
					user2RegisterButton.ForeColor = Color.DimGray;
				}
				else
				{
					user2IncorrectLabel.Text = "Incorrect username or password, please try again.";
					username2Textbox.Focus();
					user2LoggedIn = false;
				}
			}
			if (user1LoggedIn && user2LoggedIn)
			{
				startGameButton.Enabled = true;
				startGameButton.BackColor = Constants.DarkColour;
				startGameButton.ForeColor = Constants.LightColour;
			}
		}

		private void password1EyeButton_Click(object sender, EventArgs e)
		{
			if (password1Textbox.PasswordChar == '*')
			{
				password1Textbox.PasswordChar = '\0';
				password1EyeButton.BackgroundImage = Properties.Resources.EyeCrossed;
			}
			else
			{
				password1Textbox.PasswordChar = '*';
				password1EyeButton.BackgroundImage = Properties.Resources.Eye;
			}
		}

		private void password2EyeButton_Click(object sender, EventArgs e)
		{
			if (password2Textbox.PasswordChar == '*')
			{
				password2Textbox.PasswordChar = '\0';
				password2EyeButton.BackgroundImage = Properties.Resources.EyeCrossed;
			}
			else
			{
				password2Textbox.PasswordChar = '*';
				password2EyeButton.BackgroundImage = Properties.Resources.Eye;
			}
		}

		private async void startGameButton_Click(object sender, EventArgs e)
		{
			if (user1LoggedIn && user2LoggedIn)
			{
				player1 = await MatchRecordService.updateRecords(player1);
				player2 = await MatchRecordService.updateRecords(player2);

				new Game(player1, player2).Show();
				Hide();
			}

		}

		private void user1LogoutLabel_Click(object sender, EventArgs e)
		{
			user1LoggedIn = false;
			user1LoginButton.Enabled = true;
			user1RegisterButton.Enabled = true;
			user1PlayAsGuestLabel.Visible = true;
			user1LogoutLabel.Visible = false;
			username1Textbox.Clear();
			password1Textbox.Clear();
			username1Textbox.Focus();

			startGameButton.BackColor = Color.DarkGray;
			startGameButton.ForeColor = Color.DimGray;
			user1LoginButton.BackColor = Constants.DarkColour;
			user1LoginButton.ForeColor = Constants.LightColour;
			user1RegisterButton.BackColor = Constants.DarkColour;
			user1RegisterButton.ForeColor = Constants.LightColour;
		}

		private void user2LogoutLabel_Click(object sender, EventArgs e)
		{
			user2LoggedIn = false;
			user2LoginButton.Enabled = true;
			user2RegisterButton.Enabled = true;
			user2PlayAsGuestLabel.Visible = true;
			user2LogoutLabel.Visible = false;
			username2Textbox.Clear();
			password2Textbox.Clear();
			username2Textbox.Focus();

			startGameButton.BackColor = Color.DarkGray;
			startGameButton.ForeColor = Color.DimGray;
			user2LoginButton.BackColor = Constants.DarkColour;
			user2LoginButton.ForeColor = Constants.LightColour;
			user2RegisterButton.BackColor = Constants.DarkColour;
			user2RegisterButton.ForeColor = Constants.LightColour;
		}

		private async void user1RegisterButton_Click(object sender, EventArgs e)
		{
			user1IncorrectLabel.Text = await registerUser(true);
		}

		private async void user2RegisterButton_Click(object sender, EventArgs e)
		{
			user2IncorrectLabel.Text = await registerUser(true);
		}

		private void user1PlayAsGuestLabel_Click(object sender, EventArgs e)
		{
				username1 = "Guest Player 1";
				player1 = new Player();
				LoginDetails guestLogin = new LoginDetails();
				guestLogin.Username = username1;
				player1.playerLogin = guestLogin;

				user1LoggedIn = true;
				user1LoginButton.Enabled = false;
				user1RegisterButton.Enabled = false;
				user1PlayAsGuestLabel.Visible = false;
				user1LogoutLabel.Visible = true;

				user1LoginButton.BackColor = Color.DarkGray;
				user1LoginButton.ForeColor = Color.DimGray;
				user1RegisterButton.BackColor = Color.DarkGray;
				user1RegisterButton.ForeColor = Color.DimGray;

				if (user1LoggedIn && user2LoggedIn)
				{
					startGameButton.Enabled = true;
					startGameButton.BackColor = Constants.DarkColour;
					startGameButton.ForeColor = Constants.LightColour;
				}
		}

		private void user2PlayAsGuestLabel_Click(object sender, EventArgs e)
		{
				username2 = "Guest Player 2";
				player2 = new Player();
				LoginDetails guestLogin = new LoginDetails();
				guestLogin.Username = username2;
				player2.playerLogin = guestLogin;

				user2LoggedIn = true;
				user2LoginButton.Enabled = false;
				user2RegisterButton.Enabled = false;
				user2PlayAsGuestLabel.Visible = false;
				user2LogoutLabel.Visible = true;

				user2LoginButton.BackColor = Color.DarkGray;
				user2LoginButton.ForeColor = Color.DimGray;
				user2RegisterButton.BackColor = Color.DarkGray;
				user2RegisterButton.ForeColor = Color.DimGray;

				if (user1LoggedIn && user2LoggedIn)
				{
					startGameButton.Enabled = true;
					startGameButton.BackColor = Constants.DarkColour;
					startGameButton.ForeColor = Constants.LightColour;
				}
		}
	}
}

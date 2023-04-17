namespace DiamondChess
{
	public partial class Login : Form
	{
		string username1, username2;
		bool user1LoggedIn, user2LoggedIn;
		public Login()
		{
			InitializeComponent();
			username1 = string.Empty;
			username2 = string.Empty;
			user1LoggedIn = false;
			user2LoggedIn = false;
		}

		private void Login_Load(object sender, EventArgs e)
		{
			user1LogoutLabel.Visible = false;
			user2LogoutLabel.Visible = false;
			startGameButton.Enabled = false;
		}

		private void user1LoginButton_Click(object sender, EventArgs e)
		{
			user1IncorrectLabel.Text = "";

			// @ GABRIEL THIS IS WHERE YOU WOULD REQUEST A LOGIN OR SOMETHING IDK ???
			if (username1Textbox.Text == "admin1" && password1Textbox.Text == "1234")
			{
				username1 = username1Textbox.Text;
				user1LoggedIn = true;
				user1LoginButton.Enabled = false;
				user1LogoutLabel.Visible = true;

				user1LoginButton.BackColor = Color.DarkGray;
				user1LoginButton.ForeColor = Color.DimGray;
			}
			else
			{
				user1IncorrectLabel.Text = "Incorrect username or password, please try again.";
				username1Textbox.Clear();
				password1Textbox.Clear();
				username1Textbox.Focus();
				user1LoggedIn = false;
			}
			if (user1LoggedIn && user2LoggedIn)
			{
				startGameButton.Enabled = true;
				startGameButton.BackColor = Constants.DarkColour;
				startGameButton.ForeColor = Constants.LightColour;
			}
		}

		private void user2LoginButton_Click(object sender, EventArgs e)
		{
			user2IncorrectLabel.Text = "";

			// @ GABRIEL THIS IS WHERE YOU WOULD REQUEST A LOGIN OR SOMETHING IDK ??? part 2
			if (username2Textbox.Text == "admin2" && password2Textbox.Text == "1234")
			{
				username2 = username2Textbox.Text;
				user2LoggedIn = true;
				user2LoginButton.Enabled = false;
				user2LogoutLabel.Visible = true;

				user2LoginButton.BackColor = Color.DarkGray;
				user2LoginButton.ForeColor = Color.DimGray;
			}
			else
			{
				user2IncorrectLabel.Text = "Incorrect username or password, please try again.";
				username2Textbox.Clear();
				password2Textbox.Clear();
				username2Textbox.Focus();
				user2LoggedIn = false;
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

		private void startGameButton_Click(object sender, EventArgs e)
		{
			if (user1LoggedIn && user2LoggedIn)
			{
				new Game(username1, username2).Show();
				Hide();
			}

		}

		private void user1LogoutLabel_Click(object sender, EventArgs e)
		{
			user1LoginButton.Enabled = true;
			user1LogoutLabel.Visible = false;
			username1Textbox.Clear();
			password1Textbox.Clear();
			username1Textbox.Focus();

			startGameButton.BackColor = Color.DarkGray;
			startGameButton.ForeColor = Color.DimGray;
			user1LoginButton.BackColor = Constants.DarkColour;
			user1LoginButton.ForeColor = Constants.LightColour;
		}

		private void user2LogoutLabel_Click(object sender, EventArgs e)
		{
			user2LoginButton.Enabled = true;
			user2LogoutLabel.Visible = false;
			username2Textbox.Clear();
			password2Textbox.Clear();
			username2Textbox.Focus();

			startGameButton.BackColor = Color.DarkGray;
			startGameButton.ForeColor = Color.DimGray;
			user2LoginButton.BackColor = Constants.DarkColour;
			user2LoginButton.ForeColor = Constants.LightColour;
		}
	}
}

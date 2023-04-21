namespace DiamondChess
{
  partial class Login
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      headingLabel = new Label();
      username1UnderlinePanel = new Panel();
      password1UnderlinePanel = new Panel();
      user1LoginButton = new Button();
      username1Textbox = new TextBox();
      password1Textbox = new TextBox();
      password1Image = new PictureBox();
      user1Image = new PictureBox();
      logoImage = new PictureBox();
      password1EyeButton = new Button();
      user1IncorrectLabel = new Label();
      user1Label = new Label();
      user2Label = new Label();
      user2IncorrectLabel = new Label();
      password2EyeButton = new Button();
      password2Textbox = new TextBox();
      username2Textbox = new TextBox();
      user2LoginButton = new Button();
      password2UnderlinePanel = new Panel();
      username2UnderlinePanel = new Panel();
      password2Image = new PictureBox();
      user2Image = new PictureBox();
      startGameButton = new Button();
      user1LogoutLabel = new Label();
      user2LogoutLabel = new Label();
      pictureBox1 = new PictureBox();
      user1RegisterButton = new Button();
      user2RegisterButton = new Button();
      user1PlayAsGuestLabel = new Label();
      user2PlayAsGuestLabel = new Label();
      ((System.ComponentModel.ISupportInitialize)password1Image).BeginInit();
      ((System.ComponentModel.ISupportInitialize)user1Image).BeginInit();
      ((System.ComponentModel.ISupportInitialize)logoImage).BeginInit();
      ((System.ComponentModel.ISupportInitialize)password2Image).BeginInit();
      ((System.ComponentModel.ISupportInitialize)user2Image).BeginInit();
      ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
      SuspendLayout();
      // 
      // headingLabel
      // 
      headingLabel.AccessibleName = "Diamond Chess heading";
      headingLabel.AutoSize = true;
      headingLabel.BackColor = Color.Transparent;
      headingLabel.Font = new Font("Javanese Text", 42F, FontStyle.Bold, GraphicsUnit.Point);
      headingLabel.Location = new Point(595, 15);
      headingLabel.Margin = new Padding(0);
      headingLabel.Name = "headingLabel";
      headingLabel.Size = new Size(438, 127);
      headingLabel.TabIndex = 1;
      headingLabel.Text = "Diamond Chess";
      headingLabel.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // username1UnderlinePanel
      // 
      username1UnderlinePanel.BackColor = Color.FromArgb(41, 76, 96);
      username1UnderlinePanel.Location = new Point(397, 268);
      username1UnderlinePanel.Margin = new Padding(0);
      username1UnderlinePanel.Name = "username1UnderlinePanel";
      username1UnderlinePanel.Size = new Size(332, 2);
      username1UnderlinePanel.TabIndex = 5;
      // 
      // password1UnderlinePanel
      // 
      password1UnderlinePanel.BackColor = Color.FromArgb(41, 76, 96);
      password1UnderlinePanel.Location = new Point(397, 355);
      password1UnderlinePanel.Name = "password1UnderlinePanel";
      password1UnderlinePanel.Size = new Size(332, 2);
      password1UnderlinePanel.TabIndex = 6;
      // 
      // user1LoginButton
      // 
      user1LoginButton.BackColor = Color.FromArgb(41, 76, 96);
      user1LoginButton.Cursor = Cursors.Hand;
      user1LoginButton.Font = new Font("Arial", 19.8F, FontStyle.Bold, GraphicsUnit.Point);
      user1LoginButton.ForeColor = Color.FromArgb(173, 182, 196);
      user1LoginButton.Location = new Point(366, 418);
      user1LoginButton.Margin = new Padding(0);
      user1LoginButton.Name = "user1LoginButton";
      user1LoginButton.Size = new Size(366, 68);
      user1LoginButton.TabIndex = 7;
      user1LoginButton.Text = "LOG IN";
      user1LoginButton.UseVisualStyleBackColor = false;
      user1LoginButton.Click += user1LoginButton_Click;
      // 
      // username1Textbox
      // 
      username1Textbox.BorderStyle = BorderStyle.None;
      username1Textbox.Cursor = Cursors.IBeam;
      username1Textbox.Font = new Font("Arial", 20F, FontStyle.Regular, GraphicsUnit.Point);
      username1Textbox.Location = new Point(427, 220);
      username1Textbox.Margin = new Padding(0);
      username1Textbox.Multiline = true;
      username1Textbox.Name = "username1Textbox";
      username1Textbox.Size = new Size(304, 45);
      username1Textbox.TabIndex = 8;
      // 
      // password1Textbox
      // 
      password1Textbox.BorderStyle = BorderStyle.None;
      password1Textbox.Font = new Font("Arial", 20F, FontStyle.Regular, GraphicsUnit.Point);
      password1Textbox.Location = new Point(427, 305);
      password1Textbox.Margin = new Padding(0);
      password1Textbox.Multiline = true;
      password1Textbox.Name = "password1Textbox";
      password1Textbox.PasswordChar = '*';
      password1Textbox.Size = new Size(304, 46);
      password1Textbox.TabIndex = 9;
      // 
      // password1Image
      // 
      password1Image.BackColor = Color.Transparent;
      password1Image.Image = Properties.Resources.Password;
      password1Image.Location = new Point(367, 298);
      password1Image.Name = "password1Image";
      password1Image.Size = new Size(61, 66);
      password1Image.SizeMode = PictureBoxSizeMode.Zoom;
      password1Image.TabIndex = 4;
      password1Image.TabStop = false;
      // 
      // user1Image
      // 
      user1Image.BackColor = Color.Transparent;
      user1Image.Image = Properties.Resources.Login;
      user1Image.Location = new Point(367, 212);
      user1Image.Name = "user1Image";
      user1Image.Size = new Size(61, 66);
      user1Image.SizeMode = PictureBoxSizeMode.Zoom;
      user1Image.TabIndex = 3;
      user1Image.TabStop = false;
      // 
      // logoImage
      // 
      logoImage.AccessibleDescription = "The logo of Diamond Chess which inludes the silhouette of a black king chess piece surrounded by the outline of a dark blue and light blue diamond.";
      logoImage.AccessibleName = "Diamond Chess Logo";
      logoImage.AccessibleRole = AccessibleRole.Graphic;
      logoImage.BackColor = Color.Transparent;
      logoImage.Image = Properties.Resources.Logo;
      logoImage.Location = new Point(461, 4);
      logoImage.Margin = new Padding(0);
      logoImage.Name = "logoImage";
      logoImage.Size = new Size(134, 124);
      logoImage.SizeMode = PictureBoxSizeMode.Zoom;
      logoImage.TabIndex = 0;
      logoImage.TabStop = false;
      // 
      // password1EyeButton
      // 
      password1EyeButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      password1EyeButton.BackColor = Color.Transparent;
      password1EyeButton.BackgroundImage = Properties.Resources.Eye;
      password1EyeButton.BackgroundImageLayout = ImageLayout.Zoom;
      password1EyeButton.Cursor = Cursors.Hand;
      password1EyeButton.FlatAppearance.BorderSize = 0;
      password1EyeButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
      password1EyeButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
      password1EyeButton.FlatStyle = FlatStyle.Flat;
      password1EyeButton.ForeColor = Color.Transparent;
      password1EyeButton.Location = new Point(692, 311);
      password1EyeButton.Margin = new Padding(0);
      password1EyeButton.Name = "password1EyeButton";
      password1EyeButton.Size = new Size(39, 42);
      password1EyeButton.TabIndex = 11;
      password1EyeButton.TextAlign = ContentAlignment.MiddleRight;
      password1EyeButton.UseVisualStyleBackColor = false;
      password1EyeButton.Click += password1EyeButton_Click;
      // 
      // user1IncorrectLabel
      // 
      user1IncorrectLabel.AutoSize = true;
      user1IncorrectLabel.BackColor = Color.Transparent;
      user1IncorrectLabel.Font = new Font("Arial", 12F, FontStyle.Italic, GraphicsUnit.Point);
      user1IncorrectLabel.ForeColor = Color.FromArgb(41, 76, 96);
      user1IncorrectLabel.Location = new Point(371, 382);
      user1IncorrectLabel.Margin = new Padding(0);
      user1IncorrectLabel.Name = "user1IncorrectLabel";
      user1IncorrectLabel.Size = new Size(0, 19);
      user1IncorrectLabel.TabIndex = 12;
      user1IncorrectLabel.TextAlign = ContentAlignment.MiddleCenter;
      // 
      // user1Label
      // 
      user1Label.AccessibleName = "Diamond Chess heading";
      user1Label.AutoSize = true;
      user1Label.BackColor = Color.Transparent;
      user1Label.Font = new Font("Javanese Text", 30F, FontStyle.Bold, GraphicsUnit.Point);
      user1Label.Location = new Point(454, 134);
      user1Label.Margin = new Padding(0);
      user1Label.Name = "user1Label";
      user1Label.Size = new Size(181, 91);
      user1Label.TabIndex = 13;
      user1Label.Text = "Player 1";
      user1Label.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // user2Label
      // 
      user2Label.AccessibleName = "Diamond Chess heading";
      user2Label.AutoSize = true;
      user2Label.BackColor = Color.Transparent;
      user2Label.Font = new Font("Javanese Text", 30F, FontStyle.Bold, GraphicsUnit.Point);
      user2Label.Location = new Point(1003, 134);
      user2Label.Margin = new Padding(0);
      user2Label.Name = "user2Label";
      user2Label.Size = new Size(188, 91);
      user2Label.TabIndex = 14;
      user2Label.Text = "Player 2";
      user2Label.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // user2IncorrectLabel
      // 
      user2IncorrectLabel.AutoSize = true;
      user2IncorrectLabel.BackColor = Color.Transparent;
      user2IncorrectLabel.Font = new Font("Arial", 12F, FontStyle.Italic, GraphicsUnit.Point);
      user2IncorrectLabel.ForeColor = Color.FromArgb(41, 76, 96);
      user2IncorrectLabel.Location = new Point(916, 382);
      user2IncorrectLabel.Margin = new Padding(0);
      user2IncorrectLabel.Name = "user2IncorrectLabel";
      user2IncorrectLabel.Size = new Size(0, 19);
      user2IncorrectLabel.TabIndex = 24;
      user2IncorrectLabel.TextAlign = ContentAlignment.MiddleCenter;
      // 
      // password2EyeButton
      // 
      password2EyeButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      password2EyeButton.BackColor = Color.Transparent;
      password2EyeButton.BackgroundImage = Properties.Resources.Eye;
      password2EyeButton.BackgroundImageLayout = ImageLayout.Zoom;
      password2EyeButton.Cursor = Cursors.Hand;
      password2EyeButton.FlatAppearance.BorderSize = 0;
      password2EyeButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
      password2EyeButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
      password2EyeButton.FlatStyle = FlatStyle.Flat;
      password2EyeButton.ForeColor = Color.Transparent;
      password2EyeButton.Location = new Point(1237, 311);
      password2EyeButton.Margin = new Padding(0);
      password2EyeButton.Name = "password2EyeButton";
      password2EyeButton.Size = new Size(39, 42);
      password2EyeButton.TabIndex = 23;
      password2EyeButton.TextAlign = ContentAlignment.MiddleRight;
      password2EyeButton.UseVisualStyleBackColor = false;
      password2EyeButton.Click += password2EyeButton_Click;
      // 
      // password2Textbox
      // 
      password2Textbox.BorderStyle = BorderStyle.None;
      password2Textbox.Font = new Font("Arial", 20F, FontStyle.Regular, GraphicsUnit.Point);
      password2Textbox.Location = new Point(972, 305);
      password2Textbox.Margin = new Padding(0);
      password2Textbox.Multiline = true;
      password2Textbox.Name = "password2Textbox";
      password2Textbox.PasswordChar = '*';
      password2Textbox.Size = new Size(304, 46);
      password2Textbox.TabIndex = 21;
      // 
      // username2Textbox
      // 
      username2Textbox.BorderStyle = BorderStyle.None;
      username2Textbox.Cursor = Cursors.IBeam;
      username2Textbox.Font = new Font("Arial", 20F, FontStyle.Regular, GraphicsUnit.Point);
      username2Textbox.Location = new Point(972, 220);
      username2Textbox.Margin = new Padding(0);
      username2Textbox.Multiline = true;
      username2Textbox.Name = "username2Textbox";
      username2Textbox.Size = new Size(304, 45);
      username2Textbox.TabIndex = 20;
      // 
      // user2LoginButton
      // 
      user2LoginButton.BackColor = Color.FromArgb(41, 76, 96);
      user2LoginButton.Cursor = Cursors.Hand;
      user2LoginButton.Font = new Font("Arial", 19.8F, FontStyle.Bold, GraphicsUnit.Point);
      user2LoginButton.ForeColor = Color.FromArgb(173, 182, 196);
      user2LoginButton.Location = new Point(912, 418);
      user2LoginButton.Margin = new Padding(0);
      user2LoginButton.Name = "user2LoginButton";
      user2LoginButton.Size = new Size(366, 68);
      user2LoginButton.TabIndex = 19;
      user2LoginButton.Text = "LOG IN";
      user2LoginButton.UseVisualStyleBackColor = false;
      user2LoginButton.Click += user2LoginButton_Click;
      // 
      // password2UnderlinePanel
      // 
      password2UnderlinePanel.BackColor = Color.FromArgb(41, 76, 96);
      password2UnderlinePanel.Location = new Point(942, 355);
      password2UnderlinePanel.Name = "password2UnderlinePanel";
      password2UnderlinePanel.Size = new Size(332, 2);
      password2UnderlinePanel.TabIndex = 18;
      // 
      // username2UnderlinePanel
      // 
      username2UnderlinePanel.BackColor = Color.FromArgb(41, 76, 96);
      username2UnderlinePanel.Location = new Point(942, 268);
      username2UnderlinePanel.Margin = new Padding(0);
      username2UnderlinePanel.Name = "username2UnderlinePanel";
      username2UnderlinePanel.Size = new Size(332, 2);
      username2UnderlinePanel.TabIndex = 17;
      // 
      // password2Image
      // 
      password2Image.BackColor = Color.Transparent;
      password2Image.Image = Properties.Resources.Password;
      password2Image.Location = new Point(910, 298);
      password2Image.Name = "password2Image";
      password2Image.Size = new Size(61, 66);
      password2Image.SizeMode = PictureBoxSizeMode.Zoom;
      password2Image.TabIndex = 16;
      password2Image.TabStop = false;
      // 
      // user2Image
      // 
      user2Image.BackColor = Color.Transparent;
      user2Image.Image = Properties.Resources.Login;
      user2Image.Location = new Point(910, 212);
      user2Image.Name = "user2Image";
      user2Image.Size = new Size(61, 66);
      user2Image.SizeMode = PictureBoxSizeMode.Zoom;
      user2Image.TabIndex = 15;
      user2Image.TabStop = false;
      // 
      // startGameButton
      // 
      startGameButton.BackColor = Color.DarkGray;
      startGameButton.Cursor = Cursors.Hand;
      startGameButton.Font = new Font("Arial", 19.8F, FontStyle.Bold, GraphicsUnit.Point);
      startGameButton.ForeColor = Color.DimGray;
      startGameButton.Location = new Point(608, 619);
      startGameButton.Margin = new Padding(0);
      startGameButton.Name = "startGameButton";
      startGameButton.Size = new Size(420, 68);
      startGameButton.TabIndex = 25;
      startGameButton.Text = "START GAME";
      startGameButton.UseVisualStyleBackColor = false;
      startGameButton.Click += startGameButton_Click;
      // 
      // user1LogoutLabel
      // 
      user1LogoutLabel.AutoSize = true;
      user1LogoutLabel.Cursor = Cursors.Hand;
      user1LogoutLabel.Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
      user1LogoutLabel.ForeColor = Color.FromArgb(41, 76, 96);
      user1LogoutLabel.Location = new Point(492, 486);
      user1LogoutLabel.Name = "user1LogoutLabel";
      user1LogoutLabel.Size = new Size(98, 22);
      user1LogoutLabel.TabIndex = 26;
      user1LogoutLabel.Text = "LOG OUT";
      user1LogoutLabel.Click += user1LogoutLabel_Click;
      // 
      // user2LogoutLabel
      // 
      user2LogoutLabel.AutoSize = true;
      user2LogoutLabel.Cursor = Cursors.Hand;
      user2LogoutLabel.Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
      user2LogoutLabel.ForeColor = Color.FromArgb(41, 76, 96);
      user2LogoutLabel.Location = new Point(1043, 486);
      user2LogoutLabel.Name = "user2LogoutLabel";
      user2LogoutLabel.Size = new Size(98, 22);
      user2LogoutLabel.TabIndex = 27;
      user2LogoutLabel.Text = "LOG OUT";
      user2LogoutLabel.Click += user2LogoutLabel_Click;
      // 
      // pictureBox1
      // 
      pictureBox1.AccessibleDescription = "The logo of Diamond Chess which inludes the silhouette of a black king chess piece surrounded by the outline of a dark blue and light blue diamond.";
      pictureBox1.AccessibleName = "Diamond Chess Logo";
      pictureBox1.AccessibleRole = AccessibleRole.Graphic;
      pictureBox1.BackColor = Color.Transparent;
      pictureBox1.Image = Properties.Resources.Logo;
      pictureBox1.Location = new Point(1055, 4);
      pictureBox1.Margin = new Padding(0);
      pictureBox1.Name = "pictureBox1";
      pictureBox1.Size = new Size(134, 124);
      pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
      pictureBox1.TabIndex = 28;
      pictureBox1.TabStop = false;
      // 
      // user1RegisterButton
      // 
      user1RegisterButton.BackColor = Color.FromArgb(41, 76, 96);
      user1RegisterButton.Cursor = Cursors.Hand;
      user1RegisterButton.Font = new Font("Arial", 19.8F, FontStyle.Bold, GraphicsUnit.Point);
      user1RegisterButton.ForeColor = Color.FromArgb(173, 182, 196);
      user1RegisterButton.Location = new Point(367, 522);
      user1RegisterButton.Margin = new Padding(0);
      user1RegisterButton.Name = "user1RegisterButton";
      user1RegisterButton.Size = new Size(366, 68);
      user1RegisterButton.TabIndex = 29;
      user1RegisterButton.Text = "REGISTER";
      user1RegisterButton.UseVisualStyleBackColor = false;
      user1RegisterButton.Click += user1RegisterButton_Click;
      // 
      // user2RegisterButton
      // 
      user2RegisterButton.BackColor = Color.FromArgb(41, 76, 96);
      user2RegisterButton.Cursor = Cursors.Hand;
      user2RegisterButton.Font = new Font("Arial", 19.8F, FontStyle.Bold, GraphicsUnit.Point);
      user2RegisterButton.ForeColor = Color.FromArgb(173, 182, 196);
      user2RegisterButton.Location = new Point(916, 522);
      user2RegisterButton.Margin = new Padding(0);
      user2RegisterButton.Name = "user2RegisterButton";
      user2RegisterButton.Size = new Size(366, 68);
      user2RegisterButton.TabIndex = 30;
      user2RegisterButton.Text = "REGISTER";
      user2RegisterButton.UseVisualStyleBackColor = false;
      user2RegisterButton.Click += user2RegisterButton_Click;
      // 
      // user1PlayAsGuestLabel
      // 
      user1PlayAsGuestLabel.AutoSize = true;
      user1PlayAsGuestLabel.Cursor = Cursors.Hand;
      user1PlayAsGuestLabel.Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
      user1PlayAsGuestLabel.ForeColor = Color.FromArgb(41, 76, 96);
      user1PlayAsGuestLabel.Location = new Point(461, 590);
      user1PlayAsGuestLabel.Name = "user1PlayAsGuestLabel";
      user1PlayAsGuestLabel.Size = new Size(161, 22);
      user1PlayAsGuestLabel.TabIndex = 31;
      user1PlayAsGuestLabel.Text = "PLAY AS GUEST";
      user1PlayAsGuestLabel.Click += user1PlayAsGuestLabel_Click;
      // 
      // user2PlayAsGuestLabel
      // 
      user2PlayAsGuestLabel.AutoSize = true;
      user2PlayAsGuestLabel.Cursor = Cursors.Hand;
      user2PlayAsGuestLabel.Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
      user2PlayAsGuestLabel.ForeColor = Color.FromArgb(41, 76, 96);
      user2PlayAsGuestLabel.Location = new Point(1019, 590);
      user2PlayAsGuestLabel.Name = "user2PlayAsGuestLabel";
      user2PlayAsGuestLabel.Size = new Size(161, 22);
      user2PlayAsGuestLabel.TabIndex = 32;
      user2PlayAsGuestLabel.Text = "PLAY AS GUEST";
      user2PlayAsGuestLabel.Click += user2PlayAsGuestLabel_Click;
      // 
      // Login
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.White;
      ClientSize = new Size(1663, 791);
      Controls.Add(user2PlayAsGuestLabel);
      Controls.Add(user1PlayAsGuestLabel);
      Controls.Add(user2RegisterButton);
      Controls.Add(user1RegisterButton);
      Controls.Add(pictureBox1);
      Controls.Add(user2LogoutLabel);
      Controls.Add(user1LogoutLabel);
      Controls.Add(startGameButton);
      Controls.Add(user2IncorrectLabel);
      Controls.Add(password2EyeButton);
      Controls.Add(password2Textbox);
      Controls.Add(username2Textbox);
      Controls.Add(user2LoginButton);
      Controls.Add(password2UnderlinePanel);
      Controls.Add(username2UnderlinePanel);
      Controls.Add(password2Image);
      Controls.Add(user2Image);
      Controls.Add(user2Label);
      Controls.Add(user1Label);
      Controls.Add(user1IncorrectLabel);
      Controls.Add(password1EyeButton);
      Controls.Add(logoImage);
      Controls.Add(password1Textbox);
      Controls.Add(username1Textbox);
      Controls.Add(user1LoginButton);
      Controls.Add(password1UnderlinePanel);
      Controls.Add(username1UnderlinePanel);
      Controls.Add(password1Image);
      Controls.Add(user1Image);
      Controls.Add(headingLabel);
      FormBorderStyle = FormBorderStyle.FixedDialog;
      MaximizeBox = false;
      Name = "Login";
      StartPosition = FormStartPosition.CenterScreen;
      Text = "Login";
      Load += Login_Load;
      ((System.ComponentModel.ISupportInitialize)password1Image).EndInit();
      ((System.ComponentModel.ISupportInitialize)user1Image).EndInit();
      ((System.ComponentModel.ISupportInitialize)logoImage).EndInit();
      ((System.ComponentModel.ISupportInitialize)password2Image).EndInit();
      ((System.ComponentModel.ISupportInitialize)user2Image).EndInit();
      ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private PictureBox logoImage;
    private Label headingLabel;
    private PictureBox user1Image;
    private PictureBox password1Image;

    private Panel username1UnderlinePanel;
    private Panel password1UnderlinePanel;

    private Button user1LoginButton;
    private Button user2LoginButton;

    private TextBox username1Textbox;
    private TextBox password1Textbox;

    private Button password1EyeButton;
    private Button password2EyeButton;

    private Label user1IncorrectLabel;
    private Label user2IncorrectLabel;

    private Label user1Label;
    private Label user2Label;

    private TextBox password2Textbox;
    private TextBox username2Textbox;

    private Panel password2UnderlinePanel;
    private Panel username2UnderlinePanel;

    private PictureBox password2Image;
    private PictureBox user2Image;

    private Button startGameButton;

    private Label user1LogoutLabel;
    private Label user2LogoutLabel;
    private PictureBox pictureBox1;
    private Button user1RegisterButton;
    private Button user2RegisterButton;
    private Label user1PlayAsGuestLabel;
    private Label user2PlayAsGuestLabel;
  }
}


namespace DiamondChess
{
	partial class Game
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
			headingLabel = new Label();
			logoImage = new PictureBox();
			pictureBox1 = new PictureBox();
			playerTurnText = new Label();
			playerTurnPictureBox = new PictureBox();
			playerTurnLabel = new Label();
			button1 = new Button();
			button2 = new Button();
			button3 = new Button();
			((System.ComponentModel.ISupportInitialize)logoImage).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)playerTurnPictureBox).BeginInit();
			SuspendLayout();
			// 
			// headingLabel
			// 
			headingLabel.AccessibleName = "Diamond Chess heading";
			headingLabel.AutoSize = true;
			headingLabel.BackColor = Color.Transparent;
			headingLabel.Font = new Font("Javanese Text", 42F, FontStyle.Bold, GraphicsUnit.Point);
			headingLabel.Location = new Point(159, 14);
			headingLabel.Margin = new Padding(0);
			headingLabel.Name = "headingLabel";
			headingLabel.Size = new Size(544, 159);
			headingLabel.TabIndex = 2;
			headingLabel.Text = "Diamond Chess";
			headingLabel.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// logoImage
			// 
			logoImage.AccessibleDescription = "The logo of Diamond Chess which inludes the silhouette of a black king chess piece surrounded by the outline of a dark blue and light blue diamond.";
			logoImage.AccessibleName = "Diamond Chess Logo";
			logoImage.AccessibleRole = AccessibleRole.Graphic;
			logoImage.BackColor = Color.Transparent;
			logoImage.Image = Properties.Resources.Logo;
			logoImage.Location = new Point(12, 14);
			logoImage.Margin = new Padding(0);
			logoImage.Name = "logoImage";
			logoImage.Size = new Size(147, 169);
			logoImage.SizeMode = PictureBoxSizeMode.Zoom;
			logoImage.TabIndex = 3;
			logoImage.TabStop = false;
			// 
			// pictureBox1
			// 
			pictureBox1.AccessibleDescription = "The logo of Diamond Chess which inludes the silhouette of a black king chess piece surrounded by the outline of a dark blue and light blue diamond.";
			pictureBox1.AccessibleName = "Diamond Chess Logo";
			pictureBox1.AccessibleRole = AccessibleRole.Graphic;
			pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			pictureBox1.BackColor = Color.Transparent;
			pictureBox1.Image = Properties.Resources.Logo;
			pictureBox1.Location = new Point(1743, 14);
			pictureBox1.Margin = new Padding(0);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(147, 169);
			pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 4;
			pictureBox1.TabStop = false;
			// 
			// playerTurnText
			// 
			playerTurnText.AccessibleName = "Diamond Chess heading";
			playerTurnText.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			playerTurnText.AutoSize = true;
			playerTurnText.BackColor = Color.Transparent;
			playerTurnText.FlatStyle = FlatStyle.Flat;
			playerTurnText.Font = new Font("Javanese Text", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
			playerTurnText.ForeColor = SystemColors.ControlText;
			playerTurnText.Location = new Point(1408, 72);
			playerTurnText.Margin = new Padding(0);
			playerTurnText.Name = "playerTurnText";
			playerTurnText.RightToLeft = RightToLeft.No;
			playerTurnText.Size = new Size(157, 62);
			playerTurnText.TabIndex = 5;
			playerTurnText.Text = "UserName";
			playerTurnText.TextAlign = ContentAlignment.MiddleRight;
			// 
			// playerTurnPictureBox
			// 
			playerTurnPictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			playerTurnPictureBox.BackColor = Color.Transparent;
			playerTurnPictureBox.BackgroundImage = Properties.Resources.W_WideLabelBackground;
			playerTurnPictureBox.BackgroundImageLayout = ImageLayout.Stretch;
			playerTurnPictureBox.Location = new Point(1187, 14);
			playerTurnPictureBox.Margin = new Padding(0);
			playerTurnPictureBox.Name = "playerTurnPictureBox";
			playerTurnPictureBox.Size = new Size(532, 169);
			playerTurnPictureBox.TabIndex = 6;
			playerTurnPictureBox.TabStop = false;
			// 
			// playerTurnLabel
			// 
			playerTurnLabel.AccessibleName = "Diamond Chess heading";
			playerTurnLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			playerTurnLabel.AutoSize = true;
			playerTurnLabel.BackColor = Color.Transparent;
			playerTurnLabel.FlatStyle = FlatStyle.Flat;
			playerTurnLabel.Font = new Font("Javanese Text", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
			playerTurnLabel.ForeColor = SystemColors.ControlText;
			playerTurnLabel.Location = new Point(1242, 72);
			playerTurnLabel.Margin = new Padding(0);
			playerTurnLabel.Name = "playerTurnLabel";
			playerTurnLabel.RightToLeft = RightToLeft.No;
			playerTurnLabel.Size = new Size(157, 62);
			playerTurnLabel.TabIndex = 7;
			playerTurnLabel.Text = "TO PLAY:";
			playerTurnLabel.TextAlign = ContentAlignment.MiddleRight;
			// 
			// button1
			// 
			button1.Location = new Point(65, 215);
			button1.Name = "button1";
			button1.Size = new Size(94, 29);
			button1.TabIndex = 8;
			button1.Text = "HIGHLIGHT";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// button2
			// 
			button2.Location = new Point(65, 263);
			button2.Name = "button2";
			button2.Size = new Size(94, 29);
			button2.TabIndex = 9;
			button2.Text = "ADD ALL";
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click;
			// 
			// button3
			// 
			button3.Location = new Point(65, 314);
			button3.Name = "button3";
			button3.Size = new Size(94, 29);
			button3.TabIndex = 10;
			button3.Text = "REMOVE";
			button3.UseVisualStyleBackColor = true;
			button3.Click += button3_Click;
			// 
			// Game
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			ClientSize = new Size(1901, 1291);
			Controls.Add(button3);
			Controls.Add(button2);
			Controls.Add(button1);
			Controls.Add(playerTurnText);
			Controls.Add(playerTurnLabel);
			Controls.Add(playerTurnPictureBox);
			Controls.Add(pictureBox1);
			Controls.Add(logoImage);
			Controls.Add(headingLabel);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "Game";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Game";
			WindowState = FormWindowState.Maximized;
			Load += Game_Load;
			((System.ComponentModel.ISupportInitialize)logoImage).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)playerTurnPictureBox).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private System.Windows.Forms.Label headingLabel;
		private System.Windows.Forms.PictureBox logoImage;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label playerTurnText;
		private System.Windows.Forms.PictureBox playerTurnPictureBox;
		private System.Windows.Forms.Label playerTurnLabel;
		private Button button1;
		private Button button2;
		private Button button3;
	}
}
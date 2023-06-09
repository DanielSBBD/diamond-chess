﻿namespace DiamondChess
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
      newGame = new Button();
      label1 = new Label();
      winLossRecordLabel = new Label();
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
      headingLabel.Location = new Point(139, 10);
      headingLabel.Margin = new Padding(0);
      headingLabel.Name = "headingLabel";
      headingLabel.Size = new Size(438, 127);
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
      logoImage.Location = new Point(10, 10);
      logoImage.Margin = new Padding(0);
      logoImage.Name = "logoImage";
      logoImage.Size = new Size(129, 127);
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
      pictureBox1.Location = new Point(1525, 10);
      pictureBox1.Margin = new Padding(0);
      pictureBox1.Name = "pictureBox1";
      pictureBox1.Size = new Size(129, 127);
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
      playerTurnText.Location = new Point(1232, 54);
      playerTurnText.Margin = new Padding(0);
      playerTurnText.Name = "playerTurnText";
      playerTurnText.RightToLeft = RightToLeft.No;
      playerTurnText.Size = new Size(123, 47);
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
      playerTurnPictureBox.Location = new Point(1039, 10);
      playerTurnPictureBox.Margin = new Padding(0);
      playerTurnPictureBox.Name = "playerTurnPictureBox";
      playerTurnPictureBox.Size = new Size(466, 127);
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
      playerTurnLabel.Location = new Point(1087, 54);
      playerTurnLabel.Margin = new Padding(0);
      playerTurnLabel.Name = "playerTurnLabel";
      playerTurnLabel.RightToLeft = RightToLeft.No;
      playerTurnLabel.Size = new Size(121, 47);
      playerTurnLabel.TabIndex = 7;
      playerTurnLabel.Text = "TO PLAY:      ";
      playerTurnLabel.TextAlign = ContentAlignment.MiddleRight;
      // 
      // newGame
      // 
      newGame.BackColor = Color.FromArgb(41, 76, 96);
      newGame.Cursor = Cursors.Hand;
      newGame.Font = new Font("Arial", 19.8F, FontStyle.Bold, GraphicsUnit.Point);
      newGame.ForeColor = Color.FromArgb(173, 182, 196);
      newGame.Location = new Point(10, 136);
      newGame.Margin = new Padding(0);
      newGame.Name = "newGame";
      newGame.Size = new Size(200, 49);
      newGame.TabIndex = 9;
      newGame.Text = "New Game";
      newGame.UseVisualStyleBackColor = false;
      newGame.Click += newGame_Click;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new Point(161, 98);
      label1.Name = "label1";
      label1.Size = new Size(358, 15);
      label1.TabIndex = 11;
      label1.Text = "Diamond chess is just like regular chess. Except its a diamond. Duh";
      // 
      // winLossRecordLabel
      // 
      winLossRecordLabel.AutoSize = true;
      winLossRecordLabel.Location = new Point(57, 188);
      winLossRecordLabel.Name = "winLossRecordLabel";
      winLossRecordLabel.Size = new Size(0, 15);
      winLossRecordLabel.TabIndex = 12;
      // 
      // Game
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.White;
      ClientSize = new Size(1663, 791);
      Controls.Add(winLossRecordLabel);
      Controls.Add(label1);
      Controls.Add(newGame);
      Controls.Add(playerTurnText);
      Controls.Add(playerTurnLabel);
      Controls.Add(playerTurnPictureBox);
      Controls.Add(pictureBox1);
      Controls.Add(logoImage);
      Controls.Add(headingLabel);
      FormBorderStyle = FormBorderStyle.FixedDialog;
      Icon = (Icon)resources.GetObject("$this.Icon");
      Margin = new Padding(3, 2, 3, 2);
      MaximizeBox = false;
      Name = "Game";
      StartPosition = FormStartPosition.CenterScreen;
      Text = "Game";
      Load += Game_Load;
      ((System.ComponentModel.ISupportInitialize)logoImage).EndInit();
      ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
      ((System.ComponentModel.ISupportInitialize)playerTurnPictureBox).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    public void ToggleTurnColour(bool toWhite)
    {
      if (toWhite)
      {
        playerTurnLabel.BackColor = Color.Black;
        playerTurnLabel.ForeColor = Color.White;
        playerTurnText.BackColor = Color.Black;
        playerTurnText.ForeColor = Color.White;
      }
      else
      {
        playerTurnLabel.BackColor = Color.Transparent;
        playerTurnLabel.ForeColor = SystemColors.ControlText;
        playerTurnText.BackColor = Color.Transparent;
        playerTurnText.ForeColor = SystemColors.ControlText;
      }
    }

    #endregion

    private System.Windows.Forms.Label headingLabel;
    private System.Windows.Forms.PictureBox logoImage;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Label playerTurnText;
    private System.Windows.Forms.PictureBox playerTurnPictureBox;
    private System.Windows.Forms.Label playerTurnLabel;
    private Button newGame;
    private Label label1;
    private Label winLossRecordLabel;
  }
}
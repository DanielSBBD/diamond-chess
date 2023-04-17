using System;
using System.Drawing;
using System.Windows.Forms;

namespace DiamondChess
{
	public partial class Game : Form
	{
		string username1, username2;
		public Game(string u1, string u2)
		{
			username1 = u1;
			username2 = u2;

			InitializeComponent();
		}

		private void Game_Load(object sender, EventArgs e)
		{
			playerTurnText.Text = username1;

			Grid grid = new Grid();
			int gridOffset = Height * 10 / 100;
			int gridSize = Height - gridOffset;
			grid.Size = new Size(gridSize, gridSize);
			grid.Location = new Point(Width / 2 - gridSize / 2, gridOffset / 2);
			Controls.Add(grid);

		}

		private void timeLabel_Click(object sender, EventArgs e)
		{

		}

		private void playerTurnText_Click(object sender, EventArgs e)
		{

		}

		private void headingLabel_Click(object sender, EventArgs e)
		{

		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			base.OnFormClosing(e);

			new Login().Show();
			Hide();
		}
	}
}

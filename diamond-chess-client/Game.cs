using System;
using System.Drawing;
using System.Windows.Forms;

namespace DiamondChess
{
	public partial class Game : Form
	{
		string username1, username2;
		Grid grid = new Grid();

		public Game(string u1, string u2)
		{
			username1 = u1;
			username2 = u2;

			InitializeComponent();
		}

		private void Game_Load(object sender, EventArgs e)
		{
			playerTurnText.Text = username1;

			int gridOffset = Height * 10 / 100;
			int gridSize = Height - gridOffset;

			grid.Size = new Size(gridSize, gridSize);
			grid.Location = new Point(Width / 2 - gridSize / 2, gridOffset / 2);
			Controls.Add(grid);
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			base.OnFormClosing(e);
			new Login().Show();
			Hide();
		}

		public void RedrawBoard()
		{
			//for (int i = 0; i < xPositions.GetLength(0); i++)
			//{
			//	for (int j = 0; j < yPositions.GetLength(0); j++)
			//	{

			//	}
			//}

		}

		Random random = new Random();
		private void button1_Click(object sender, EventArgs e)
		{
			List<int> xList = new List<int> { 1, 2, 3 };
			List<int> yList = new List<int> { 1, 2, 3 };

			grid.HighlightPieces(xList, yList);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			grid.RedrawStartPositions();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			grid.RemovePiece(0, 0);
		}
	}
}

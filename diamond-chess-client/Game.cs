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

			grid.Size = new Size(Width, Height);
			Controls.Add(grid);
		}

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
      base.OnFormClosing(e);
      new Login().Show();
      Hide();
    }

		private void button1_Click(object sender, EventArgs e)
		{
			grid.TakePiece(Properties.Resources.W_Queen, 0, 0, true);
		}

    private void button2_Click(object sender, EventArgs e)
    {
      grid.RedrawStartPositions();
    }

    private void button3_Click(object sender, EventArgs e)
    {
      // :(
    }
  }
}

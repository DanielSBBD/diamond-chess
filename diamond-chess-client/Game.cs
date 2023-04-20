using diamond_chess_server.Models;

namespace DiamondChess
{
  public partial class Game : Form
  {
    Player player1, player2;
    Grid grid = new Grid();
    bool whiteToPlay = false;

    public Game(Player player1, Player player2)
    {
      this.player1 = player1;
      this.player2 = player2;

      InitializeComponent();
    }

    private void Game_Load(object sender, EventArgs e)
    {
      playerTurnText.Text = player1.playerLogin.Username;

      winLossRecordLabel.Text = player1.playerLogin.Username + " W/L/D: " + player1.numWins + "/" + player1.numLosses + "/" + player1.numDraws + "\n" +
        player2.playerLogin.Username + " W/L/D: " + player2.numWins + "/" + player2.numLosses + "/" + player2.numDraws;

      int gridOffset = Height * 10 / 100;
      int gridSize = Height - gridOffset;

      grid.RaiseTurnChangeEvent += HandleTurnChangeEvent;

      grid.Size = new Size(gridSize, gridSize);
      grid.Location = new Point(Width / 2 - gridSize / 2, gridOffset / 2);
      Controls.Add(grid);
    }

    void HandleTurnChangeEvent(object sender, EventArgs e)
    {
      if (whiteToPlay)
      {
        playerTurnText.Text = player1.playerLogin.Username;
      }
      else
      {
        playerTurnText.Text = player2.playerLogin.Username;
      }
      whiteToPlay = !whiteToPlay;
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
      base.OnFormClosing(e);
      new Login().Show();
      Hide();
    }

    private void button2_Click(object sender, EventArgs e)
    {
      grid.RedrawStartPositions();
    }
  }
}

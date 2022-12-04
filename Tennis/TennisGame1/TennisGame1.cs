namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private readonly Player Player1;
        private readonly Player Player2;
        private readonly Umpire Umpire;

        public TennisGame1(string player1Name, string player2Name)
        {
            Player1 = new Player(player1Name, 0);
            Player2 = new Player(player2Name, 0);
            Umpire = new Umpire();
        }

        public void WonPoint(string playerName)
        {
            GetPlayerByName(playerName).ScoreAPoint();
        }

        public string GetScore()
        {
            return Umpire.GetScore(Player1, Player2).ReadScore();
        }

        private Player GetPlayerByName(string name)
        {
            return name == "player1" ? Player1 : Player2;
        }
    }
}


namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private readonly Player Player1;
        private readonly Player Player2;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.Player1 = new Player(player1Name, 0);
            this.Player2 = new Player(player2Name, 0);
        }

        public void WonPoint(string playerName)
        {
            GetPlayerByName(playerName).ScoreAPoint();
        }

        public string GetScore()
        {
            if (Player1.GetScore() == Player2.GetScore())
            {
                return EstablishDrawScore();
            }
            if (Player1.GetScore() >= 4 || Player2.GetScore() >= 4)
            {
                return EstablishEndGameScore();
            }
            return EstablishNormalScore();
        }

        private Player GetPlayerByName(string name)
        {
            return name == "player1" ? Player1 : Player2;
        }

        private string EstablishNormalScore()
        {
            return $"{GetScoreName(Player1.GetScore())}-{GetScoreName(Player2.GetScore())}";
        }

        private string EstablishEndGameScore()
        {
            var scoreDelta = Player1.GetScore() - Player2.GetScore();
            if (scoreDelta == 1) return "Advantage player1";
            if (scoreDelta == -1) return "Advantage player2";
            if (scoreDelta >= 2) return "Win for player1";
            return "Win for player2";
        }

        private string EstablishDrawScore()
        {
            return Player1.GetScore() switch
            {
                0 => "Love-All",
                1 => "Fifteen-All",
                2 => "Thirty-All",
                _ => "Deuce",
            };
        }

        private static string GetScoreName(int score)
        {
            return score switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                _ => "Forty",
            };
        }
    }
}


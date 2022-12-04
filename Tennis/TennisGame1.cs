namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int player1Score = 0;
        private int player2Score = 0;
        private string player1Name;
        private string player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                player1Score += 1;
            else
                player2Score += 1;
        }

        public string GetScore()
        {
            if (player1Score == player2Score)
            {
                return EstablishDrawScore();
            }
            if (player1Score >= 4 || player2Score >= 4)
            {
                return EstablishEndGameScore();
            }
            return EstablishNormalScore();
        }

        private string EstablishNormalScore()
        {
            return $"{GetScoreName(player1Score)}-{GetScoreName(player2Score)}";
        }


        private string EstablishEndGameScore()
        {
            var scoreDelta = player1Score - player2Score;
            if (scoreDelta == 1) return "Advantage player1";
            if (scoreDelta == -1) return "Advantage player2";
            if (scoreDelta >= 2) return "Win for player1";
            return "Win for player2";
        }

        private string EstablishDrawScore()
        {
            return player1Score switch
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


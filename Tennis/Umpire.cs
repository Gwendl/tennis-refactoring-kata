namespace Tennis
{
    sealed class Umpire
    {
        public string GetScore(Player player1, Player player2)
        {
            int player1Score = player1.GetScore();
            int player2Score = player2.GetScore();
            if (player1Score == player2Score)
            {
                return EstablishDrawScore(player1Score);
            }
            if (player1Score >= 4 || player2Score >= 4)
            {
                return EstablishEndGameScore(player1Score, player2Score);
            }
            return EstablishNormalScore(player1Score, player2Score);
        }

            private string EstablishNormalScore(int player1Score, int player2Score)
            {
                return $"{GetScoreName(player1Score)}-{GetScoreName(player2Score)}";
            }

            private string EstablishEndGameScore(int player1Score, int player2Score)
            {
                var scoreDelta = player1Score - player2Score;
                if (scoreDelta == 1) return "Advantage player1";
                if (scoreDelta == -1) return "Advantage player2";
                if (scoreDelta >= 2) return "Win for player1";
                return "Win for player2";
            }

            private string EstablishDrawScore(int score)
            {
                return score switch
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


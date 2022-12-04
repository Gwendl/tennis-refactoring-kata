namespace Tennis
{
    sealed class Umpire
    {
        public IScoreResult GetScore(Player player1, Player player2)
        {
            int player1Score = player1.GetScore();
            int player2Score = player2.GetScore();
            if (player1Score == player2Score)
            {
                return new TieScoreResult(player1Score, player2Score);
            }
            if (player1Score >= 4 || player2Score >= 4)
            {
                return new EndgameScoreResult(player1Score, player2Score);
            }
            return new NormalScoreResult(player1Score, player2Score);
        }
    }
}


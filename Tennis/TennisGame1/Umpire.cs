using System;

namespace Tennis
{
    sealed class Umpire
    {
        public IScoreResult GetScore(Player player1, Player player2)
        {
            if (player1.IsTieWith(player2))
            {
                return new TieScoreResult(player1.GetScore(), player2.GetScore());
            }
            if (APlayerHasWon(player1, player2))
            {
                return new WinScoreResult(player1.GetScore(), player2.GetScore());
            }
            if (IsAdvantageSituation(player1, player2))
            {
                return new AdvantageScoreResult(player1.GetScore(), player2.GetScore());
            }

            return new NormalScoreResult(player1.GetScore(), player2.GetScore());
        }

        private bool IsAdvantageSituation(Player player1, Player player2)
            => player1.GetScore() >= 4 || player2.GetScore() >= 4;

        private bool APlayerHasWon(Player player1, Player player2)
        {
            int scoreDelta = Math.Abs(player1.GetScore() - player2.GetScore());
            return IsAdvantageSituation(player1, player2) && scoreDelta >= 2;
        }
    }
}


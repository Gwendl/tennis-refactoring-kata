using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis
{
    interface IScoreResult
    {
        public string ReadScore();
    }

    public abstract class AScoreResult: IScoreResult
    {
        protected readonly int player1Score;
        protected readonly int player2Score;

        protected AScoreResult(int player1Score, int player2Score)
        {
            this.player1Score = player1Score;
            this.player2Score = player2Score;
        }

        public abstract string ReadScore();

        protected string GetScoreName(int score)
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

    sealed class TieScoreResult : AScoreResult
    {
        public TieScoreResult(int player1Score, int player2Score) : base(player1Score, player2Score)
        {
        }

        public override string ReadScore()
        {
            return player1Score switch
            {
                0 => "Love-All",
                1 => "Fifteen-All",
                2 => "Thirty-All",
                _ => "Deuce",
            };
        }
    }

    sealed class EndgameScoreResult : AScoreResult
    {
        public EndgameScoreResult(int player1Score, int player2Score) : base(player1Score, player2Score)
        {
        }

        public override string ReadScore()
        {
            var scoreDelta = player1Score - player2Score;
            if (scoreDelta == 1) return "Advantage player1";
            if (scoreDelta == -1) return "Advantage player2";
            if (scoreDelta >= 2) return "Win for player1";
            return "Win for player2";
        }
    }

    sealed class NormalScoreResult : AScoreResult
    {
        public NormalScoreResult(int player1Score, int player2Score) : base(player1Score, player2Score)
        {
        }

        public override string ReadScore()
        {
            return $"{GetScoreName(player1Score)}-{GetScoreName(player2Score)}";
        }
    }
}

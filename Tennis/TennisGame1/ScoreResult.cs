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

    internal abstract class AScoreResult: IScoreResult
    {
        protected readonly Player Player1;
        protected readonly Player Player2;

        public AScoreResult(Player player1, Player player2)
        {
            Player1 = player1;
            Player2 = player2;
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
        public TieScoreResult(Player player1, Player player2) : base(player1, player2)
        {
        }

        public override string ReadScore()
        {
            return Player1.GetScore() switch
            {
                0 => "Love-All",
                1 => "Fifteen-All",
                2 => "Thirty-All",
                _ => "Deuce",
            };
        }
    }

    sealed class AdvantageScoreResult : AScoreResult
    {
        public AdvantageScoreResult(Player player1, Player player2) : base(player1, player2)
        {
        }

        public override string ReadScore()
        {
            if (Player1.IsOnePointAheadOf(Player2))
            {
                return $"Advantage {Player1.Name}";
            }
            return $"Advantage {Player2.Name}";
        }
    }

    sealed class WinScoreResult : AScoreResult
    {
        public WinScoreResult(Player player1, Player player2) : base(player1, player2)
        {
        }

        public override string ReadScore()
        {
            if (Player1.IsAheadOf(Player2))
            {
                return $"Win for {Player1.Name}";
            }
            return $"Win for {Player2.Name}";
        }
    }

    sealed class NormalScoreResult : AScoreResult
    {
        public NormalScoreResult(Player player1, Player player2) : base(player1, player2)
        {
        }

        public override string ReadScore()
        {
            return $"{GetScoreName(Player1.GetScore())}-{GetScoreName(Player2.GetScore())}";
        }
    }
}

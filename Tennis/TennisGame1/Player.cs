namespace Tennis
{
    sealed class Player
    {
        public readonly string Name;
        private int Score;

        public Player(string name, int score)
        {
            Name = name;
            Score = score;
        }

        public void ScoreAPoint()
        {
            Score += 1;
        }

        public int GetScore() => Score;

        public bool IsTieWith(Player other) => Score == other.Score;

        public bool IsOnePointAheadOf(Player other) => Score - other.Score == 1;

        public bool IsAheadOf(Player other) => Score > other.Score;
    }
}


public class Player
    {
        private int totalScore;
        private int hintsRemaining;

        public int TotalScore => totalScore;
        public int HintsRemaining => hintsRemaining;

        public Player()
        {
            totalScore = 0;
            hintsRemaining = 3;
        }

        public void UpdateTotalScore(int score)
        {
            totalScore += score;
        }

        public void UseHint()
        {
            hintsRemaining--;
        }
    }
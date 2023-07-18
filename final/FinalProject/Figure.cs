public class HangmanFigure
    {
        private int incorrectGuesses;

        public void IncrementIncorrectGuesses()
        {
            incorrectGuesses++;
        }

        public int GetIncorrectGuesses()
        {
            return incorrectGuesses;
        }

        public bool IsHangmanComplete()
        {
            return incorrectGuesses >= 11;
        }
    }
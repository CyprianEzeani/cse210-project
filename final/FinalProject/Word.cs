public class HangmanWord
    {
        private string mysteryWord;
        private char[] visibleWord;
        private List<int> hiddenLetterIndices;
        private Random random;

        public int NumberOfLetters { get; private set; }

        public HangmanWord()
        {
            random = new Random();
        }

        public void SetNumberOfLetters(int numberOfLetters)
        {
            NumberOfLetters = numberOfLetters;
            visibleWord = new char[numberOfLetters];
            hiddenLetterIndices = new List<int>();
            for (int i = 0; i < numberOfLetters; i++)
            {
                visibleWord[i] = '_';
                hiddenLetterIndices.Add(i);
            }
        }

        public void SetMysteryWord(string word)
        {
            mysteryWord = word;
        }

        public bool CheckLetterGuess(char letterGuess)
        {
            bool isCorrectGuess = false;
            for (int i = 0; i < mysteryWord.Length; i++)
            {
                if (mysteryWord[i] == letterGuess)
                {
                    visibleWord[i] = letterGuess;
                    hiddenLetterIndices.Remove(i);
                    isCorrectGuess = true;
                }
            }
            return isCorrectGuess;
        }

        public bool IsWordComplete()
        {
            return hiddenLetterIndices.Count == 0;
        }

        public string GetVisibleWord()
        {
            return new string(visibleWord);
        }

        public string GetMysteryWord()
        {
            return mysteryWord;
        }

        public char GetRandomHiddenLetter()
        {
            int randomIndex = random.Next(hiddenLetterIndices.Count);
            int hiddenIndex = hiddenLetterIndices[randomIndex];
            return mysteryWord[hiddenIndex];
        }
    }
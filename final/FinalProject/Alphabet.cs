public class HangmanAlphabet
    {
        private List<char> availableLetters;

        public HangmanAlphabet()
        {
            availableLetters = new List<char>();
            for (char letter = 'A'; letter <= 'Z'; letter++)
            {
                availableLetters.Add(letter);
            }
        }

        public string GetAvailableLetters()
        {
            return new string(availableLetters.ToArray());
        }

        public bool IsLetterAvailable(char letter)
        {
            return availableLetters.Contains(letter);
        }

        public void RemoveLetter(char letter)
        {
            availableLetters.Remove(letter);
        }
    }
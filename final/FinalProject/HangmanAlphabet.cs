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
        return string.Join(" ", availableLetters);
    }

    public void RemoveLetter(char letter)
    {
        availableLetters.Remove(letter);
    }
}
public class HangmanFigure
{
    private List<string> hangmanParts;

    public HangmanFigure()
    {
        hangmanParts = new List<string>
        {
            "  ____\n |/   |\n |    \n |    \n |    \n_|_\n",
            "  ____\n |/   |\n |    O\n |    \n |    \n_|_\n",
            "  ____\n |/   |\n |    O\n |    |\n |    \n_|_\n",
            "  ____\n |/   |\n |    O\n |   /|\n |    \n_|_\n",
            "  ____\n |/   |\n |    O\n |   /|\\\n |    \n_|_\n",
            "  ____\n |/   |\n |    O\n |   /|\\\n |   / \n_|_\n",
            "  ____\n |/   |\n |    O\n |   /|\\\n |   / \\\n_|_\n",
            "  ____\n |/   |\n |    O\n |   /|\\\n |   / \\\n_|_\n",
            "  ____\n |/   |\n |    O\n |   /|\\\n |   /\n_|_\n",
            "  ____\n |/   |\n |    O\n |   /|\\\n |\n_|_\n",
            "  ____\n |/   |\n |    O\n |   /|\n |\n_|_\n",
            "  ____\n |/   |\n |    O\n |    |\n |\n_|_\n",
            "  ____\n |/   |\n |    O\n |\n |\n_|_\n",
            "  ____\n |/   |\n |\n |\n |\n_|_\n",
            "  ____\n |/\n |\n |\n |\n_|_\n",
            "  \n |\n |\n |\n |\n_|_\n",
            "\n\n\n\n\n\n\n"
        };
    }

    public void DisplayHangman(int incorrectGuesses)
    {
        Console.WriteLine(hangmanParts[incorrectGuesses]);
    }
}
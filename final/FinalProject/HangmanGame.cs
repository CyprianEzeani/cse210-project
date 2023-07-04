using System;
using System.Collections.Generic;
using System.Linq;

public class HangmanGame
{
    private const int MaxIncorrectGuesses = 11;
    private const int Game1PartScore = 3;
    private const int Game2PartScore = 5;
    private const int Level2Bonus = 5;
    private const int Level3Bonus = 15;

    private HangmanAlphabet alphabet;
    private HangmanFigure hangmanFigure;
    private HangmanScorer scorer;
    private string selectedCategory;
    private int numberOfLetters;
    private int incorrectGuesses;
    private int score;

    private Dictionary<string, List<string>> wordDictionary;

    public HangmanGame(Dictionary<string, List<string>> wordDictionary)
    {
        alphabet = new HangmanAlphabet();
        hangmanFigure = new HangmanFigure();
        scorer = new HangmanScorer(Game1PartScore, Game2PartScore, Level2Bonus, Level3Bonus);
        this.wordDictionary = wordDictionary;
    }

    public void StartGame()
    {
        while (true)
        {
            Console.WriteLine("Waking up the game: If no buttons are pressed for one minute, the game will go into “Sleep Mode”.");
            Console.WriteLine("To “Wake-Up” the game, press ON/NEW.");
            Console.WriteLine("Starting a New Game: Press and Hold ON/NEW.");

            int gameChoice = GetGameChoice();

            if (gameChoice == 1)
            {
                bool isCategoryEnabled = SelectCategory();
                numberOfLetters = SelectNumberOfLetters();
                string mysteryWord = GenerateMysteryWord(numberOfLetters);

                PlayGame(mysteryWord, isCategoryEnabled);
            }
            else if (gameChoice == 2)
            {
                numberOfLetters = SelectNumberOfLetters();
                string mysteryWord = GenerateMysteryWord(numberOfLetters);

                PlayGame(mysteryWord, false);
            }
            else
            {
                Console.WriteLine("Invalid game choice. Please try again.");
            }
        }
    }

    private int GetGameChoice()
    {
        Console.WriteLine("Press 1 for Game 1 or 2 for Game 2:");
        char choice = GetCharChoice(new[] { '1', '2' });
        Console.Clear();
        return int.Parse(choice.ToString());
    }

    private char GetCharChoice(char[] validChoices)
    {
        char choice;

        while (true)
        {
            bool isValidChoice = char.TryParse(Console.ReadLine(), out choice);

            if (isValidChoice && validChoices.Contains(choice))
            {
                return choice;
            }

            Console.WriteLine("Invalid choice. Please try again.");
        }
    }

    private bool SelectCategory()
    {
        Console.WriteLine("Select Category:");
        Console.WriteLine("1. Animals");
        Console.WriteLine("2. Music");
        Console.WriteLine("3. Beach");
        Console.WriteLine("4. Party");
        Console.WriteLine("5. City");
        Console.WriteLine("6. School");
        Console.WriteLine("7. Grocery");
        Console.WriteLine("8. Sports");
        Console.WriteLine("9. Leisure");
        Console.WriteLine("10. (Wild) West");

        int categoryChoice = GetNumericChoice(1, 10);
        Console.Clear();

        selectedCategory = GetCategoryName(categoryChoice);

        return true;
    }

    private int GetNumericChoice(int min, int max)
    {
        int choice;

        while (true)
        {
            bool isValidChoice = int.TryParse(Console.ReadLine(), out choice);

            if (isValidChoice && choice >= min && choice <= max)
            {
                return choice;
            }

            Console.WriteLine("Invalid choice. Please try again.");
        }
    }

    private string GetCategoryName(int categoryChoice)
    {
        switch (categoryChoice)
        {
            case 1:
                return "Animals";
            case 2:
                return "Music";
            case 3:
                return "Beach";
            case 4:
                return "Party";
            case 5:
                return "City";
            case 6:
                return "School";
            case 7:
                return "Grocery";
            case 8:
                return "Sports";
            case 9:
                return "Leisure";
            case 10:
                return "(Wild) West";
            default:
                return null;
        }
    }

    private int SelectNumberOfLetters()
    {
        Console.WriteLine("Select the number of letters (3-7):");
        int numberOfLetters = GetNumericChoice(3, 7);
        Console.Clear();
        return numberOfLetters;
    }

    private string GenerateMysteryWord(int numberOfLetters)
    {
        List<string> wordList = selectedCategory != null && wordDictionary.ContainsKey(selectedCategory)
            ? wordDictionary[selectedCategory]
            : wordDictionary.Values.SelectMany(x => x).ToList();

        List<string> wordsWithMatchingLength = wordList.Where(word => word.Length == numberOfLetters).ToList();

        if (wordsWithMatchingLength.Count == 0)
        {
            Console.WriteLine("No words found with the selected length. Generating a random word from the dictionary.");
            Random random = new Random();
            int randomIndex = random.Next(wordList.Count);
            return wordList[randomIndex];
        }

        Random rand = new Random();
        int index = rand.Next(wordsWithMatchingLength.Count);
        return wordsWithMatchingLength[index];
    }

    private void PlayGame(string mysteryWord, bool isCategoryEnabled)
    {
        incorrectGuesses = 0;
        score = 0;

        char[] mysteryWordArray = mysteryWord.ToCharArray();
        char[] hiddenWordArray = new char[mysteryWordArray.Length];
        Array.Fill(hiddenWordArray, '_');

        while (true)
        {
            Console.WriteLine("Mystery Word: " + string.Join(" ", hiddenWordArray));
            Console.WriteLine("Available Letters: " + alphabet.GetAvailableLetters());
            Console.WriteLine("Enter a letter:");

            char letter = GetCharChoice(alphabet.GetAvailableLetters().ToCharArray());

            alphabet.RemoveLetter(letter);
            Console.Clear();

            bool isCorrectGuess = false;

            for (int i = 0; i < mysteryWordArray.Length; i++)
            {
                if (mysteryWordArray[i] == letter)
                    isCorrectGuess = true;
                }
            }

            if (!isCorrectGuess)
            {
                incorrectGuesses++;
                hangmanFigure.DisplayHangman(incorrectGuesses);
            }

            if (hiddenWordArray.SequenceEqual(mysteryWordArray))
            {
                Console.WriteLine("Congratulations! You guessed the word: " + mysteryWord);
                score = scorer.CalculateScore(incorrectGuesses, numberOfLetters, isCategoryEnabled, selectedCategory);
                Console.WriteLine("Score: " + score);
                break;
            }

            if (incorrectGuesses == MaxIncorrectGuesses)
            {
                Console.WriteLine("Oops! You couldn't guess the word. The correct word was: " + mysteryWord);
                score -= 25;
                Console.WriteLine("Score: " + score);
                break;
            }
        }

        Console.WriteLine("Game Over");
    }
           {
                    hiddenWordArray[i] = letter;
}
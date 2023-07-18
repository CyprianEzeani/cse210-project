using System;
using System.Collections.Generic;

namespace HangmanGame
{
    public class HangmanGame
    {
        private HangmanCategory hangmanCategory;
        private WordGenerator wordGenerator;
        private HangmanFigure hangmanFigure;
        private HangmanWord hangmanWord;
        private HangmanAlphabet hangmanAlphabet;
        private HangmanScorer hangmanScorer;
        private Player player;

        public void StartGame()
        {
            Console.WriteLine("Welcome to Hangman Game!");

            // Initialize the game components
            hangmanCategory = new HangmanCategory();
            wordGenerator = new WordGenerator();
            hangmanFigure = new HangmanFigure();
            hangmanWord = new HangmanWord();
            hangmanAlphabet = new HangmanAlphabet();
            hangmanScorer = new HangmanScorer();
            player = new Player();

            // Get user input for game settings
            SelectGame();
            SelectSkillLevel();
            if (hangmanCategory.CategoryEnabled)
                SelectCategory();
            SelectNumberOfLetters();

            // Generate the mystery word
            string mysteryWord = wordGenerator.GenerateWord(hangmanCategory.SelectedCategory, hangmanWord.NumberOfLetters);
            hangmanWord.SetMysteryWord(mysteryWord);

            bool isGameFinished = false;
            while (!isGameFinished)
            {
                // Display game state
                Console.Clear();
                DisplayGameState();

                // Get user input for action (guess or hint)
                HangmanAction action = GetPlayerAction();

                if (action == HangmanAction.Guess)
                {
                    // Get user input for letter guess
                    char guessedLetter = GetLetterGuess();

                    // Check if letter is correct or incorrect
                    bool isCorrectGuess = hangmanWord.CheckLetterGuess(guessedLetter);
                    if (isCorrectGuess)
                    {
                        if (hangmanWord.IsWordComplete())
                        {
                            isGameFinished = true;
                            Console.WriteLine("Congratulations! You guessed the word correctly!");
                        }
                    }
                    else
                    {
                        // Update hangman figure
                        hangmanFigure.IncrementIncorrectGuesses();

                        if (hangmanFigure.IsHangmanComplete())
                        {
                            isGameFinished = true;
                            Console.WriteLine("Oops! You failed to guess the word. Game Over!");
                        }
                    }
                }
                else if (action == HangmanAction.Hint)
                {
                    // Use hint
                    if (player.HintsRemaining > 0)
                    {
                        char hintLetter = hangmanWord.GetRandomHiddenLetter();
                        Console.WriteLine($"Hint: The mystery word contains the letter '{hintLetter}'.");
                        player.UseHint();
                    }
                    else
                    {
                        Console.WriteLine("You have used all your hints!");
                    }

                    Console.WriteLine("Press ENTER to continue...");
                    Console.ReadLine();
                }
            }

            // Calculate score and display game over screen
            int score = hangmanScorer.CalculateScore(hangmanFigure.GetIncorrectGuesses(), hangmanWord.NumberOfLetters, hangmanWord.IsWordComplete(), hangmanCategory.CategoryEnabled, hangmanCategory.SelectedCategory);
            Console.WriteLine($"Game Over! The mystery word was: {hangmanWord.GetMysteryWord()}");
            Console.WriteLine($"Score: {score}");

            // Update player's total score
            player.UpdateTotalScore(score);

            // Display player's total score
            Console.WriteLine($"Total Score: {player.TotalScore}");

            // Restart the game or exit
            Console.WriteLine("Press ENTER to play again or any other key to exit.");
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
                StartGame();
        }

        private void SelectGame()
        {
            Console.WriteLine("Select a game: ");
            Console.WriteLine("1. Regular Hangman Play");
            Console.WriteLine("2. Scrambled Words");
            Console.Write("Enter your choice (1 or 2): ");

            int gameChoice;
            while (!int.TryParse(Console.ReadLine(), out gameChoice) || (gameChoice != 1 && gameChoice != 2))
            {
                Console.Write("Invalid input. Please enter 1 or 2: ");
            }

            if (gameChoice == 2)
            {
                // Game 2 selected
                Console.WriteLine("Game 2 - Scrambled Words");
            }
            else
            {
                // Default to Game 1
                Console.WriteLine("Game 1 - Regular Hangman Play");
            }
        }

        private void SelectSkillLevel()
        {
            Console.WriteLine("Select a skill level: ");
            Console.WriteLine("1. Level 1");
            Console.WriteLine("2. Level 2");
            Console.WriteLine("3. Level 3");
            Console.Write("Enter your choice (1, 2, or 3): ");

            int skillLevel;
            while (!int.TryParse(Console.ReadLine(), out skillLevel) || (skillLevel != 1 && skillLevel != 2 && skillLevel != 3))
            {
                Console.Write("Invalid input. Please enter 1, 2, or 3: ");
            }

            hangmanScorer.SetSkillLevel(skillLevel);
        }

        private void SelectCategory()
        {
            Console.WriteLine("Select a category: ");
            List<string> categories = hangmanCategory.GetCategories();
            for (int i = 0; i < categories.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {categories[i]}");
            }
            Console.Write("Enter your choice (1-10): ");

            int categoryChoice;
            while (!int.TryParse(Console.ReadLine(), out categoryChoice) || (categoryChoice < 1 || categoryChoice > categories.Count))
            {
                Console.Write("Invalid input. Please enter a number between 1 and 10: ");
            }

            hangmanCategory.SetSelectedCategory(categoryChoice - 1);
        }

        private void SelectNumberOfLetters()
        {
            Console.WriteLine("Select the number of letters (3-7): ");

            int numberOfLetters;
            while (!int.TryParse(Console.ReadLine(), out numberOfLetters) || (numberOfLetters < 3 || numberOfLetters > 7))
            {
                Console.Write("Invalid input. Please enter a number between 3 and 7: ");
            }

            hangmanWord.SetNumberOfLetters(numberOfLetters);
        }

        private char GetLetterGuess()
        {
            Console.WriteLine($"Available letters: {hangmanAlphabet.GetAvailableLetters()}");
            Console.Write("Enter a letter guess: ");

            char letterGuess;
            while (!char.TryParse(Console.ReadLine().ToUpper(), out letterGuess) || !char.IsLetter(letterGuess) || !hangmanAlphabet.IsLetterAvailable(letterGuess))
            {
                Console.Write("Invalid input. Please enter an available letter: ");
            }

            hangmanAlphabet.RemoveLetter(letterGuess);
            return letterGuess;
        }

        private HangmanAction GetPlayerAction()
        {
            Console.WriteLine("Choose an action: ");
            Console.WriteLine("1. Guess a letter");
            Console.WriteLine("2. Use a hint");
            Console.Write("Enter your choice (1 or 2): ");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2))
            {
                Console.Write("Invalid input. Please enter 1 or 2: ");
            }

            return (HangmanAction)choice;
        }

        private void DisplayGameState()
        {
            Console.WriteLine($"Category: {hangmanCategory.GetSelectedCategory()}");
            Console.WriteLine($"Mystery Word: {hangmanWord.GetVisibleWord()}");
            Console.WriteLine($"Incorrect Guesses: {hangmanFigure.GetIncorrectGuesses()}");
            Console.WriteLine($"Hints Remaining: {player.HintsRemaining}");
        }
    }

    public enum HangmanAction
    {
        Guess = 1,
        Hint = 2
    }
}
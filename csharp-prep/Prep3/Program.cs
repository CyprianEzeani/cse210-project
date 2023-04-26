 using System;

    class GuessMyNunberGame {
        static void Main() {

          do {
            int magicNumber = new Random().Next(1, 100);
            int guessCount = 0;

            Console.WriteLine("I'm thinking of a number between 1 and 100. Can you guess it?");

            while (true) {
                Console.WriteLine("Enter your guess: ");
                int guess = Convert.ToInt32(Console.ReadLine());

                guessCount++;

                if (guess < magicNumber) {
                    Console.WriteLine("Too low! Guess higher next time.");
                } else if (guess > magicNumber) {
                    Console.WriteLine("Too high! Guess lower next time.");

                } else {
                    Console.WriteLine("Congratulations! You guessed the magic number in {0} guesses.", guessCount);
                    break;


                }

            } 

            Console.WriteLine("Do you want to play again? (yes/no): ");

        } while (Console.ReadLine().ToLower() == "yes");

    }

 }

    

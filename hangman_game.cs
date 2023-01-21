using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace hangmanGame
{
    internal class Program
    {
        const int USER_LIVES = 15;

        static void Main(string[] args)
        {
            string[] wordsArray = { "property", "departure", "disk", "possession", "assignment", "goal", "year", "impression", "university", "information",
                "operation", "piano", "county", "woman", "negotiation", "son", "thing", "girl", "sympathy", "volume", "mood", "funeral", "administration",
                "economics", "role" };

            Random randomNumber = new Random();
            string playOrNo = "x";
            string userGuess;

            do
            {
                Console.Clear();

                int userLives = USER_LIVES;

                int wordIndex = randomNumber.Next(wordsArray.Length);
                string secretWord = wordsArray[wordIndex];

                StringBuilder guessingString = new StringBuilder(secretWord.Length);
                guessingString.Append('_', secretWord.Length);

                List<string> wrongGuesses = new List<string>();

                Console.WriteLine($"Hello user!\nThis is a hangman game. The program lets you guess the letters in a randomly chosen word.\n" +
                $"You have {userLives} wrong guesses untill the noose tightens and you loose the game!\n" +
                $"You can't use whitespace as input and you can only input one letter at a time. Have fun!");

                while (!guessingString.Equals(secretWord) && userLives > 1)
                {
                    Console.WriteLine("Please enter your guess and press enter: ");

                    userGuess = Console.ReadLine().ToLower();

                    if (wrongGuesses.Contains(userGuess))
                    {
                        Console.WriteLine("You already tried that!");
                        continue;
                    }
                    else if (secretWord.Contains(userGuess))
                    {
                        for (int i = 0; i < secretWord.Length; i++)
                        {
                            if (userGuess.StartsWith(secretWord[i]))
                            {
                                guessingString.Replace("_", userGuess, i, 1);
                            }
                        }
                    }
                    else if (String.IsNullOrWhiteSpace(userGuess) || userGuess.Length > 1)
                    {
                        Console.WriteLine("Wrong input, try again!");
                        continue;
                    }
                    else
                    {
                        userLives--;
                        wrongGuesses.Add(userGuess);
                        Console.WriteLine($"Wrong answer! You have {userLives} lives left.");
                    }

                    Console.Write($"Your guess: {guessingString}\nWrong guesses: ");
                    Console.WriteLine(string.Join(", ", wrongGuesses));
                }

                if (guessingString.Equals(secretWord))
                {
                    Console.WriteLine($"Congratulations! you guessed it.");
                }
                else
                {
                    Console.WriteLine($"Sorry, you lost!\nThe right answer was {secretWord}.");
                }

                Console.WriteLine("Do you want to play again? Type 'y' for yes and anything else for no, then press enter.");
                playOrNo = Console.ReadLine().ToLower();

            } while (playOrNo.Contains("y"));
        }
    }
}
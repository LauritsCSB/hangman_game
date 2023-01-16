using System.Text;

namespace hangmanGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            The program runs by generating a random number and using that to pick a word from the array at a random index.
            As long as the "empty" guessing string isn't equal to the word pick from the array, the while loop runs.
            If the user runs out of lives or if the word is guessed correctly, the while loop breaks.
            A feature was added to check for whitespace and multiple characters in the same input, this wont be taken as a
            wrong answer and the user gets a second chance.
            */

            string[] wordsArray = { "property", "departure", "disk", "possession", "assignment", "goal", "year", "impression", "university", "information",
                "operation", "piano", "county", "woman", "negotiation", "son", "thing", "girl", "sympathy", "volume", "mood", "funeral", "administration",
                "economics", "role" };

            int userLives = 15;
            Random randomNumber = new Random();
            int wordIndex = randomNumber.Next(wordsArray.Length);
            string secretWord = wordsArray[wordIndex];

            string userGuess = string.Empty;

            StringBuilder guessingString = new StringBuilder(secretWord.Length);
            foreach (char i in secretWord)
            {
                guessingString.Append("_");
            }

            Console.WriteLine($"Hello user!\nThis is a hangman game. The program lets you guess the letters in a randomly chosen word.\n" +
                $"You have {userLives} wrong guesses untill the noose tightens and you loose the game!\n" +
                $"You can't use whitespace as input and you can only input one letter at a time. Have fun!");

            while (!guessingString.Equals(secretWord))
            {
                Console.WriteLine("Please enter your guess and press enter: ");
                userGuess = Console.ReadLine().ToLower();
                Console.Clear();

                if (secretWord.Contains(userGuess))
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
                }
                else
                {
                    userLives--;
                    Console.WriteLine($"Wrong answer! You have {userLives} lives left.");
                }


                if (userLives < 1)
                {
                    Console.WriteLine($"Sorry, you lost!\nThe right answer was {secretWord}.");
                    break;
                }

                Console.WriteLine($"Your guess: {guessingString}");
            }

            if (guessingString.Equals(secretWord))
            {
                Console.WriteLine($"Congratulations! you guessed it.\nThe right word was {secretWord}.");
            }
        }
    }
}
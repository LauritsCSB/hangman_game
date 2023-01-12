using System;
using System.Text;
using System.Runtime.InteropServices;

namespace hangmanGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            My idea is to initialize and array of strings and use the random class to pick an element and make the user guess the letters in the string (word).
            I wanted a relatively large selection of randomly generated words to increase the challenge when playing the game. I chose to write out the array
            containing every string instead of initializing and empty array and append elements afterwards, i guess this makes it kind of hard to edit the
            selection, but its easier to read.
            */
            string[] wordsArray = { "property", "departure", "disk", "possession", "assignment", "goal", "year", "impression", "university", "information",
                "operation", "piano", "county", "woman", "negotiation", "son", "thing", "girl", "sympathy", "volume", "mood", "funeral", "administration",
                "economics", "role" };

            int userLives = 15;
            Random randomNumber = new Random();
            int wordIndex = randomNumber.Next(wordsArray.Length);
            string secretWord = wordsArray[wordIndex];

            string userGuess = string.Empty;
            string askForInput = "Please enter your guess and press enter: ";
            string wrongInput = "Wrong input, try again!";

            StringBuilder guessingString = new StringBuilder(secretWord.Length);
            foreach (char i in secretWord)
            {
                guessingString.Append("_");
            }
            
            Console.WriteLine($"Hello user!\nThis is a hangman game. The program lets you guess the letters in a randomly chosen word.\n" +
                $"You have {userLives} wrong guesses untill the noose tightens and you loose the game!\n" +
                $"You can't use whitespace as input and you can only input one letter at a time. Have fun!");

            while (guessingString.Equals(secretWord) == false)
            {
                Console.WriteLine(askForInput);
                Console.WriteLine(secretWord);
                userGuess = Console.ReadLine();
                Console.Clear();
                userGuess = userGuess.ToLower();

                if (guessingString.Equals(secretWord))
                {
                    Console.WriteLine($"Congratulations! you guessed it.\nThe right word was {secretWord}.");
                    break;
                }

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
                    Console.WriteLine(wrongInput);
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

                Console.WriteLine(guessingString);
            }
        }
    }
}
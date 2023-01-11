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

            Random randomNumber = new Random();
            int wordIndex = randomNumber.Next(wordsArray.Length);
            string secretWord = wordsArray[wordIndex];
            string userGuess = string.Empty;
            string askForInput = "Please enter your guess and press enter: ";
            int userLives = 10;

            StringBuilder guessingString = new StringBuilder(secretWord.Length);

            foreach (char i in secretWord)
            {
                guessingString.Append("_");

            }
            
            Console.WriteLine($"Hello user!\nThis is a hangman game. The program lets you guess the letters in a randomly chosen word.\n" +
                $"You have {userLives} wrong guesses untill the noose tightens and you loose the game!");
            //TODO Figure this shit out!!!
            //The program has to loop through every character of the word and check if it's equal to the user input, if yes, replace
            while (checkerString.Contains("_") || userLives < 1)
            {
                string checkerString = guessingString.ToString();

                Console.WriteLine(askForInput);
                userGuess = Console.ReadLine();
                userGuess = userGuess.ToLower();

                for (int i = 0; i >= secretWord.Length; i++)
                {
                    if (secretWord.Contains(userGuess)
                    {
                        guessingString.Replace("_", userGuess);
                    }
                }

                if (secretWord.Contains(userGuess))
                {
                    guessingString[secretWord.IndexOf(userGuess)] = userGuess;
                    guessingString.Insert(secretWord.IndexOf(userGuess), userGuess);
                    guessingString.Remove(secretWord.IndexOf(userGuess) + 1, 1);
                    //guessingString.Replace("_", userGuess, secretWord.IndexOf(userGuess), 1);
                }
                else if (String.IsNullOrWhiteSpace(userGuess))
                {
                    Console.WriteLine("There's no whitespace in the word");
                }
                else if (userGuess.Length > 1)
                {
                    Console.WriteLine("You can only enter one letter at a time");
                }
                else
                {
                    userLives--;
                }

            Console.WriteLine(guessingString);
            }
        }
    }
}
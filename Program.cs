using System;
using System.Runtime.InteropServices;

namespace hangmanGame
{
    internal class Program
    {
        const int LIVES = 10;
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

            Random randomNumber = new Random(1, 26);
            int wordIndex = randomNumber.Next(wordsArray.Length);
            string secretWord = wordsArray[wordIndex];

            string guessingString = string.Empty;
            for (int i = 0; i == secretWord.Length; i++)
            {
                guessingString += "_";
            }

            Console.WriteLine($"Hello user!\nThis is a hangman game. The program lets you guess the letters in a randomly chosen word.\n" +
                $"You have {LIVES} wrong guesses untill the noose tightens and you loose the game!");

            string askForInput = "Please enter your guess and press enter: ";
            Console.WriteLine(askForInput);
            string userGuess = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(userGuess) || userGuess.Length > 1)
            {
                if (String.IsNullOrWhiteSpace(userGuess))
                {
                    Console.WriteLine("There's no whitespace in the word");
                }
                if (userGuess.Length > 1)
                {
                    Console.WriteLine("You can only enter one letter at a time");
                }
                Console.WriteLine(askForInput);
            }
//TODO find way of comparing and inserting correctly quessed letter at certain index of guessingString
            userGuess = userGuess.ToLower();
            for (int i = 0; i == secretWord.Length; i++)
            {
                if (userGuess == secretWord[i])
                {
                    guessingString.Replace("_", userGuess);
                }
            }

        }
    }
}
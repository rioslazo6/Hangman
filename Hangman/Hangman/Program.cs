using System;
using System.Collections.Generic;

namespace Hangman
{
    class Program
    {
        static void Main()
        {
            // Defining list of words
            List<string> wordsList = new List<string> { "CABBAGE", "TOMORROW", "CEILING", "HAMSTER", "DIME", "UNIQUE", "TRIGGER", "HORIZONTAL", "COCOA", "IMPOSSIBLE" };

            // Generating random number to choose word from the list
            Random random = new Random();
            int selected = random.Next(0, 9);
            string selectedWord = wordsList[selected];

            // Keeping controls of letters that have been guessed in a list
            List<char> guessedLetters = new List<char> { };
 
            // Grabbing length of selected word, creating an array to display the correctly guessed letters
            int length = selectedWord.Length;
            string[] word = new string[length * 2];

            // To keep control of pending letters to guess, attempts, and letters that match
            int pending = length;
            int attempts = 0, failedAttempts = 0, correctAttempts = 0;
            int matches;
            
            // Filling up with underscores for each letter of the word, separated by spaces
            for (int i = 0; i < length; i++)
            {
                word[(2 * i)] = "_";
                word[(2 * i) + 1] = " ";
            }

            // Showing gallows for the first time
            showHangman(failedAttempts);
            Console.WriteLine();

            // Showing the word (all underscores at first)
            Console.Write("Word: ");
            foreach (string s in word)
            {
                Console.Write(s);
            }
            Console.WriteLine();

            bool done = false;
            // As long as done = false, the program will keep asking for letters to be guessed
            while(!done)
            {
                matches = 0;
                
                // Reading a key, converting to uppercase for consistency
                Console.WriteLine("\nGuess a letter:");
                char input = char.ToUpper(Console.ReadKey().KeyChar);

                // The program will only continue if the entered letter doesn't exist in the guessedLetters list
                if (!guessedLetters.Contains(input))
                {
                    attempts++;

                    Console.Clear();

                    for (int i = 0; i < length; i++)
                    {
                        // Looping through the selected word, if the entered key matches the
                        // character in that position, it's saved in the word array to be displayed
                        if (input == selectedWord[i])
                        {
                            word[2 * i] = input.ToString();
                            pending--;
                            matches++;
                        }
                    }

                    guessedLetters.Add(input);

                    // Keeping control of correct and failed attempts
                    if (matches > 0)
                    {
                        correctAttempts++;
                    }
                    else
                    {
                        failedAttempts++;
                    }

                    // Showing updated gallows after guessing a letter
                    showHangman(failedAttempts);
                    Console.WriteLine();

                    // Showing updated word; if any letters were guessed, those will appear,
                    // and the pending ones will still be shown as underscores
                    Console.Write("Word: ");
                    foreach (string s in word)
                    {
                        Console.Write(s);
                    }
                    Console.WriteLine();
                    Console.WriteLine();

                    // Showing letters that have been attempted
                    Console.Write("Letters you've tried so far: ");
                    foreach (char c in guessedLetters)
                    {
                        Console.Write(c + " ");
                    }
                    Console.WriteLine();
                    Console.WriteLine();

                    // Showing total attempts, correct and incorrect
                    Console.WriteLine("Number of attempts: " + attempts);
                    Console.WriteLine("Correct attempts: " + correctAttempts);
                    Console.WriteLine("Incorrect attempts: " + failedAttempts);

                    if (pending <= 0)
                    {
                        // Once there are no pending letters to be guessed, the user won (W)
                        gameOver('W');
                    }

                    if (failedAttempts > 5)
                    {
                        // This was not in the requirements but I added it for fun, instead of going on forever,
                        // once the user has failed more than 5 times, they lost (L), as there are no more body parts to add
                        gameOver('L');
                    }
                }
                // If the entered letter is already in the guessedLetters list, the program will ask for a different one
                else
                {
                    Console.WriteLine("\nYou've already entered that one, try something different!");
                }
            }

            // Shows the welcome message and the gallows with the body parts
            void showHangman(int failed)
            {
                Console.WriteLine("* Welcome to  H A N G M A N *\n");
                Console.WriteLine("The word you're looking for has " + length + " letters.\n");
                switch (failed)
                {
                    // Showing the gallows, adding different body parts depending on how many failed attempts there are
                    case 0:
                        Console.WriteLine("------ ");
                        Console.WriteLine("|    | ");
                        Console.WriteLine("|      ");
                        Console.WriteLine("|      ");
                        Console.WriteLine("|      ");
                        Console.WriteLine("|      ");
                        break;
                    case 1:
                        Console.WriteLine("------ ");
                        Console.WriteLine("|    | ");
                        Console.WriteLine("|    O ");
                        Console.WriteLine("|      ");
                        Console.WriteLine("|      ");
                        Console.WriteLine("|      ");
                        break;
                    case 2:
                        Console.WriteLine("------ ");
                        Console.WriteLine("|    | ");
                        Console.WriteLine("|    O ");
                        Console.WriteLine("|    | ");
                        Console.WriteLine("|      ");
                        Console.WriteLine("|      ");
                        break;
                    case 3:
                        Console.WriteLine("------ ");
                        Console.WriteLine("|    | ");
                        Console.WriteLine("|    O ");
                        Console.WriteLine("|   /| ");
                        Console.WriteLine("|      ");
                        Console.WriteLine("|      ");
                        break;
                    case 4:
                        Console.WriteLine("------ ");
                        Console.WriteLine("|    | ");
                        Console.WriteLine("|    O ");
                        Console.WriteLine("|   /|\\");
                        Console.WriteLine("|      ");
                        Console.WriteLine("|      ");
                        break;
                    case 5:
                        Console.WriteLine("------ ");
                        Console.WriteLine("|    | ");
                        Console.WriteLine("|    O ");
                        Console.WriteLine("|   /|\\");
                        Console.WriteLine("|   /  ");
                        Console.WriteLine("|      ");
                        break;
                    default:
                        Console.WriteLine("------ ");
                        Console.WriteLine("|    | ");
                        Console.WriteLine("|    O ");
                        Console.WriteLine("|   /|\\");
                        Console.WriteLine("|   / \\");
                        Console.WriteLine("|      ");
                        break;
                }
            }
            
            // Shows a message once the game ends, and asks the user if they want to play again
            void gameOver(char r)
            {
                // Changing the value of done to true, so the while loop will stop
                done = true;
                
                // Congratulating the user if they won (W), revealing the correct word otherwise
                if (r == 'W')
                {
                    Console.WriteLine("\n* C O N G R A T U L A T I O N S *\n");
                    Console.WriteLine("You guessed it! You won!\n");
                }
                else
                {
                    Console.WriteLine("\n* G A M E   O V E R *\n");
                    Console.WriteLine("Sorry! You're dead :(\n\nThe word was: " + selectedWord + ".\n");
                }
                // Asking to play again
                Console.WriteLine("Wanna try again? (press 'Y' to continue, or any other key to exit)");
                char keepPlaying = char.ToUpper(Console.ReadKey().KeyChar);
                if (keepPlaying == 'Y')
                {
                    // Restarting the game
                    Console.Clear();
                    Main();
                }
                else
                {
                    Console.WriteLine("\n\nThanks for playing!\n");
                }
            }
        }
    }
}

using System;

namespace WordGuessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                FileSetup();
                Home();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye!");
            }
        }
        static void Home()
        {
            // intro screen
            // user interface/selection
                // CRUD words to file
        }
        static void FileSetup()
        {
            // check for file
            // if no file, create
            // if file, load
        }
        static void Play()
        {
            // load words from file and select random
            // while true loop guessing
            // track guesses
            // completion event!!
            // play again ? play : home/exit
        }
        static void ViewWords()
        {
            // io
        }
        static void AddWords()
        {
            // io
        }
        static void RemoveWord()
        {
            // io
        }
    }
}

using System;
using System.IO;

namespace WordGuessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] wordBank = FileSetup();
                Home(wordBank);
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
        static void Home(string[] wordBank)
        {
            Console.WriteLine("315: HOME");
            for (int i = 0; i < wordBank.Length; i++)
            {
                Console.WriteLine(wordBank[i]);
            }
            // intro screen
            // user interface/selection
            // CRUD words to file
        }
        static string[] FileSetup()
        {
            Console.WriteLine("315: FILE SETUP");
            string path = "../../../MyTest.txt";

            // no file? create and populate with default bank:
            string[] defaultBank = new string[3] { "cocortical", "scrumptious", "bombastic" };
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    for (int i = 0; i < defaultBank.Length; i++)
                    {
                        sw.WriteLine(defaultBank[i]);
                    }
                }
            }

            string[] wordBank = File.ReadAllLines(path);

            return wordBank;

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
            // read and print file
            string path = "../../../MyTest.txt";
            using (StreamReader sr = File.OpenText(path))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
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

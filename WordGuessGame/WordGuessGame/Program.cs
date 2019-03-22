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
            // other cool thing for game intro here
           
            Console.WriteLine("1] PLAY");
            Console.WriteLine("2] VIEW WORDS");
            Console.WriteLine("3] ADD WORD");
            Console.WriteLine("4] REMOVE WORD");
            Console.WriteLine("5] EXIT");

            while (true)
            {
                string inputStr = Console.ReadLine();
                int inputVal;
                inputVal = Convert.ToInt32(inputStr);
                if(inputVal == 1)
                {
                    Play();
                }
                else if (inputVal == 2)
                {
                    ViewWords();
                }
                else if (inputVal == 3)
                {
                    AddWord();
                }
                else if (inputVal == 4)
                {
                    RemoveWord();
                }
                else if (inputVal == 5)
                {
                    Console.WriteLine("Toodle-oo!");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Excuse me what?");
                }

            }
            //for (int i = 0; i < wordBank.Length; i++)
            //{
            //    Console.WriteLine(wordBank[i]);
            //}
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
        static void AddWord()
        {
            // io
        }
        static void RemoveWord()
        {
            // io
        }
    }
}

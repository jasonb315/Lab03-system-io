﻿using System;
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
                Console.ForegroundColor = ConsoleColor.White;
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

            int userSelect;

            while(true)
            {
                string inputStr = Console.ReadLine();
                userSelect = Convert.ToInt32(inputStr);
                if (userSelect >= 1 && userSelect <= 5)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Excuse me what?");
                }
            }

            if(userSelect == 1)
            {
                Play(wordBank);
            }
            else if (userSelect == 2)
            {
                ViewWords();
            }
            else if (userSelect == 3)
            {
                AddWord();
            }
            else if (userSelect == 4)
            {
                RemoveWord();
            }
            else if (userSelect == 5)
            {
                Console.WriteLine("Toodle-oo!");
                Environment.Exit(0);
            }
        }
        static string[] FileSetup()
        {
            Console.WriteLine("315: FILE SETUP");
            string path = "../../../wordBank.txt";

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

        static void ColorCode(int color)
        {
            if(color == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            if (color == 1)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
            if (color == 2)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            if (color == 3)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            if (color == 4)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            if (color == 5)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
        }

        static void Play(string[]wordBank)
        {
            
            Random rnd = new Random();
            int selectVal = rnd.Next(0, wordBank.Length -1);
            string secretWord = wordBank[selectVal];

            // compare data:
            char[] charArray = secretWord.ToCharArray();
            // console write data:
            char[] dashLine = new char[charArray.Length];
            //populate dashLine
            
            for (int i = 0; i < dashLine.Length; i++)
            {
                dashLine[i] = '_';
            }

            //string[] colorCode = new string[] { "Red", "Magenta", "Yellow", "Green", "Cyan", "Blue" };
            int colorCounter = 0;

            while (true)
            {
                for (int i = 0; i < dashLine.Length; i++)
                {
                    if (colorCounter == 6)
                    {
                        colorCounter = 0;

                    }
                    ColorCode(colorCounter);
                    colorCounter++;
                    Console.Write($"{ dashLine[i]} ");
                }

                Console.WriteLine();

                Console.Write("Guess a letter: ");
                string inputStr = Console.ReadLine();

                if (inputStr.Length > 1)
                {
                    Console.WriteLine("Woah buddy, one at a time.");
                }
                else if (inputStr.Length == 1)
                {

                    // valid length
                    // find and replace char in dashLine
                    char character = char.Parse(inputStr);

                    for (int i = 0; i < dashLine.Length; i++)
                    {

                        if (charArray[i] == character)
                        {
                            Console.WriteLine("ding!");
                            dashLine[i] = character;
                        }
                    }
                }


                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.White;
                
            }



            Home(wordBank);

        }
        static void ViewWords()
        {
            // read and print file
            string path = "../../../wordBank.txt";
            using (StreamReader sr = File.OpenText(path))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }

            string[] wordBank = FileSetup();
            Home(wordBank);

        }
        static void AddWord()
        {
            while (true)
            {
                Console.Write("<<<\"done\"] Enter word to add: ");

                string newWord = Console.ReadLine();

                string path = "../../../wordBank.txt";
                
                // exit AddWord
                if (newWord == "done")
                {
                    break;
                }

                else
                {
                    // add the word
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine(newWord);
                    }

                    // and print the list with the new word
                    Console.WriteLine("UPDATED WORD BANK:");
                    using (StreamReader sr = File.OpenText(path))
                    {
                        string s;
                        while ((s = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(s);
                        }
                    }
                }
            }

            // load new wordBank to Home
            string[] wordBank = FileSetup();
            Home(wordBank);
        }
        static void RemoveWord()
        {
            while (true)
            {
                Console.Write("<<<\"done\"] Enter word to remove: ");

                string delWord = Console.ReadLine();

                string path = "../../../wordBank.txt";

                // exit AddWord
                if (delWord == "done")
                {
                    break;
                }

                else
                {
                    // read into program as arr
                    // remove word
                    // rewrite file
                    string[] wordList = File.ReadAllLines(path);
                    string[] newList = new string[wordList.Length - 1];

                    int j = 0;
                    for (int i = 0; i < wordList.Length; i++)
                    {
                        if (delWord != wordList[i]){
                            newList[j] = wordList[i];
                            j++;
                        }
                    }

                    //rewrite file
                    File.Delete(path);

                    using (StreamWriter sw = File.CreateText(path))
                    {
                        for (int i = 0; i < newList.Length; i++)
                        {
                            sw.WriteLine(newList[i]);
                        }
                    }

                    // and print the list with the new word
                    Console.WriteLine("UPDATED WORD BANK:");
                    using (StreamReader sr = File.OpenText(path))
                    {
                        string s;
                        while ((s = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(s);
                        }
                    }
                }
            }
            string[] wordBank = FileSetup();
            Home(wordBank);
        }
    }
}


using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

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


                Console.WriteLine();

                Home(wordBank);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Buhbye!");
            }
        }
        static void Home(string[] wordBank)
        {
            // other cool thing for game intro here

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Gray;
            string appName = "WordGuessingGame";
            string appVersion = "1.0.0";
            string appAuthor = "Jason Burns";
            Console.WriteLine("{0}: Version {1} by {2}", appName, appVersion, appAuthor);

            Console.ForegroundColor = ConsoleColor.White;
            string title = @"
                                     ,---,            
         .---.   ,---.    __  ,-.  ,---.'|            
        /. ./|  '   ,'\ ,' ,'/ /|  |   | :  .--.--.   
     .-'-. ' | /   /   |'  | |' |  |   | | /  /    '  
    /___/ \: |.   ; ,. :|  |   ,',--.__| ||  :  /`./  
 .-'.. '   ' .'   | |: :'  :  / /   ,'   ||  :  ;_    
/___/ \:     ''   | .; :|  | ' .   '  /  | \  \    `. 
.   \  ' .\   |   :    |;  : | '   ; |:  |  `----.   \
 \   \   ' \ | \   \  / |  , ; |   | '/  ' /  /`--'  /
  \   \  |--'   `----'   ---' |   :    :| '--'.     /
   \   \ |                      \   \  /    `--`---`
    '---'                        `----'

                ";
            Console.Write(title);

            Console.WriteLine();

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
                Console.WriteLine();
                Console.WriteLine("Toodle-oo!");
                Console.WriteLine();
                Environment.Exit(0);
            }
        }
        static string[] FileSetup()
        {
            Console.WriteLine();
            string path = "../../../wordBank.txt";

            // no file? create and populate with default bank:
            string[] defaultBank = new string[1] { "dog" };
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

        static void WinBling()
        {
            Console.Clear();
            string title = @"
 _ _ _  _  _ _  _ _  ___  ___ 
| | | || || \ || \ || __>| . \
| | | || ||   ||   || _> |   /
|__/_/ |_||_\_||_\_||___>|_\_\
                ";

            int colorCounter = 0;
            int milliseconds = 400;

            for (int i = 0; i < 6; i++)
            {
                Console.Clear();
                if (colorCounter == 6)
                {
                    colorCounter = 0;
                }
                ColorCode(colorCounter);
                colorCounter++;
                Console.Write(title);
                
                Thread.Sleep(milliseconds);
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press any key to continue ...");
            Console.ReadLine();
        }

        static void Play(string[]wordBank)
        {
            Console.Clear();

            Console.WriteLine();
            string guessPrompt = "GUESS THE WORD";
            for (int i = 0; i < guessPrompt.Length; i++)
            {
                int printWait = 100;
                Thread.Sleep(printWait);
                Console.Write(guessPrompt[i]);
            }

           
            Console.WriteLine();

            int startWait = 500;
            Thread.Sleep(startWait);

            Console.Clear();

            Random rnd = new Random();
            int selectVal = rnd.Next(0, wordBank.Length -1);
            string secretWord = wordBank[selectVal];

            // guess list
            List<string> guessed = new List<string>();
            // compare data:
            char[] charArray = secretWord.ToCharArray();
            // console write data:
            char[] dashLine = new char[charArray.Length];
            //populate dashLine
            
            for (int i = 0; i < dashLine.Length; i++)
            {
                dashLine[i] = '_';
            }

            int colorCounter = 0;

            bool playing = true;
            while (playing)
            {
                Console.Clear();
                Console.WriteLine();
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
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("Guesses made: [");
                foreach(var letter in guessed)
                {
                    Console.Write($"{letter} ");
                }
                Console.Write("]");
                Console.WriteLine();


                Console.Write("Guess a letter: ");
                string inputStr = Console.ReadLine();

                if (inputStr.Length > 1)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Woah buddy, one at a time.");
                }
                else if (inputStr.Length == 1)
                {
                    guessed.Add(inputStr);
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

                    //check for completion
                    for (int i = 0; i < dashLine.Length; i++)
                    {
                        string s = new string(dashLine);
                        if (!s.Contains('_'))
                        {
                            playing = false;
                            
                        }
                    }
                    // endgame redout of word
                    if (!playing)
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("You got it!");
                        Console.ForegroundColor = ConsoleColor.White;
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
                        Console.ReadLine();
                        WinBling();
                        Console.Clear();

                    }
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
            }



            Home(wordBank);

        }
        static void ViewWords()
        {
            Console.WriteLine("WORD BANK:");
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
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            Home(wordBank);

        }
        static void AddWord()
        {
            Console.WriteLine("WORD BANK:");
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

            while (true)
            {
                Console.Write("<<<\"done\"] Enter word to add: ");

                string newWord = Console.ReadLine();
                
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
            Console.WriteLine("WORD BANK:");
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

            while (true)
            {
                Console.Write("<<<\"done\"] Enter word to remove: ");

                string delWord = Console.ReadLine();


                // exit AddWord
                if (delWord == "done")
                {
                    break;
                }

                else
                {
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


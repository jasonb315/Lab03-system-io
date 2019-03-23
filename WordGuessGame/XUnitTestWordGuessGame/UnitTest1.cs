using System;
using System.IO;
using Xunit;

namespace WordGuessGame
{
    public class UnitTest1
    {
        [Fact]
        public void FileCreation()
        {
            string path = "../../../../WordGuessGame/wordBank.txt";

            bool fileExists = File.Exists(path);

            Assert.True(fileExists);
        }

        [Fact]
        public void FileRead()
        {
            string[] words = new string[11];

            string path = "../../../../WordGuessGame/wordBank.txt";
            int i = 0;

            using (StreamReader sr = File.OpenText(path))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    words[i] = s;
                    i++;
                }
            }
            int wordArrLen = words.Length;
            Assert.Equal(11, wordArrLen);
        }

        [Fact]
        public void LetterRead()
        {
            string word = "dog";
            bool wordHasLetter = word.Contains("o");
            Assert.True(wordHasLetter);
        }
    }
}

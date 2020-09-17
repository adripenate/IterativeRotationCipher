using System;
using System.Text.RegularExpressions;

namespace IterativeRotationCipher
{
    public class Encoder
    {
        private const string SPACE_PATTERN = @"\s+";
        private const string NO_SPACE = "";
        private const char SPACE_CHARACTER = ' ';

        public object Encode(string phrase, int number_rotations)
        {
            for(int actual_rotation = 0; actual_rotation<number_rotations; actual_rotation++)
            {
                string phraseWithoutSpaces = RemoveSpaces(phrase);
                phraseWithoutSpaces = Rotate(phraseWithoutSpaces, number_rotations);
                string[] words = SeparateWords(phrase, phraseWithoutSpaces);
                phrase = "";
                for (int position = 0; position < words.Length; position++)
                {
                    if (words[position].Length > 1) words[position] = Rotate(words[position], number_rotations);
                    phrase += words[position] + " ";
                }
                phrase = phrase.Trim();
            }
            return phrase;
        }

        private static string[] SeparateWords(string phrase, string phraseWithoutSpaces)
        {
            string[] original_words = phrase.Split(SPACE_CHARACTER);
            string[] words = new string[original_words.Length];
            var separation = 0;
            for (int position = 0; position < original_words.Length; position++)
            {
                words[position] = GetWord(phraseWithoutSpaces, GetWordLength(original_words, position), separation);
                separation += GetWordLength(original_words, position);
            }
            return words;
        }

        private static int GetWordLength(string[] original_words, int position)
        {
            return original_words[position].Length;
        }

        private static string GetWord(string phraseWithoutSpaces, int word_length, int separation)
        {
            return phraseWithoutSpaces.Substring(separation, word_length);
        }

        private static string RemoveSpaces(string phrase)
        {
            return Regex.Replace(phrase, SPACE_PATTERN, NO_SPACE);
        }

        private static string Rotate(string phrase, int number_rotations)
        {
            return phrase.Substring(GetShiftPosition(phrase, number_rotations)) + phrase.Substring(0, GetShiftPosition(phrase, number_rotations));
        }

        private static int GetShiftPosition(string phrase, int number_rotations)
        {
            return phrase.Length - number_rotations;
        }
    }
}

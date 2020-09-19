using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace IterativeRotationCipher
{
    public class IRC
    {
        private const string SPACE_PATTERN = @"\s+";
        private const string NO_SPACE = "";
        private const char SPACE_CHARACTER = ' ';
        private const string SPACE = " ";

        public object Encode(string phrase, int number_rotations)
        {
            for(int actual_rotation = 0; actual_rotation<number_rotations; actual_rotation++)
            {
                string phraseWithoutSpaces = RemoveSpaces(phrase);
                phraseWithoutSpaces = Shifter.ShiftRight(phraseWithoutSpaces, number_rotations);
                List<string> words = SeparateWords(phrase, phraseWithoutSpaces);
                words = RotateWords(number_rotations, words);
                phrase = BuildPhrase(words);
            }
            return phrase;
        }

        public object Decode(string phrase, int number_rotations)
        {
            for (int actual_rotation = 0; actual_rotation < number_rotations; actual_rotation++)
            {
                List<string> words = new List<string>(phrase.Split(' '));
                for (int position = 0; position < words.Count; position++)
                {
                    words[position] = Shifter.ShiftLeft(words[position], number_rotations);
                }

                var phraseWithoutSpaces = Shifter.ShiftLeft(String.Join("", words.ToArray()), number_rotations);
                words = SeparateWords(phrase, phraseWithoutSpaces);
                phrase = String.Join(" ", words.ToArray());
            }
            return phrase;
        }

        private static string RemoveSpaces(string phrase)
        {
            return Regex.Replace(phrase, SPACE_PATTERN, NO_SPACE);
        }

        private static List<string> SeparateWords(string phrase, string phraseWithoutSpaces)
        {
            List<string> words = new List<string>(GetOriginalWords(phrase));
            for (int position = 0, word_start = 0; position < words.Count; position++)
            {
                words[position] = GetWord(phraseWithoutSpaces, GetLength(words[position]), word_start);
                word_start += GetLength(words[position]);
            }
            return words;
        }

        private static List<string> RotateWords(int number_rotations, List<string> words)
        {
            for (int position = 0; position < words.Count; position++)
            {
                if (HasMoreThanOneLetter(words[position])) words[position] = Shifter.ShiftRight(words[position], number_rotations);
            }
            return words;
        }

        private static string BuildPhrase(List<string> words)
        {
            return String.Join(SPACE, words.ToArray());
        }

        private static string[] GetOriginalWords(string phrase)
        {
            return phrase.Split(SPACE_CHARACTER);
        }

        private static int GetLength(string word)
        {
            return word.Length;
        }

        private static string GetWord(string phraseWithoutSpaces, int word_length, int separation)
        {
            return phraseWithoutSpaces.Substring(separation, word_length);
        }

        private static bool HasMoreThanOneLetter(string word)
        {
            return GetLength(word) > 1;
        }
    }
}

using System;
using System.Text.RegularExpressions;

namespace IterativeRotationCipher
{
    public class Encoder
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
                phraseWithoutSpaces = Rotate(phraseWithoutSpaces, number_rotations);
                string[] words = SeparateWords(phrase, phraseWithoutSpaces);
                words = RotateWords(number_rotations, words);
                phrase = BuildPhrase(words);
            }
            return phrase;
        }

        private static string[] RotateWords(int number_rotations, string[] words)
        {
            for (int position = 0; position < GetNumberOfWords(words); position++)
            {
                if (HasMoreThanOneLetter(words[position])) words[position] = Rotate(words[position], number_rotations);
            }
            return words;
        }

        private static int GetNumberOfWords(string[] words)
        {
            return words.Length;
        }

        private static string BuildPhrase(string[] words)
        {
            string phrase = "";
            for (int position = 0; position < GetNumberOfWords(words)-1; position++) 
                phrase += words[position] + SPACE;
            phrase += words[GetNumberOfWords(words)-1];
            return phrase;
        }

        private static bool HasMoreThanOneLetter(string word)
        {
            return GetLength(word) > 1;
        }

        private static string[] SeparateWords(string phrase, string phraseWithoutSpaces)
        {
            string[] original_words = GetOriginalWords(phrase);
            string[] words = new string[GetNumberOfWords(original_words)];
            for (int position = 0, word_start = 0; position < GetNumberOfWords(original_words); position++)
            {
                words[position] = GetWord(phraseWithoutSpaces, GetLength(original_words[position]), word_start);
                word_start += GetLength(original_words[position]);
            }
            return words;
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
            return GetLength(phrase) - number_rotations;
        }
    }
}

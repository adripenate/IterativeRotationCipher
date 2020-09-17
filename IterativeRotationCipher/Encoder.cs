using System;
using System.Text.RegularExpressions;

namespace IterativeRotationCipher
{
    public class Encoder
    {
        public object encode(string phrase, int number_rotations)
        {
            for(int actual_rotation = 0; actual_rotation<number_rotations; actual_rotation++)
            {
                string phraseWithoutSpaces = RemoveSpaces(phrase);
                phraseWithoutSpaces = Rotate(phraseWithoutSpaces, number_rotations);
                string[] original_words = phrase.Split(' ');
                string[] words = new string[original_words.Length];
                var separation = 0;
                phrase = "";
                for (int position = 0; position < original_words.Length; position++)
                {
                    words[position] = GetWord(phraseWithoutSpaces, original_words[position], separation);
                    words[position] = Rotate(words[position], number_rotations);
                    separation += original_words[position].Length;
                    phrase += words[position] + " ";
                }
                phrase = phrase.Trim();
            }
            return phrase;
        }

        private static string GetWord(string phraseWithoutSpaces, string original_word, int separation)
        {
            return phraseWithoutSpaces.Substring(separation, original_word.Length);
        }

        private static string RemoveSpaces(string phrase)
        {
            return Regex.Replace(phrase, @"\s+", "");
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

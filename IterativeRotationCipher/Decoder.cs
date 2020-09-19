using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace IterativeRotationCipher
{
    public class Decoder
    {
        private const char SPACE_CHARACTER = ' ';

        public object Decode(string phrase, int number_rotations)
        {
            for (int actual_rotation = 0; actual_rotation<number_rotations; actual_rotation++)
            {
                List<string> words = new List<string>(phrase.Split(' '));
                for (int position = 0; position<words.Count; position++)
                {
                    words[position] = Shifter.ShiftLeft(words[position], number_rotations);
                }

                var phraseWithoutSpaces = Shifter.ShiftLeft(String.Join("", words.ToArray()), number_rotations);
                words = SeparateWords(phrase, phraseWithoutSpaces);
                phrase = String.Join(" ", words.ToArray());
            }
            return phrase;
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

        private static string[] GetOriginalWords(string phrase)
        {
            return phrase.Split(SPACE_CHARACTER);
        }

        private static string GetWord(string phraseWithoutSpaces, int word_length, int separation)
        {
            return phraseWithoutSpaces.Substring(separation, word_length);
        }

        private static int GetLength(string word)
        {
            return word.Length;
        }
    }
}

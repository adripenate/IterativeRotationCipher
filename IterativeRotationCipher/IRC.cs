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
                phrase = RotatePhrase(phrase, number_rotations, new RightShifter());
                phrase = RotateWords(phrase, number_rotations, new RightShifter());
            }
            return phrase;
        }


        public object Decode(string phrase, int number_rotations)
        {
            for (int actual_rotation = 0; actual_rotation < number_rotations; actual_rotation++)
            {
                phrase = RotateWords(phrase, number_rotations, new LeftShifter());
                phrase = RotatePhrase(phrase, number_rotations, new LeftShifter());
            }
            return phrase;
        }

        private string RotatePhrase(string phrase, int number_rotations, IShifter shifter)
        {
            string phraseWithoutSpaces = RemoveSpaces(phrase);
            phraseWithoutSpaces = shifter.Shift(phraseWithoutSpaces, number_rotations);
            return PutSpacesBackInPlace(phrase, phraseWithoutSpaces);
        }

        private string PutSpacesBackInPlace(string phrase, string phraseWithoutSpaces)
        {
            List<string> words = SeparateWords(phrase, phraseWithoutSpaces);
            return JoinWords(words, SPACE);
        }

        private string RotateWords(string phrase, int number_rotations, IShifter shifter)
        {
            List<string> words = new List<string>(GetWordsIn(phrase));
            for (int position = 0; position < words.Count; position++)
            {
                if (HasMoreThanOneLetter(words[position])) words[position] = shifter.Shift(words[position], number_rotations);
            }
            return JoinWords(words, SPACE);
        }

        private string RemoveSpaces(string phrase)
        {
            return Regex.Replace(phrase, SPACE_PATTERN, NO_SPACE);
        }

        private List<string> SeparateWords(string phrase, string phraseWithoutSpaces)
        {
            List<string> words = new List<string>(GetWordsIn(phrase));
            for (int position = 0, word_start = 0; position < words.Count; position++)
            {
                words[position] = GetWord(phraseWithoutSpaces, GetLength(words[position]), word_start);
                word_start += GetLength(words[position]);
            }
            return words;
        }

        private string JoinWords(List<string> words, string delimiter)
        {
            return String.Join(delimiter, words.ToArray());
        }

        private string[] GetWordsIn(string phrase)
        {
            return phrase.Split(SPACE_CHARACTER);
        }

        private int GetLength(string word)
        {
            return word.Length;
        }

        private string GetWord(string phraseWithoutSpaces, int word_length, int separation)
        {
            return phraseWithoutSpaces.Substring(separation, word_length);
        }

        private bool HasMoreThanOneLetter(string word)
        {
            return GetLength(word) > 1;
        }
    }
}

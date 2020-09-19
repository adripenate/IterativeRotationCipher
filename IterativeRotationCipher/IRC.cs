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
        private IShifter shifter;

        public object Encode(string phrase, int number_rotations)
        {
            shifter = new RightShifter();
            for(int actual_rotation = 0; actual_rotation<number_rotations; actual_rotation++)
            {
                phrase = RotatePhraseRight(phrase, number_rotations);
                phrase = RotateWordsRight(number_rotations, phrase);
            }
            return phrase;
        }


        public object Decode(string phrase, int number_rotations)
        {
            shifter = new LeftShifter();
            for (int actual_rotation = 0; actual_rotation < number_rotations; actual_rotation++)
            {
                phrase = RotateWordsLeft(phrase, number_rotations);
                phrase = RotatePhraseLeft(phrase, number_rotations);
            }
            return phrase;
        }

        private string RotatePhraseRight(string phrase, int number_rotations)
        {
            string phraseWithoutSpaces = RemoveSpaces(phrase);
            phraseWithoutSpaces = shifter.Shift(phraseWithoutSpaces, number_rotations);
            List<string> words = SeparateWords(phrase, phraseWithoutSpaces);
            phrase = JoinWords(words, SPACE);
            return phrase;
        }

        private string RotatePhraseLeft(string phrase, int number_rotations)
        {
            var phraseWithoutSpaces = RemoveSpaces(phrase);
            phraseWithoutSpaces = shifter.Shift(phraseWithoutSpaces, number_rotations);
            List<string> words = SeparateWords(phrase, phraseWithoutSpaces);
            phrase = JoinWords(words, SPACE);
            return phrase;
        }

        private string RotateWordsRight(int number_rotations, string phrase)
        {
            List<string> words = new List<string>(GetWordsIn(phrase));
            for (int position = 0; position < words.Count; position++)
            {
                if (HasMoreThanOneLetter(words[position])) words[position] = shifter.Shift(words[position], number_rotations);
            }
            return JoinWords(words, SPACE);
        }

        private string RotateWordsLeft(string phrase, int number_rotations)
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

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

        public string Encode(string phrase, int number_rotations)
        {
            for(int actual_rotation = 0; actual_rotation<number_rotations; actual_rotation++)
            {
                phrase = RotatePhrase(phrase, number_rotations, new RightShifter());
                phrase = RotateWords(phrase, number_rotations, new RightShifter());
            }
            return number_rotations + " " + phrase;
        }


        public string Decode(string phrase)
        {
            var number_rotations = int.Parse(phrase.Substring(0, phrase.IndexOf(' ')));
            phrase = phrase.Substring(phrase.IndexOf(' ') + 1);
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

        private string RotateWords(string phrase, int number_rotations, IShifter shifter)
        {
            List<string> words = GetListOfWordsIn(phrase);
            for (int position = 0; position < NumberOf(words); position++)
            {
                if (HasMoreThanOneLetter(words[position])) words[position] = shifter.Shift(words[position], number_rotations);
            }
            return JoinWords(words, SPACE);
        }

        private string PutSpacesBackInPlace(string phrase, string phraseWithoutSpaces)
        {
            List<string> words = SeparateWords(phrase, phraseWithoutSpaces);
            return JoinWords(words, SPACE);
        }

        private List<string> SeparateWords(string phrase, string phraseWithoutSpaces)
        {
            List<string> words = GetListOfWordsIn(phrase);
            for (int position = 0, word_start = 0; position < NumberOf(words); position++)
            {
                words[position] = GetWord(phraseWithoutSpaces, GetLength(words[position]), word_start);
                word_start += GetLength(words[position]);
            }
            return words;
        }

        private string RemoveSpaces(string phrase)
        {
            return Regex.Replace(phrase, SPACE_PATTERN, NO_SPACE);
        }

        private string JoinWords(List<string> words, string separator)
        {
            return String.Join(separator, words.ToArray());
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

        private static int NumberOf(List<string> words)
        {
            return words.Count;
        }

        private List<string> GetListOfWordsIn(string phrase)
        {
            return new List<string>(GetWordsIn(phrase));
        }
    }
}

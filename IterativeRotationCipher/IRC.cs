using System;
using System.Collections.Generic;

namespace IterativeRotationCipher
{
    public class IRC
    {
        private const string NO_SPACE = "";
        private const char SPACE_CHARACTER = ' ';
        private const string SPACE = " ";

        public static string Encode(string phrase, int number_rotations)
        {
            
            for (int actual_rotation = 0; actual_rotation<number_rotations; actual_rotation++)
            {
                phrase = RotatePhrase(phrase, number_rotations, new RightShifter());
                phrase = RotateWords(phrase, number_rotations, new RightShifter());
            }
            return number_rotations + SPACE + phrase;
        }


        public static string Decode(string phrase)
        {
            var number_rotations = GetNumberOfRotations(phrase);
            phrase = GetPhraseWithoutNumberOfRotations(phrase);
            for (int actual_rotation = 0; actual_rotation < number_rotations; actual_rotation++)
            {
                phrase = RotateWords(phrase, number_rotations, new LeftShifter());
                phrase = RotatePhrase(phrase, number_rotations, new LeftShifter());
            }
            return phrase;
        }

        private static string RotatePhrase(string phrase, int number_rotations, IShifter shifter)
        {
            string phraseWithoutSpaces = RemoveSpaces(phrase);
            phraseWithoutSpaces = shifter.Shift(phraseWithoutSpaces, number_rotations);
            return PutSpacesBackInPlace(phrase, phraseWithoutSpaces);
        }

        private static string RotateWords(string phrase, int number_rotations, IShifter shifter)
        {
            List<string> words = GetListOfWordsIn(phrase);
            for (int position = 0; position < NumberOf(words); position++)
            {
                if (HasMoreThanOneLetter(words[position])) words[position] = shifter.Shift(words[position], number_rotations);
            }
            return JoinWords(words, SPACE);
        }

        private static string PutSpacesBackInPlace(string phrase, string phraseWithoutSpaces)
        {
            List<string> words = SeparateWords(phrase, phraseWithoutSpaces);
            return JoinWords(words, SPACE);
        }

        private static List<string> SeparateWords(string phrase, string phraseWithoutSpaces)
        {
            List<string> words = GetListOfWordsIn(phrase);
            for (int position = 0, word_start = 0; position < NumberOf(words); position++)
            {
                words[position] = GetWord(phraseWithoutSpaces, GetLength(words[position]), word_start);
                word_start += GetLength(words[position]);
            }
            return words;
        }

        private static string GetPhraseWithoutNumberOfRotations(string phrase)
        {
            return phrase.Substring(phrase.IndexOf(SPACE_CHARACTER) + 1);
        }

        private static int GetNumberOfRotations(string phrase)
        {
            return int.Parse(phrase.Substring(0, phrase.IndexOf(SPACE_CHARACTER)));
        }

        private static string RemoveSpaces(string phrase)
        {
            return phrase.Replace(SPACE, NO_SPACE);
        }

        private static string JoinWords(List<string> words, string separator)
        {
            return String.Join(separator, words.ToArray());
        }

        private static string[] GetWordsIn(string phrase)
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

        private static int NumberOf(List<string> words)
        {
            return words.Count;
        }

        private static List<string> GetListOfWordsIn(string phrase)
        {
            return new List<string>(GetWordsIn(phrase));
        }
    }
}

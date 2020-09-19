using System;
using System.Collections.Generic;
using System.Text;

namespace IterativeRotationCipher
{
    class Shifter
    {
        public static string ShiftLeft(string phrase, int number_rotations)
        {
            return phrase.Substring(number_rotations) + phrase.Substring(0, number_rotations);
        }

        public static string ShiftRight(string phrase, int number_rotations)
        {
            return phrase.Substring(GetShiftPosition(phrase, number_rotations)) + phrase.Substring(0, GetShiftPosition(phrase, number_rotations));
        }

        private static int GetShiftPosition(string phrase, int number_rotations)
        {
            return GetLength(phrase) - number_rotations;
        }

        private static int GetLength(string word)
        {
            return word.Length;
        }
    }
}

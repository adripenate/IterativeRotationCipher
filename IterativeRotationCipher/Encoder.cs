using System;

namespace IterativeRotationCipher
{
    public class Encoder
    {
        public object encode(string phrase, int number_rotations)
        {
            for(int actual_rotation = 0; actual_rotation<number_rotations; actual_rotation++)
            {
                phrase = Rotate(phrase, number_rotations);
                phrase = Rotate(phrase, number_rotations);
            }
            return phrase;
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

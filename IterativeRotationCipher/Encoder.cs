using System;

namespace IterativeRotationCipher
{
    public class Encoder
    {
        public object encode(string phrase, int number_rotations)
        {
            for(int actual_rotation = 0; actual_rotation<number_rotations; actual_rotation++)
            {
                phrase = phrase.Substring(phrase.Length - number_rotations) + phrase.Substring(0, phrase.Length - number_rotations);
                phrase = phrase.Substring(phrase.Length - number_rotations) + phrase.Substring(0, phrase.Length - number_rotations);
            }
            return phrase;
        }
    }
}

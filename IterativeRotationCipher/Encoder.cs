using System;

namespace IterativeRotationCipher
{
    public class Encoder
    {
        public object encode(string phrase, int number_rotations)
        {
            phrase = phrase.Substring(phrase.Length - 1) + phrase.Substring(0, phrase.Length - 1);
            return phrase.Substring(phrase.Length - 1) + phrase.Substring(0, phrase.Length - 1);
        }
    }
}

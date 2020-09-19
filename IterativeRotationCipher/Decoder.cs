using System;
using System.Collections.Generic;
using System.Text;

namespace IterativeRotationCipher
{
    public class Decoder
    {
        public object Decode(string phrase, int number_rotations)
        {
            for (int actual_rotation = 0; actual_rotation<number_rotations; actual_rotation++)
            {
                phrase = Shifter.ShiftLeft(phrase, number_rotations);
                phrase = Shifter.ShiftLeft(phrase, number_rotations);
            }
            return phrase;
        }
    }
}

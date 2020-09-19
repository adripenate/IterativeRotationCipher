using System;
using System.Collections.Generic;
using System.Text;

namespace IterativeRotationCipher
{
    public class LeftShifter: IShifter
    {
        public string Shift(string phrase, int number_rotations)
        {
            return phrase.Substring(number_rotations) + phrase.Substring(0, number_rotations);
        }
    }
}

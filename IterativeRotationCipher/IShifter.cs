using System;
using System.Collections.Generic;
using System.Text;

namespace IterativeRotationCipher
{
    interface IShifter
    {
        string Shift(string phrase, int number_rotations);
    }
}

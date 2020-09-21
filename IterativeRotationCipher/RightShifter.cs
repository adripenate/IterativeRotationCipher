namespace IterativeRotationCipher
{
    public class RightShifter: IShifter
    {
        public string Shift(string phrase, int number_rotations)
        {
            for (int actual_rotation = 0; actual_rotation<number_rotations; actual_rotation++)
            {   
                phrase = phrase.Substring(GetLength(phrase) - 1) + phrase.Substring(0, GetLength(phrase)-1);
            }
            return phrase;
        }

        private static int GetLength(string word)
        {
            return word.Length;
        }
    }
}

namespace IterativeRotationCipher
{
    public class LeftShifter: IShifter
    {
        public string Shift(string phrase, int number_rotations)
        {
            for (int actual_rotation = 0; actual_rotation < number_rotations; actual_rotation++)
            {
                phrase = phrase.Substring(1) + phrase.Substring(0, 1);
            }
            return phrase;
        }
    }
}

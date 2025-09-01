namespace TicTacToe 
{
    public static class Extensions
    {
        public static bool IsValidInteger(this string? input, out int index)
        {
            if (int.TryParse(input, out index))
            {
                return true;
            }
            index = -1;
            return false;
        }
    }
}

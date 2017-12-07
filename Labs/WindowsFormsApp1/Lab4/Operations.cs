namespace WindowsFormsApp1
{
     public static class Operations
    {

        public static string ToDigitsString(uint[] data)
        {
            
            return  reverse(data[0]).ToString("X8") +
                    reverse(data[1]).ToString("X8") +
                    reverse(data[2]).ToString("X8") +
                    reverse(data[3]).ToString("X8");
        }

        public static uint lshift(uint integer, ushort shift)
        {
            return ((integer >> 32 - shift) | (integer << shift));
        }

        public static uint reverse(uint integer)
        {
            return (((integer & 0x000000ff) << 24) |
                        (integer >> 24) |
                    ((integer & 0x00ff0000) >> 8) |
                    ((integer & 0x0000ff00) << 8));
        }
    }
}

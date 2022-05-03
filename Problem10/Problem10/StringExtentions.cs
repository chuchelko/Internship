namespace Problem10
{

    public static class StringExtentions
    {
        
        public static int FindEntriesCount(this string str, char c)
        {
            int count = 0;
            foreach (var ch in str)
            {
                if(c == ch)
                    count++;
            }
            return count;
        }

    }

}

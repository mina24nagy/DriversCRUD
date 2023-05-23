namespace DriversAPI.Helpers
{
    public class StringUtility
    {
        public static string GetRandomString()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, random.Next(4, 10))
                .Select(s => s[random.Next(s.Length)])
                .ToArray());
        }

        public static string GetRandomPhoneNumber()
        {
            string chars = "123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, 11)
                .Select(s => s[random.Next(s.Length)])
                .ToArray());
        }

        public static string SortString(String str)
        {
            var n = str.Length;
            char[] arr = str.ToCharArray();
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (Char.ToLower(arr[j]) > Char.ToLower(arr[j + 1]))
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                    }
                }
            }

            return String.Join("", arr);
        }
    }
}

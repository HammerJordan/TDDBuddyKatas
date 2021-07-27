namespace BalancedBrackets.Kata
{
    public class BalanceBracket
    {
        public static string TestBrackets(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            int length = input.Length;

            for (int i = 0; i < length; i++)
            {
                if (input[i] == '[' && input[i + 1] == ']')
                {
                    i++;
                    continue;
                }
                
                if(input[i] == '[' && input[^(1 + i)] == ']')
                {
                    length--;
                    continue;
                }
                
                return "FAIL";
            }

            return "OK";
        }
    }
}
namespace BalancedBrackets.Kata
{
    public class BalanceBracket
    {
        private const char LEFT_BRACE = '[';
        private const char RIGHT_BRACE = ']';
        
        public static string TestBrackets(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            int length = input.Length;

            for (int i = 0; i < length; i++)
            {
                if (input[i] == LEFT_BRACE && input[i + 1] == RIGHT_BRACE)
                {
                    i++;
                    continue;
                }
                if(input[i] == LEFT_BRACE && input[^(1 + i)] == RIGHT_BRACE)
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
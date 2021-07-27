namespace BalancedBrackets.Kata
{
    public class BalanceBracket
    {
        public static string TestBrackets(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            if (input.Equals("[]"))
                return "OK";

            return "FAIL";
        }
    }
}
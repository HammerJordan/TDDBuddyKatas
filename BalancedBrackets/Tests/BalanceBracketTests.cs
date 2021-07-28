using Xunit;
using BalancedBrackets.Kata;
using FluentAssertions;

namespace BalancedBrackets.Tests
{
    public class BalanceBracketTests
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ReturnEmptyString_WhenInputIsNullOrEmpty(string value)
        {
            var result = BalanceBracket.TestBrackets(value);

            result.Should().BeEquivalentTo("");
        }
        
        [Theory]
        [InlineData("[]")]
        [InlineData("[][]")]
        [InlineData("[][][]")]
        [InlineData("[[]]")]
        [InlineData("[[[][]]]")]
        
        public void ReturnOK_WhenInputIsBracesInCorrectOrder(string value)
        {
            var result = BalanceBracket.TestBrackets(value);
        
            result.Should().BeEquivalentTo("OK");
        }
        
        [Theory]
        [InlineData("][")]
        [InlineData("][][")]
        [InlineData("[][]][")]
        public void ReturnFAIL_WhenInputIsBracesInIncorrectOrder(string value)
        {
            var result = BalanceBracket.TestBrackets(value);
        
            result.Should().BeEquivalentTo("FAIL");
        }
    }
}
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

        [Fact]
        public void ReturnOK_WhenInputIsSingleBracesInCorrectOrder()
        {
            var result = BalanceBracket.TestBrackets("[]");
        
            result.Should().BeEquivalentTo("OK");
        }
        
        [Fact]
        public void ReturnFAIL_WhenInputIsSingleBracesInIncorrectOrder()
        {
            var result = BalanceBracket.TestBrackets("][");
        
            result.Should().BeEquivalentTo("FAIL");
        }
        
        [Theory]
        [InlineData("[][]")]
        [InlineData("[][][]")]
        [InlineData("[[]]")]
        [InlineData("[[[][]]]")]
        
        public void ReturnOK_WhenInputIsBracesInCorrectOrder(string value)
        {
            var result = BalanceBracket.TestBrackets(value);
        
            result.Should().BeEquivalentTo("OK");
        }
    }
}
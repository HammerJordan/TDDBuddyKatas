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

        // [Fact]
        // public void ReturnOK_WhenInputIsSingleBraces()
        // {
        //     var result = BalanceBracket.TestBrackets("[]");
        //
        //     result.Should().BeEquivalentTo("OK");
        // }
    }
}
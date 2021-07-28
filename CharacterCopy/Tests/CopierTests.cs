using CharacterCopy.Kata;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace CharacterCopy.Tests
{
    public class CopierTests
    {
        [Fact]
        public void CanConstructCopier()
        {
            var iSource = Substitute.For<ISource>();
            var iDestination = Substitute.For<IDestination>();

            var copier = new Copier(iSource, iDestination);

            copier.Should().NotBeNull();
        }
    }
}
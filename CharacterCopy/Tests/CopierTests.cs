using System.Linq;
using CharacterCopy.Kata;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace CharacterCopy.Tests
{
    public class CopierTests
    {
        private readonly ISource iSource;
        private readonly IDestination iDestination;
        private readonly Copier copier;

        public CopierTests()
        {
            iSource = Substitute.For<ISource>();
            iDestination = Substitute.For<IDestination>();

            copier = new Copier(iSource, iDestination);
        }

        [Fact]
        public void CanConstructCopier()
        {
            copier.Should().NotBeNull();
        }

        [Fact]
        public void Copy_Stops_WhenNewLineReached()
        {
            iSource.ReadChar().Returns('\n');

            copier.Copy();

            iSource.Received(1).ReadChar();
        }
    }
}
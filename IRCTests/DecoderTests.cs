using NUnit.Framework;
using FluentAssertions;
using IterativeRotationCipher;

namespace IRCTests
{
    public class DecoderTests
    {
        [Test]
        public void ShouldDecodeOneWordWithOneRotation()
        {
            var phrase = "1 lohel";
            var expectedOutput = "hello";

            var output = new IRC().Decode(phrase);

            output.Should().BeEquivalentTo(expectedOutput);
        }

        [Test]
        public void ShouldDecodeOneWordWithTwoRotations()
        {
            var phrase = "2 llohe";
            var expectedOutput = "hello";
            
            var output = new IRC().Decode(phrase);

            output.Should().BeEquivalentTo(expectedOutput);
        }

        [Test]
        public void ShouldDecodeTwoWordsWithOneRotation()
        {
            var phrase = "1 ldhel nofrie";
            var expectedOutput = "hello friend";
            
            var output = new IRC().Decode(phrase);

            output.Should().BeEquivalentTo(expectedOutput);
        }

        [Test]
        public void ShouldEncodeWithExtraSpaces()
        {
            var phrase = "2 lnfre  lodhie";
            var expectedOutput = "hello  friend";
            
            var output = new IRC().Decode(phrase);

            output.Should().BeEquivalentTo(expectedOutput);
        }


    }
}

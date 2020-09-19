using NUnit.Framework;
using FluentAssertions;
using IterativeRotationCipher;

namespace IRCTests
{
    public class EncoderTests
    {
        [Test]
        public void ShouldEncodeOneWordWithTwoRotations()
        {
            var number_rotations = 2;
            var phrase = "hello";
            var expectedOutput = "2 llohe";

            var output = IRC.Encode(phrase, number_rotations);

            output.Should().BeEquivalentTo(expectedOutput);
        }

        [Test]
        public void ShouldEncodeTwoWordsWithOneRotation()
        {
            var number_rotations = 1;
            var phrase = "hello friend";
            var expectedOutput = "1 ldhel nofrie";

            var output = IRC.Encode(phrase, number_rotations);

            output.Should().BeEquivalentTo(expectedOutput);
        }

        [Test]
        public void ShouldEncodeWithExtraSpaces()
        {
            var number_rotations = 2;
            var phrase = "hello  friend";
            var expectedOutput = "2 lnfre  lodhie";

            var output = IRC.Encode(phrase, number_rotations);

            output.Should().BeEquivalentTo(expectedOutput);
        }

        [Test]
        public void ShouldEncodeWithExtraSpacesAtTheEnd()
        {
            var number_rotations = 2;
            var phrase = "hello friend ";
            var expectedOutput = "2 lnfre lodhie ";

            var output = IRC.Encode(phrase, number_rotations);

            output.Should().BeEquivalentTo(expectedOutput);
        }
    }
}
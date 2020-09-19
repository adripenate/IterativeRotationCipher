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
            var expectedOutput = "llohe";

            var output = new IRC().Encode(phrase, number_rotations);

            output.Should().BeEquivalentTo(expectedOutput);
        }

        [Test]
        public void ShouldEncodeTwoWordsWithOneRotation()
        {
            var number_rotations = 1;
            var phrase = "hello friend";
            var expectedOutput = "ldhel nofrie";

            var output = new IRC().Encode(phrase, number_rotations);

            output.Should().BeEquivalentTo(expectedOutput);
        }

        [Test]
        public void ShouldEncodeWithExtraSpaces()
        {
            var number_rotations = 2;
            var phrase = "hello  friend";
            var expectedOutput = "lnfre  lodhie";

            var output = new IRC().Encode(phrase, number_rotations);

            output.Should().BeEquivalentTo(expectedOutput);
        }

        [Test]
        public void ShouldEncodeWithExtraSpacesAtTheEnd()
        {
            var number_rotations = 2;
            var phrase = "hello friend ";
            var expectedOutput = "lnfre lodhie ";

            var output = new IRC().Encode(phrase, number_rotations);

            output.Should().BeEquivalentTo(expectedOutput);
        }
    }
}
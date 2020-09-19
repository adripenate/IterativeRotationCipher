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

        [Test]
        public void ShouldEncodeWithWordsLengthLessThanNumberRotations()
        {
            var number_rotations = 10;
            var phrase = "If you wish to make an apple pie from scratch, you must first invent the universe.";
            var expectedOutput = "10 hu fmo a,ys vi utie mr snehn rni tvte .ysushou teI fwea pmapi apfrok rei tnocsclet";

            var output = IRC.Encode(phrase, number_rotations);

            output.Should().BeEquivalentTo(expectedOutput);
        }
    }
}
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

            var output = IRC.Decode(phrase);

            output.Should().BeEquivalentTo(expectedOutput);
        }

        [Test]
        public void ShouldDecodeOneWordWithTwoRotations()
        {
            var phrase = "2 llohe";
            var expectedOutput = "hello";
            
            var output = IRC.Decode(phrase);

            output.Should().BeEquivalentTo(expectedOutput);
        }

        [Test]
        public void ShouldDecodeTwoWordsWithOneRotation()
        {
            var phrase = "1 ldhel nofrie";
            var expectedOutput = "hello friend";
            
            var output = IRC.Decode(phrase);

            output.Should().BeEquivalentTo(expectedOutput);
        }

        [Test]
        public void ShouldEncodeWithExtraSpaces()
        {
            var phrase = "2 lnfre  lodhie";
            var expectedOutput = "hello  friend";
            
            var output = IRC.Decode(phrase);

            output.Should().BeEquivalentTo(expectedOutput);
        }

        [Test]
        public void ShouldDecodeWithWordsLengthLessThanNumberRotations()
        {
            var number_rotations = 10;
            var phrase = "10 hu fmo a,ys vi utie mr snehn rni tvte .ysushou teI fwea pmapi apfrok rei tnocsclet";
            var expectedOutput = "If you wish to make an apple pie from scratch, you must first invent the universe.";

            var output = IRC.Encode(phrase, number_rotations);

            output.Should().BeEquivalentTo(expectedOutput);
        }
    }
}

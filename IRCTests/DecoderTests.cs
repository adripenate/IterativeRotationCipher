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
            var number_rotations = 1;
            var phrase = "lohel";
            var expectedOutput = "hello";

            var output = new IRC().Decode(phrase, number_rotations);

            output.Should().BeEquivalentTo(expectedOutput);
        }

        [Test]
        public void ShouldDecodeOneWordWithTwoRotations()
        {
            var number_rotations = 2;
            var phrase = "llohe";
            var expectedOutput = "hello";
            
            var output = new IRC().Decode(phrase, number_rotations);

            output.Should().BeEquivalentTo(expectedOutput);
        }

        [Test]
        public void ShouldDecodeTwoWordsWithOneRotation()
        {
            var number_rotations = 1;
            var phrase = "ldhel nofrie";
            var expectedOutput = "hello friend";
            
            var output = new IRC().Decode(phrase, number_rotations);

            output.Should().BeEquivalentTo(expectedOutput);
        }


    }
}

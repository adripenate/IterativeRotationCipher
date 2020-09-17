using NUnit.Framework;
using FluentAssertions;
using IterativeRotationCipher;

namespace IRCTests
{
    public class EncoderTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldIterateOneWordTwoTimes()
        {
            var number_rotations = 2;
            var phrase = "hello";
            var expectedOutput = "llohe";

            var output = new Encoder().Encode(phrase, number_rotations);

            output.Should().BeEquivalentTo(expectedOutput);
        }

        [Test]
        public void ShouldIterateTwoWordsOneTime()
        {
            var number_rotations = 1;
            var phrase = "hello friend";
            var expectedOutput = "ldhel nofrie";

            var output = new Encoder().Encode(phrase, number_rotations);

            output.Should().BeEquivalentTo(expectedOutput);
        }

        [Test]
        public void ShouldIterateWithExtraSpaces()
        {
            var number_rotations = 2;
            var phrase = "hello  friend";
            var expectedOutput = "lnfre  lodhie";

            var output = new Encoder().Encode(phrase, number_rotations);

            output.Should().BeEquivalentTo(expectedOutput);
        }
    }
}
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
        public void shouldIterateSingleWordOneTime()
        {
            var number_rotations = 1;
            var phrase = "hello";
            var expectedOutput = "lohel";

            var output = new Encoder().encode(phrase, number_rotations);

            output.Should().BeEquivalentTo(expectedOutput);
        }
    }
}
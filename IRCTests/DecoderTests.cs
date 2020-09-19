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

            var output = new Decoder().Decode(phrase, number_rotations);

            output.Should().BeEquivalentTo(expectedOutput);
        }

        
    }
}

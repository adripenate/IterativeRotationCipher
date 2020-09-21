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

        [Test]
        public void ShouldEncodeWithNewLines()
        {
            var number_rotations = 29;
            var phrase = "I avoid that bleak first hour of the working day during which my still sluggish senses and body make every chore a penance.\nI find that in arriving later, the work which I do perform is of a much higher quality.";
            var expectedOutput = "29 a r.lht niou gwryd aoshg gIsi mk lei adwhfci isd seensn rdohy mo kleie oltbyhes a\naneu p.n rndr tehh irnne yifav t eo,raclhtc frpw IIti im gwkaidhv aicufh ima doea eruhi y io qshhcoa kr ef l btah gtrrse otnvugrt";

            var output = IRC.Encode(phrase, number_rotations);

            output.Should().BeEquivalentTo(expectedOutput);
        }
    }
}
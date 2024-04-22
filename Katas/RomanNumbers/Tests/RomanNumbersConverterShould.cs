using Katas.RomanNumbers.App;
using NUnit.Framework;

namespace Katas.RomanNumbers.Tests
{
    [TestFixture]
    public class RomanNumbersConverterShould
    {
        [Test]
        [TestCase(1, "I")]
        [TestCase(2, "II")]
        [TestCase(3, "III")]
        [TestCase(4, "IV")]
        [TestCase(5, "V")]
        [TestCase(6, "VI")]
        [TestCase(7, "VII")]
        [TestCase(8, "VIII")]
        [TestCase(9, "IX")]
        [TestCase(10, "X")]
        [TestCase(11, "XI")]
        [TestCase(29, "XXIX")]
        [TestCase(80, "LXXX")]
        [TestCase(294, "CCXCIV")]
        [TestCase(1673, "MDCLXXIII")]
        [TestCase(2019, "MMXIX")]
        [TestCase(3400, "MMMCD")]
        [TestCase(3450, "MMMCDL")]
        [TestCase(3500, "MMMD")]
        [TestCase(3550, "MMMDL")]
        [TestCase(3600, "MMMDC")]
        [TestCase(3650, "MMMDCL")]
        [TestCase(3700, "MMMDCC")]
        [TestCase(3750, "MMMDCCL")]
        [TestCase(3800, "MMMDCCC")]
        [TestCase(3850, "MMMDCCCL")]
        public void convert_Arabic_numbers_into_their_Roman_numeral_equivalents(
            int number, string expectedRoman
        )
        {
            Assert.That(expectedRoman, Is.EqualTo(RomanNumbersConverter.Convert(number)));
        }
    }
}
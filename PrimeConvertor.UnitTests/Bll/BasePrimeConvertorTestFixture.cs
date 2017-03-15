using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using WindowsFormsApplication1.Bll;

namespace PrimeConvertor.UnitTests.Bll
{
    [TestFixture]
    public class BasePrimeConvertorTestFixture
    {
        private BasePrimeConvertor _convertor;

        [SetUp]
        public void SetUp()
        {
            _convertor = new BasePrimeConvertor();
        }

        [Test]
        [TestCaseSource(nameof(TestGetDividersSource))]
        public void TestGetDividers(int input, int[] expected)
        {
            // arrange
            // act
            var result = _convertor.GetDividers(input);

            // assert
            Assert.That(result.Success, Is.EqualTo(true));
            Assert.That(result.ErrorText, Is.EqualTo(string.Empty));
            Assert.That(result.Dividers.Length, Is.EqualTo(expected.Length));
            Assert.That(result.Dividers.ToList().SequenceEqual(expected.ToList()));
        }

        public static IEnumerable<TestCaseData> TestGetDividersSource()
        {
            yield return new TestCaseData(1, new int[0]);
            yield return new TestCaseData(2, new int[] { 2 });
            yield return new TestCaseData(3, new int[] { 3 });
            yield return new TestCaseData(4, new int[] { 2, 2 });
            yield return new TestCaseData(5, new int[] { 5 });
            yield return new TestCaseData(6, new int[] { 3, 2 });
            yield return new TestCaseData(8, new int[] { 2, 2, 2 });
            yield return new TestCaseData(450, new int[] { 5, 5, 3, 3, 2 });
        }

        [Test]
        [TestCaseSource(nameof(TestGetDividersErrorSource))]
        public void TestGetDividersError(int input, string error)
        {
            // arrange
            // act
            var result = _convertor.GetDividers(input);

            // assert
            Assert.That(result.Success, Is.EqualTo(false));
            Assert.That(result.ErrorText, Is.EqualTo(error));
        }

        public static IEnumerable<TestCaseData> TestGetDividersErrorSource()
        {
            yield return new TestCaseData(-100, "-inf");
            yield return new TestCaseData(-1, "-inf");
            yield return new TestCaseData(0, "-inf");
        }

        [Test]
        public void test() {
            // arrange

            // act
            var result = _convertor.GetHighestPrimeUnderOrEqualToValue(6);

            // assert
            Assert.That(result, Is.EqualTo(5));
        }
    }
}

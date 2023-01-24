using Misc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscNUnitTest
{
    [TestFixture]
    public class FiboNUnitTests
    {
        private Fibo Fibo;

        [SetUp]
        public void SetUp()
        {
            Fibo = new Fibo();
        }

        [Test]
        public void GetFiboSeries_Input0_ReturnsIntList()
        {
            Fibo.Range = 1;
            var result = Fibo.GetFiboSeries();

            Assert.That(result, Is.Not.Empty);
            Assert.That(result, Is.Ordered);
            Assert.That(result, Is.EquivalentTo(new List<int> { 0 }));
        }

        [Test]
        public void GetFiboSeries_Input6_ReturnsIntList()
        {
            Fibo.Range = 6;
            var result = Fibo.GetFiboSeries();

            Assert.That(result, Does.Contain(3));
            Assert.That(result.Count, Is.EqualTo(6));
            Assert.That(result, Does.Not.Contain(4));
            Assert.That(result, Is.EquivalentTo(new List<int> { 0, 1, 1, 2, 3, 5 }));
        }
    }
}

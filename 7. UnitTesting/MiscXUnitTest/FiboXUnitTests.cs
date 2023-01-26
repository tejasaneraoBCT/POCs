using Misc;
using Xunit;

namespace MiscXUnitTest
{
    public class FiboXUnitTests
    {
        private Fibo Fibo;


        public FiboXUnitTests()
        {
            Fibo = new Fibo();

        }

        [Fact]
        public void GetFiboSeries_Input0_ReturnsIntList()
        {
            Fibo.Range = 1;
            var result = Fibo.GetFiboSeries();

            Assert.NotEmpty(result);
            Assert.Equal(result.OrderBy(x=>x), result);
            Assert.Equal(new List<int> { 0 }, result);
        }

        [Fact]
        public void GetFiboSeries_Input6_ReturnsIntList()
        {
            Fibo.Range = 6;
            var result = Fibo.GetFiboSeries();

            Assert.Contains(3, result);
            Assert.Equal(6, result.Count);
            Assert.DoesNotContain(4, result);
            Assert.Equal(new List<int> { 0, 1, 1, 2, 3, 5 }, result);
        }
    }
}

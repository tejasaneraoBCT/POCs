using Misc;
using System.Drawing;
using Xunit;

namespace MiscXUnitTest
{
    public class GradingCalculatorXUnitTests
    {
        private GradingCalculator GradingCalculator;


        public GradingCalculatorXUnitTests()
        {
            GradingCalculator = new GradingCalculator();

        }

        [Fact]
        public void GetGrade_InputScore95Attendance90_ReturnA()
        {
            GradingCalculator.Score = 95;
            GradingCalculator.AttendancePercentage = 90;
            var grade = GradingCalculator.GetGrade();
            Assert.Equal("A", grade);
        }

        [Fact]
        public void GetGrade_InputScore85Attendance90_ReturnB()
        {
            GradingCalculator.Score = 85;
            GradingCalculator.AttendancePercentage = 90;
            var grade = GradingCalculator.GetGrade();
            Assert.Equal("B", grade);
        }

        [Fact]
        public void GetGrade_InputScore65Attendance90_ReturnC()
        {
            GradingCalculator.Score = 65;
            GradingCalculator.AttendancePercentage = 90;
            var grade = GradingCalculator.GetGrade();
            Assert.Equal("C", grade);
        }

        [Fact]
        public void GetGrade_InputScore95Attendance65_ReturnB()
        {
            GradingCalculator.Score = 95;
            GradingCalculator.AttendancePercentage = 65;
            var grade = GradingCalculator.GetGrade();
            Assert.Equal("B", grade);
        }

        [Theory]
        [InlineData(95, 55)]
        [InlineData(65, 55)]
        [InlineData(50, 90)]
        public void GetGrade_InputScoreAttendance_ReturnF(int score, int attendance)
        {
            GradingCalculator.Score = score;
            GradingCalculator.AttendancePercentage = attendance;
            var grade = GradingCalculator.GetGrade();
            Assert.Equal("F", grade);
        }

        [Theory]
        [InlineData(95, 55, "F")]
        [InlineData(50, 90, "F")]
        [InlineData(65, 55, "F")]
        [InlineData(95, 90, "A")]
        [InlineData(85, 90, "B")]
        [InlineData(65, 90, "C")]
        [InlineData(95, 65, "B")]
        public void GetGrade_DifferentInputPossibilitiesForAllGrades_ReturnExpectedGrade(int score, int attendance, string expected)
        {
            GradingCalculator.Score = score;
            GradingCalculator.AttendancePercentage = attendance;
            var result = GradingCalculator.GetGrade();
            Assert.Equal(expected, result);

        }
    }
}

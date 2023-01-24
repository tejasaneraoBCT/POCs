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
    public class GradingCalculatorNUnitTests
    {
        private GradingCalculator GradingCalculator;

        [SetUp]
        public void Setup()
        {
            GradingCalculator = new GradingCalculator();
        }

        [Test]
        public void GetGrade_InputScore95Attendance90_ReturnA()
        {
            GradingCalculator.Score = 95;
            GradingCalculator.AttendancePercentage = 90;
            var grade = GradingCalculator.GetGrade();
            Assert.That(grade, Is.EqualTo("A"));
        }

        [Test]
        public void GetGrade_InputScore85Attendance90_ReturnB()
        {
            GradingCalculator.Score = 85;
            GradingCalculator.AttendancePercentage = 90;
            var grade = GradingCalculator.GetGrade();
            Assert.That(grade, Is.EqualTo("B"));
        }

        [Test]
        public void GetGrade_InputScore65Attendance90_ReturnC()
        {
            GradingCalculator.Score = 65;
            GradingCalculator.AttendancePercentage = 90;
            var grade = GradingCalculator.GetGrade();
            Assert.That(grade, Is.EqualTo("C"));
        }

        [Test]
        public void GetGrade_InputScore95Attendance65_ReturnB()
        {
            GradingCalculator.Score = 95;
            GradingCalculator.AttendancePercentage = 65;
            var grade = GradingCalculator.GetGrade();
            Assert.That(grade, Is.EqualTo("B"));
        }

        [Test]
        [TestCase(95,55)]
        [TestCase(65,55)]
        [TestCase(50, 90)]
        public void GetGrade_InputScoreAttendance_ReturnF(int score, int attendance)
        {
            GradingCalculator.Score = score;
            GradingCalculator.AttendancePercentage = attendance;
            var grade = GradingCalculator.GetGrade();
            Assert.That(grade, Is.EqualTo("F"));
        }

        [Test]
        [TestCase(95, 55, ExpectedResult = "F")]
        [TestCase(65, 55, ExpectedResult = "F")]
        [TestCase(50, 90, ExpectedResult = "F")]
        [TestCase(95, 90, ExpectedResult = "A")]
        [TestCase(85, 90, ExpectedResult = "B")]
        [TestCase(65, 90, ExpectedResult = "C")]
        [TestCase(95, 65, ExpectedResult = "B")]
        public string GetGrade_DifferentInputPossibilitiesForAllGrades_ReturnExpectedGrade(int score, int attendance)
        {
            GradingCalculator.Score = score;
            GradingCalculator.AttendancePercentage = attendance;
            return GradingCalculator.GetGrade();
        }
    }
}

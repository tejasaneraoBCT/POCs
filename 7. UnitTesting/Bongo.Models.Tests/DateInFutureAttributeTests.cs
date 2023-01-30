using Bongo.Models.ModelValidations;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bongo.Models.Tests
{
    [TestFixture]
    public class DateInFutureAttributeTests
    {
        [TestCase(100, ExpectedResult = true)]
        [TestCase(0, ExpectedResult = false)]
        [TestCase(-100, ExpectedResult = false)]
        public bool DateValidator_InputDateRange_DateValidity(int time)
        {
            DateInFutureAttribute dateInFutureAttribute = new(() => DateTime.Now);
            var result = dateInFutureAttribute.IsValid(DateTime.Now.AddSeconds(time));
            return result;
        }

        [Test]
        public void DateValidator_NotValidDate_ReturnErrorMessage()
        {
            var result = new DateInFutureAttribute();
            Assert.That(result.ErrorMessage, Is.EqualTo("Date must be in the future"));
        }
    }
}

using Bongo.Core.Services.IServices;
using Bongo.Models.Model;
using Bongo.Models.Model.VM;
using Bongo.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace Bongo.Web.Tests
{
    [TestFixture]
    public class RoomBookingControllerTests
    {
        private Mock<IStudyRoomBookingService> _studyRoomBookingService;
        private RoomBookingController _bookingController;

        [SetUp]
        public void Setup()
        {
            _studyRoomBookingService= new Mock<IStudyRoomBookingService>();
            _bookingController = new RoomBookingController(_studyRoomBookingService.Object);
        }

        [Test]
        public void IndexPage_CallRequest_VerifyGetAllInvoked()
        {
            _bookingController.Index();
            _studyRoomBookingService.Verify(x => x.GetAllBooking(), Times.Once);
        }

        [Test]
        public void BookRoomCheck_ModelStateInvalid_ReturnView()
        {
            _bookingController.ModelState.AddModelError("test", "test");
            var result = _bookingController.Book(new StudyRoomBooking());
            ViewResult viewResult = result as ViewResult;

            Assert.That(viewResult.ViewName, Is.EqualTo("Book"));
        }

        [Test]
        public void BookRoomCheck_NotSuccessful_NoRoomCode()
        {
            _studyRoomBookingService.Setup(x => x.BookStudyRoom(It.IsAny<StudyRoomBooking>())).Returns(new StudyRoomBookingResult()
            {
                Code = StudyRoomBookingCode.NoRoomAvailable
            });
            var result = _bookingController.Book(new StudyRoomBooking());
            Assert.IsInstanceOf<ViewResult>(result);
            ViewResult viewResult = result as ViewResult;

            Assert.That(viewResult.ViewData["Error"], Is.EqualTo("No Study Room available for selected date"));
        }

        [Test]
        public void BookRoomCheck_Successful_SuccessCode()
        {
            // Arrange
            _studyRoomBookingService.Setup(x => x.BookStudyRoom(It.IsAny<StudyRoomBooking>())).Returns((StudyRoomBooking booking) => new StudyRoomBookingResult()
            {
                Code = StudyRoomBookingCode.Success,
                FirstName = booking.FirstName,
                LastName = booking.LastName,
                Email = booking.LastName,
                Date = booking.Date
            });

            // Act
            var result = _bookingController.Book(new StudyRoomBooking()
            {
                FirstName = "Tejas",
                LastName = "A",
                Date = new DateTime(2023, 1, 1),
                Email = "tejas@ust.com",
                StudyRoomId = 1,
            });

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            RedirectToActionResult actionResult = result as RedirectToActionResult;

            Assert.That(actionResult.RouteValues["FirstName"], Is.EqualTo("Tejas"));
            Assert.That(actionResult.RouteValues["Code"], Is.EqualTo(StudyRoomBookingCode.Success));

        }
    }
}

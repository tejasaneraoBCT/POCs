using Bongo.Core.Services;
using Bongo.DataAccess.Repository.IRepository;
using Bongo.Models.Model;
using Bongo.Models.Model.VM;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bongo.Core.Tests
{
    [TestFixture]
    public class StudyRoomBookingServiceTests
    {
        private Mock<IStudyRoomBookingRepository> _studyRoomBookingRepoMock;
        private Mock<IStudyRoomRepository> _studyRoomRepoMock;
        private StudyRoomBookingService _bookingService;
        private StudyRoomBooking _request;
        private List<StudyRoom> _availableStudyRooms;

        [SetUp]
        public void Setup()
        {
            _studyRoomBookingRepoMock = new Mock<IStudyRoomBookingRepository>();
            _studyRoomRepoMock = new Mock<IStudyRoomRepository>();
            _bookingService = new StudyRoomBookingService(_studyRoomBookingRepoMock.Object, _studyRoomRepoMock.Object);
            _request = new StudyRoomBooking
            {
                FirstName = "Tejas",
                LastName = "A",
                Date = new DateTime(2023, 1, 1),
                Email = "tejas@ust.com",
            };
            _availableStudyRooms = new List<StudyRoom>
            {
                new StudyRoom {Id=10, RoomName="A", RoomNumber="A101"}
            };
            _studyRoomRepoMock.Setup(x => x.GetAll()).Returns(_availableStudyRooms);
        }

        [Test]
        public void GetAllBooking_InvokeMethod_CheckIfRepoIsCalled()
        {
            _bookingService.GetAllBooking();
            _studyRoomBookingRepoMock.Verify(x => x.GetAll(null), Times.Once);
        }

        [Test]
        public void BookingException_NullRequest_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => _bookingService.BookStudyRoom(null));
        }

        [Test]
        public void StudyRoomBooking_SaveBookingWithAvailableRoom_ReturnsResultWithAllValues()
        {
            // Arrange
            StudyRoomBooking savedStudyRoomBooking = null;
            _studyRoomBookingRepoMock.Setup(x => x.Book(It.IsAny<StudyRoomBooking>())).Callback<StudyRoomBooking>(booking =>
            {
                savedStudyRoomBooking = booking;
            });

            // Act
            _bookingService.BookStudyRoom(_request);

            // Assert
            _studyRoomBookingRepoMock.Verify(x => x.Book(It.IsAny<StudyRoomBooking>()), Times.Once);
            Assert.NotNull(savedStudyRoomBooking);
            Assert.That(savedStudyRoomBooking.FirstName, Is.EqualTo(_request.FirstName));
            Assert.That(savedStudyRoomBooking.LastName, Is.EqualTo(_request.LastName));
            Assert.That(savedStudyRoomBooking.Email, Is.EqualTo(_request.Email));
            Assert.That(savedStudyRoomBooking.Date, Is.EqualTo(_request.Date));
            Assert.That(savedStudyRoomBooking.StudyRoomId, Is.EqualTo(_availableStudyRooms.First().Id));
        }

        [Test]
        public void StudyRoomBookingResultCheck_InputRequest_ValuesMatchInResult()
        {
            StudyRoomBookingResult result = _bookingService.BookStudyRoom(_request);
            Assert.NotNull(result);
            Assert.That(_request.FirstName, Is.EqualTo(result.FirstName));
            Assert.That(_request.LastName, Is.EqualTo(result.LastName));
            Assert.That(_request.Email, Is.EqualTo(result.Email));
            Assert.That(_request.Date, Is.EqualTo(result.Date));
        }

        [Test]
        public void ResultCodeSuccess_RoomAvailability_ReturnsSuccessResultCode()
        {
            var result = _bookingService.BookStudyRoom(_request);

            Assert.That(result.Code, Is.EqualTo(StudyRoomBookingCode.Success));
        }

        [TestCase(true, ExpectedResult = StudyRoomBookingCode.Success)]
        [TestCase(false, ExpectedResult = StudyRoomBookingCode.NoRoomAvailable)]
        public StudyRoomBookingCode ResultCodeSuccess_RoomAvailability_ReturnsSuccessResultCode(bool roomAvailable)
        {
            if (!roomAvailable)
            {
                _availableStudyRooms.Clear();
            }
            return _bookingService.BookStudyRoom(_request).Code;
        }

        [TestCase(0, false)]
        [TestCase(10, true)]
        public void StudyRoomBooking_BookRoomWithAvailability_ReturnsBookingId(int expectedBookingId, bool roomAvailable)
        {
            if (!roomAvailable)
            {
                _availableStudyRooms.Clear();
            }

            _studyRoomBookingRepoMock.Setup(x => x.Book(It.IsAny<StudyRoomBooking>())).Callback<StudyRoomBooking>(booking =>
            {
                booking.BookingId = 10;
            });

            var result = _bookingService.BookStudyRoom(_request);
            Assert.That(expectedBookingId, Is.EqualTo(result.BookingId));
            if (!roomAvailable)
            {
                _studyRoomBookingRepoMock.Verify(x => x.Book(It.IsAny<StudyRoomBooking>()), Times.Never);
            }
        }
    }
}

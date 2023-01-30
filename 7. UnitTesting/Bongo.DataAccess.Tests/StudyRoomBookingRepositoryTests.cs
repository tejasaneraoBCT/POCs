using Bongo.DataAccess.Repository;
using Bongo.Models.Model;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bongo.DataAccess.Tests
{
    [TestFixture]
    public class StudyRoomBookingRepositoryTests
    {
        private StudyRoomBooking _studyRoomBooking_One;
        private StudyRoomBooking _studyRoomBooking_Two;
        private DbContextOptions<ApplicationDbContext> _options;

        public StudyRoomBookingRepositoryTests()
        {
            _studyRoomBooking_One = new StudyRoomBooking
            {
                FirstName = "Tejas",
                LastName = "A",
                Date = new DateTime(2023, 1, 1),
                Email = "tejas@ust.com",
                BookingId = 11,
                StudyRoomId = 1,
            };

            _studyRoomBooking_Two = new StudyRoomBooking
            {
                FirstName = "Tejas2",
                LastName = "A2",
                Date = new DateTime(2023, 1, 1),
                Email = "tejas2@ust.com",
                BookingId = 22,
                StudyRoomId = 2,
            };
        }

        [SetUp] 
        public void SetUp()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "bongo_temp_db").Options;
        }

        [Test]
        public void SaveBooking_Booking_One_CheckTheValuesFromDatabase()
        {
            // Arrange

            // Act
            using(var context = new ApplicationDbContext(_options))
            {
                context.Database.EnsureDeleted();
                var respository = new StudyRoomBookingRepository(context);
                respository.Book(_studyRoomBooking_One);
            }

            // Assert
            using (var context = new ApplicationDbContext(_options))
            {
                var bookingFromDb = context.StudyRoomBookings.FirstOrDefault(x=>x.BookingId == 11);
                Assert.IsNotNull(bookingFromDb);
                Assert.That(bookingFromDb.BookingId, Is.EqualTo(_studyRoomBooking_One.BookingId));
                Assert.That(bookingFromDb.FirstName, Is.EqualTo(_studyRoomBooking_One.FirstName));
                Assert.That(bookingFromDb.LastName, Is.EqualTo(_studyRoomBooking_One.LastName));
                Assert.That(bookingFromDb.Email, Is.EqualTo(_studyRoomBooking_One.Email));
                Assert.That(bookingFromDb.Date, Is.EqualTo(_studyRoomBooking_One.Date));
            }
        }

        [Test]
        public void GetAllBookings_BookingOneAndTwo_CheckBothTheBookingsFromDatabase()
        {
            // Arrange
            var expectedResult = new List<StudyRoomBooking> { _studyRoomBooking_One, _studyRoomBooking_Two };

            using (var context = new ApplicationDbContext(_options))
            {
                context.Database.EnsureDeleted();
                var respository = new StudyRoomBookingRepository(context);
                respository.Book(_studyRoomBooking_One);
                respository.Book(_studyRoomBooking_Two);
            }

            // Act
            List<StudyRoomBooking> actualList;
            using (var context = new ApplicationDbContext(_options))
            {
                var respository = new StudyRoomBookingRepository(context);
                actualList = respository.GetAll(null).ToList();
            }

            // Assert
            CollectionAssert.AreEqual(expectedResult, actualList, new BookingCompare());
            
        }

        private class BookingCompare : IComparer
        {
            public int Compare(object? x, object? y)
            {
                var booking1 = x as StudyRoomBooking;
                var booking2 = y as StudyRoomBooking;

                if (booking1.BookingId != booking2.BookingId)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}

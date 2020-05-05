using System;

namespace _02.ESGI.DesignPattern.Polymorphisme
{
    public interface IClockService
    {
        DateTime Now();
    }

    public class ClockService : IClockService
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }

    public class MockClockService : IClockService
    {
        private DateTime _dateTimeToReturn;

        public MockClockService(DateTime dateTimeToReturn)
        {
            _dateTimeToReturn = dateTimeToReturn;
        }

        public DateTime Now()
        {
            return _dateTimeToReturn;
        }
    }

    public class Lesson
    {
        private DateTime _lessonStartDateTime;

        public Lesson(DateTime lessonStartDateTime)
        {
            _lessonStartDateTime = lessonStartDateTime;
        }

        public bool IsBreakTime(IClockService clockService)
        {
            var now = clockService.Now();

            return now - _lessonStartDateTime > new TimeSpan(1, 30, 00);
        }
    }
}

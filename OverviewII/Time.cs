using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace OverviewII
{
    public class Time
    {
        public  DateTime _time;
        public Time(DateTime time)
        {
            _time = time;
        }

        public string PrintTheCurrentHour()
        {
            return _time.ToString("HH:mm:ss zzz");
        }

        public void Add(DateTime newTime)
        {
            _time = new DateTime(_time.Ticks + newTime.Ticks);
        }

        public void Subtraction(DateTime newTime)
        {
            _time = new DateTime(_time.Ticks - newTime.Ticks);
        }
        public List<DateTime> Sort(List<DateTime> allDates)
        {
           var PM = allDates
                .Where(d => d.ToString("tt", CultureInfo.InvariantCulture) == "PM").ToList()
                .OrderBy(d => d.TimeOfDay).ToList();

            var AM = allDates
                 .Where(d => d.ToString("tt", CultureInfo.InvariantCulture) == "AM").ToList()
                 .OrderBy(d => d.TimeOfDay).ToList();

           AM.AddRange(PM);

           return AM;
        }

        public static bool operator ==(Time time1, Time time2)
        {
            return time1._time.TimeOfDay.Equals(time2._time.TimeOfDay);
        }
        public static bool operator !=(Time time1, Time time2)
        {
            return !(time1._time==time2._time);
        }

    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Pr6
{
    class WebsiteAttendance : IEquatable<WebsiteAttendance>
    {
        private string[] _ipAddress;
        private DateTime[] _attendanceTime;
        private string[] _dayOfWeek;

        public WebsiteAttendance(string[] ipAddress, DateTime[] attendanceTime, string[] dayOfWeek)
        {
            _ipAddress = ipAddress;
            _attendanceTime = attendanceTime;
            _dayOfWeek = dayOfWeek;
        }

        public WebsiteAttendance()
        {
            ReadFromFile("D:\\Courses\\Sigma\\Pr6\\Pr6\\AttendanceRecords.txt");
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as WebsiteAttendance);
        }

        public bool Equals(WebsiteAttendance other)
        {
            return other != null &&
                   _ipAddress == other._ipAddress &&
                   _attendanceTime == other._attendanceTime &&
                   _dayOfWeek == other._dayOfWeek;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_ipAddress, _attendanceTime, _dayOfWeek);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public void ReadFromFile(string filePath)
        {
            string readText;
            using (StreamReader reader = new StreamReader(filePath))
            {
                readText = reader.ReadToEnd();
            }
            string[] oneRecord = readText.Split("\\n");
            string[] elements;
            DayOfWeek val;
            
            for (var i = 0; i < readText.Length; i++)
            {    
                elements = oneRecord[i].Split(" ");
                _ipAddress[i] = elements[0];
                _attendanceTime[i] = Convert.ToDateTime(elements[1]);
                if (Enum.TryParse(elements[2], out val))
                {
                    _dayOfWeek[i] = elements[2];
                }
            }
        }
    }
}

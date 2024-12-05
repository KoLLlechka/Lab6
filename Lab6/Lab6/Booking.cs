using DocumentFormat.OpenXml.Drawing.Spreadsheet;
using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Lab6
{
    internal class Booking
    {
        public int ClientId;
        public int RoomId;
        public DateTime BookingDate;
        public DateTime CheckInDate;
        public DateTime CheckOutDate;

        public Booking()
        {
            ClientId = 0;
            RoomId = 0;
            BookingDate = DateTime.MinValue;
            CheckInDate = DateTime.MinValue;
            CheckOutDate = DateTime.MinValue;
        }

        public Booking(int clientId, int roomId, DateTime bookingDate, DateTime checkInDate,
            DateTime checkOutDate)
        {
            ClientId = clientId; 
            RoomId = roomId; 
            BookingDate = bookingDate; 
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
        }

        public override string ToString()
        {
            return $"{ClientId, -8}{RoomId, -8}{BookingDate.ToString().Substring(0,10), -13}" +
                $"{CheckInDate.ToString().Substring(0, 10), -12}" +
                $"{CheckOutDate.ToString().Substring(0, 10)}";
        }
    }
}

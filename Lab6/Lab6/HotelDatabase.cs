using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using ClosedXML;

namespace Lab6
{
    internal class HotelDatabase
    {
        public Dictionary<int, Client> clients { get; }
        public Dictionary<int, Room> rooms { get; }
        public Dictionary<int, Booking> bookings { get; }
        private string pathXLS = Path.GetFullPath(@"..\..\files\LR6-var9.xls");
        private string pathXLSX = Path.GetFullPath(@"..\..\files\LR6-var9.xlsx");

        public HotelDatabase()
        {
            if (!File.Exists(pathXLS)) throw new Exception();

            if (!File.Exists(pathXLSX))
            {
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook workbook = excelApp.Workbooks.Open(pathXLS);
                workbook.SaveAs(pathXLSX, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook);
                workbook.Close();
                excelApp.Quit();
            }

            try
            {
                using (XLWorkbook wb = new XLWorkbook(pathXLSX))
                {
                    IXLWorksheet ws = wb.Worksheet(1);

                    clients = ws.RowsUsed()
                                          .Skip(1)
                                          .ToDictionary(
                                              row => (int)row.Cell(1).Value.GetNumber(),
                                              row => new Client(row.Cell(2).GetText(), 
                                              row.Cell(3).GetText(), row.Cell(4).GetText(), 
                                              row.Cell(5).GetText())
                                          );

                    ws = wb.Worksheet(2);

                    bookings = ws.RowsUsed()
                                          .Skip(1)
                                          .ToDictionary(
                                              row => (int)row.Cell(1).Value.GetNumber(),
                                              row => new Booking((int)row.Cell(2).Value.GetNumber(), 
                                              (int)row.Cell(3).Value.GetNumber(), 
                                              row.Cell(4).GetDateTime(), row.Cell(5).GetDateTime(), 
                                              row.Cell(6).GetDateTime())
                                          );

                    ws = wb.Worksheet(3);

                    rooms = ws.RowsUsed()
                                          .Skip(1)
                                          .ToDictionary(
                                              row => (int)row.Cell(1).Value.GetNumber(),
                                              row => new Room((int)row.Cell(2).Value.GetNumber(),
                                              (int)row.Cell(3).Value.GetNumber(),
                                              (int)row.Cell(4).Value.GetNumber(),
                                              (int)row.Cell(5).Value.GetNumber())
                                          );
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddInRooms(int id, int f, int cap, int p, int cat)
        {
            rooms[id] = new Room(f, cap, p, cat);
        }

        public void AddInBookings(int id, int cid, int rid, DateTime db, DateTime ind, DateTime outd)
        {
            bookings[id] = new Booking(cid, rid, db, ind, outd);
        }

        public void AddInClients(int id, string n, string sn, string p, string res)
        {
            clients[id] = new Client(n, sn, p, res);
        }

        public void CorrectInRooms(int id, int column, string zam)
        {
            foreach (var el in rooms.Keys)
            {
                if (el == id)
                {
                    switch (column)
                    {
                        case 2: rooms[el].Floor = int.Parse(zam); break;
                        case 3: rooms[el].Capacity = int.Parse(zam); break;
                        case 4: rooms[el].Price = int.Parse(zam); break;
                        case 5: rooms[el].Category = int.Parse(zam); break;
                    }
                    break;
                }
            }
        }

        public void CorrectInBookings(int id, int column, string zam)
        {
            foreach (var el in bookings.Keys)
            {
                if (el == id)
                {
                    switch (column)
                    {
                        case 2: bookings[el].ClientId = int.Parse(zam); break;
                        case 3: bookings[el].RoomId = int.Parse(zam); break;
                        case 4: bookings[el].BookingDate = DateTime.Parse(zam); break;
                        case 5: bookings[el].CheckInDate = DateTime.Parse(zam); break;
                        case 6: bookings[el].CheckOutDate = DateTime.Parse(zam); break;
                    }
                    break;
                }
            }
        }

        public void CorrectInClients(int id, int column, string zam)
        {
            foreach(var el in clients.Keys)
            {
                if (el == id)
                {
                    switch(column)
                    {
                        case 2: clients[el].Surname = zam; break;
                        case 3: clients[el].Patronymic = zam; break;
                        case 4: clients[el].Residence = zam; break;
                    }
                    break;
                }
            }
        }

        public void DeleteInRooms(int del)
        {
            rooms.Remove(del);
        }

        public void DeleteInBookings(int del)
        {
            bookings.Remove(del);
        }

        public void DeleteInClients(int del)
        {
            clients.Remove(del);
        }

        public string PrintHotel<T>(Dictionary<int, T> d, string s) where T : class
        {
            string result = string.Empty;
            int i = 0;
            foreach (var k in d.Keys)
            {
                if (i == 5)
                    break;
                else
                    result += "   " + k.ToString() + s + d[k].ToString() + "\n";   
                i++;
            }
            result += "   ....\n   " + d.Count();
            return result;
        }
    }
}

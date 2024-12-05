using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab6
{
    internal class Room
    {
        public int Floor;
        public int Capacity;
        public int Price;
        public int Category;

        public Room()
        {
            Floor = 0;
            Capacity = 0;
            Price = 0;
            Category = 0;
        }

        public Room(int floor, int capacity, int price, int category)
        {
            Floor = floor;
            Capacity = capacity;
            Price = price;
            Category = category;
        }

        public override string ToString()
        {
            return $"{Floor, -8}{Capacity, -7}{Price + " р.", -15}{Category}";
        }
    }
}

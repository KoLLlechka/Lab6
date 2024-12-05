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
    internal class Client
    {
        public string Surname;
        public string Name;
        public string Patronymic;
        public string Residence;

        public Client(string surname, string name, string patronymic, string residence)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Residence = residence;
        }

        public override string ToString()
        {
            return $"{Surname, -13}{Name, -12}{Patronymic, -15}{Residence}";
        }
    }
}

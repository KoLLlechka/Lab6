using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.ComponentModel;
//using System.Windows.Shapes;

namespace Lab6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string textTask;
        private bool isOpen = false;
        private HotelDatabase hotelDatabase = null;
        private string path = Path.GetFullPath(@"..\..\files\protokol.txt");
        string forFile = string.Empty;
        private Logger logger = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        void DataWindow_Closing(object sender, CancelEventArgs e)
        {
            logger.Log("Клик на кнопку закрытия приложения");
            logger.Log("Приложение закрыто");
        }

        private void fornew_Click(object sender, RoutedEventArgs e)
        {
            fornew.Visibility = Visibility.Collapsed;
            forold.Visibility = Visibility.Collapsed;
            protocol.Visibility = Visibility.Collapsed;
            logger = new Logger(path);
            logger.Clear();
            logger.Log("Клик на кнопку создания нового файла");
            tasksComboBox.Visibility = Visibility.Visible;
            forTasksCombo.Visibility = Visibility.Visible;
            task.Visibility = Visibility.Visible;
        }

        private void forold_Click(object sender, RoutedEventArgs e)
        {
            fornew.Visibility = Visibility.Collapsed;
            forold.Visibility = Visibility.Collapsed;
            protocol.Visibility = Visibility.Collapsed;
            logger = new Logger(path);
            logger.Log("Клик на кнопку записывания в старый файл");
            tasksComboBox.Visibility = Visibility.Visible;
            forTasksCombo.Visibility = Visibility.Visible;
            task.Visibility = Visibility.Visible;
        }

        private void tasksComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            textTask = tasksComboBox.SelectedItem.ToString().Substring(38);
            answer.Content = "";
            answer.Visibility = Visibility.Visible;
            add.Visibility = Visibility.Collapsed;
            table.Visibility = Visibility.Collapsed;
            ontable.Visibility = Visibility.Collapsed;
            switch (textTask)
            {
                case "Lab 6: Пункт 1":
                    logger.Log("В tasksComboBox выбрано \"Lab 6: Пункт 1\"");
                    answer.Content = "";
                    task.Content = "Чтение базы данных из excel файла";
                    ValueText("", "", "", "", "", "", "");
                    VisibleValue(Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, 
                        Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, 
                        Visibility.Collapsed);
                    value3.Height = 100;
                    value4.Height = 100;
                    ChangedTask(Visibility.Collapsed);
                    break;
                case "Lab 6: Пункт 2":
                    logger.Log("В tasksComboBox выбрано \"Lab 6: Пункт 2\"");
                    answer.Content = "";
                    task.Content = "Просмотр базы данных";
                    ValueText("Table", "", "", "", "", "", "");
                    VisibleValue(Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed,
                        Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed,
                        Visibility.Collapsed);
                    ChangedTask(Visibility.Visible);
                    break;
                case "Lab 6: Пункт 3":
                    logger.Log("В tasksComboBox выбрано \"Lab 6: Пункт 3\"");
                    answer.Content = "";
                    task.Content = "Удаление элементов (по ключу)";
                    ValueText("Table", "El", "", "", "", "", "");
                    VisibleValue(Visibility.Visible, Visibility.Visible, Visibility.Collapsed,
                        Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed,
                        Visibility.Collapsed);
                    ChangedTask(Visibility.Visible);
                    break;
                case "Lab 6: Пункт 4":
                    logger.Log("В tasksComboBox выбрано \"Lab 6: Пункт 4\"");
                    answer.Content = "";
                    task.Content = "Корректировка элементов (по ключу)";
                    ValueText("Table", "Id", "Col", "Zam", "", "", "");
                    VisibleValue(Visibility.Visible, Visibility.Visible, Visibility.Visible,
                        Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed,
                        Visibility.Collapsed);
                    //value3.Height = 18;
                    ChangedTask(Visibility.Visible);
                    break;
                case "Lab 6: Пункт 5":
                    logger.Log("В tasksComboBox выбрано \"Lab 6: Пункт 5\"");
                    answer.Content = "";
                    task.Content = "Добавление элементов";
                    ValueText("", "", "", "", "", "", "");
                    VisibleValue(Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed,
                        Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed,
                        Visibility.Collapsed);
                    table.Visibility = Visibility.Visible;
                    ontable.Visibility = Visibility.Visible;
                    //value3.Height = 18;
                    input.Visibility = Visibility.Collapsed;
                    outputButton.Visibility = Visibility.Collapsed;
                    break;
                case "Lab 6: Пункт 6.1":
                    logger.Log("В tasksComboBox выбрано \"Lab 6: Пункт 6.1\"");
                    answer.Content = "";
                    task.Content = "Запрос с обращением к одной таблице\n\n" +
                        "Определить количество забронированных номеров категории 5\n" +
                        "и вывести их коды";
                    ValueText("", "", "", "", "", "", "");
                    VisibleValue(Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed,
                        Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed,
                        Visibility.Collapsed); 
                    //value3.Height = 18;
                    ChangedTask(Visibility.Collapsed);
                    break;
                case "Lab 6: Пункт 6.2":
                    logger.Log("В tasksComboBox выбрано \"Lab 6: Пункт 6.2\"");
                    answer.Content = "";
                    task.Content = "Запрос с обращением к двум таблицам\n\n" +
                        "Определить общую стоимость проживания за сутки в номерах,\n" +
                        "находящихся на 7 этаже и забронированных с 3 по 12 июня\n" +
                        "включительно";
                    ValueText("", "", "", "", "", "", "");
                    VisibleValue(Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed,
                        Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed,
                        Visibility.Collapsed); 
                    //value3.Height = 18;
                    ChangedTask(Visibility.Collapsed);
                    break;
                case "Lab 6: Пункт 6.3":
                    logger.Log("В tasksComboBox выбрано \"Lab 6: Пункт 6.3\"");
                    answer.Content = "";
                    task.Content = "Первый запрос с обращением к трем таблицам\n\n" +
                        "Определите общую стоимость проживания за сутки в номерах\n" +
                        "категории 5, забронированных клиентами из г. Уфа с 1 по 16 июня\n" +
                        "включительно";
                    ValueText("", "", "", "", "", "", "");
                    VisibleValue(Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed,
                        Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed,
                        Visibility.Collapsed); 
                    //value3.Height = 18;
                    ChangedTask(Visibility.Collapsed);
                    break;
                case "Lab 6: Пункт 6.4":
                    logger.Log("В tasksComboBox выбрано \"Lab 6: Пункт 6.4\"");
                    answer.Content = "";
                    task.Content = "Второй запрос с обращением к трем таблицам\n\n" +
                        "Определить общее количество номеров категории 1, забронированных\n" +
                        "клиентами с фамилией, начинающуюся на \"А\" с 11 по 23 июня\n" +
                        "включительно и вывести коды номеров";
                    ValueText("", "", "", "", "", "", "");
                    VisibleValue(Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed,
                        Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed,
                        Visibility.Collapsed); 
                    //value3.Height = 18;
                    ChangedTask(Visibility.Collapsed);
                    break;
                default:
                    break;
            }
        }

        private void table_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            textTask = table.SelectedItem.ToString().Substring(38);
            ChangedTask(Visibility.Visible);
            switch (textTask)
            {
                case "Клиенты":
                    logger.Log("В tableComboBox выбрано \"Клиенты\"");
                    ValueText("Id", "Surname", "Name", "Patr", "Resid", "", "");
                    VisibleValue(Visibility.Visible, Visibility.Visible, Visibility.Visible,
                        Visibility.Visible, Visibility.Visible, Visibility.Collapsed,
                        Visibility.Collapsed);
                    break;
                case "Бронирование":
                    logger.Log("В tableComboBox выбрано \"Бронирование\"");
                    ValueText("Id", "Client", "Room", "Date", "DateIn", "DateOut", "");
                    VisibleValue(Visibility.Visible, Visibility.Visible, Visibility.Visible,
                        Visibility.Visible, Visibility.Visible, Visibility.Visible,
                        Visibility.Collapsed);
                    break;
                case "Номера":
                    logger.Log("В tableComboBox выбрано \"Номера\"");
                    ValueText("Id", "Floor", "Capas", "Price", "Categ", "", "");
                    VisibleValue(Visibility.Visible, Visibility.Visible, Visibility.Visible,
                        Visibility.Visible, Visibility.Visible, Visibility.Collapsed,
                        Visibility.Collapsed);
                    break;
            }
        }

        private void ValueText(string v1, string v2, string v3, string v4, string v5, string v6,
            string v7)
        {
            value1.Text = "";
            value2.Text = "";
            value3.Text = "";
            value4.Text = "";
            value5.Text = "";
            value6.Text = "";
            value7.Text = "";
            valueText1.Content = v1;
            valueText2.Content = v2;
            valueText3.Content = v3;
            valueText4.Content = v4;
            valueText5.Content = v5;
            valueText6.Content = v6;
            valueText7.Content = v7;
        }

        private void VisibleValue(Visibility v1, Visibility v2, Visibility v3, Visibility v4,
            Visibility v5, Visibility v6, Visibility v7)
        {
            value1.Visibility = v1;
            value2.Visibility = v2;
            value3.Visibility = v3;
            value4.Visibility = v4;
            value5.Visibility = v5;
            value6.Visibility = v6;
            value7.Visibility = v7;
            valueText1.Visibility = v1;
            valueText2.Visibility = v2;
            valueText3.Visibility = v3;
            valueText4.Visibility = v4;
            valueText5.Visibility = v5;
            valueText6.Visibility = v6;
            valueText7.Visibility = v7;
        }

        private void ChangedTask(Visibility v1)
        {
            input.Visibility = v1;
            outputButton.Visibility = Visibility.Visible;
        }

        public string InputIsCorrect(Func<bool> isCorrect, Func<string> resultFunc)
        {
            if (isCorrect())
            {
                return resultFunc();
            }
            else
            {
                return "Ввод не корректен";
            }
        }

        private void outputButton_Click(object sender, RoutedEventArgs e)
        {
            textTask = tasksComboBox.SelectedItem.ToString().Substring(38);
            switch (textTask)
            {
                case "Lab 6: Пункт 1":
                    answer.Content = Paragraph1();
                    break;
                case "Lab 6: Пункт 2":
                    answer.Content = InputIsCorrect(
                        () => InputCheck.IsStringToInt(value1.Text) &&
                        InputCheck.IsIntOneThree(value1.Text),
                        () => Paragraph2());
                    break;
                case "Lab 6: Пункт 3":
                    answer.Content = InputIsCorrect(
                        () => InputCheck.IsStringToInt(value1.Text) &&
                        InputCheck.IsIntOneThree(value1.Text) && 
                        InputCheck.IsStringToInt(value2.Text),
                        () => Paragraph3());
                    break;
                case "Lab 6: Пункт 4":
                    answer.Content = InputIsCorrect(
                        () => InputCheck.IsStringToInt(value1.Text) &&
                        InputCheck.IsIntOneThree(value1.Text) &&
                        InputCheck.IsStringToInt(value2.Text),
                        () => Paragraph4());
                    break;
                case "Lab 6: Пункт 5":
                    answer.Content = Paragraph5();
                    break;
                case "Lab 6: Пункт 6.1":
                    answer.Content = Paragraph6_1();
                    break;
                case "Lab 6: Пункт 6.2":
                    answer.Content = Paragraph6_2();
                    break;
                case "Lab 6: Пункт 6.3":
                    answer.Content = Paragraph6_3();
                    break;
                case "Lab 6: Пункт 6.4":
                    answer.Content = Paragraph6_4();
                    break;
            }
        }

        private string Paragraph6_4()
        {
            logger.Log("Запрос с обращением к трем таблицам");
            string result = "Получившееся количество: ";
            if (!isOpen)
            {
                hotelDatabase = new HotelDatabase();
                isOpen = true;
            }

            var onA = from el in hotelDatabase.clients.Keys
                          where
                          hotelDatabase.clients[el].Surname.StartsWith("А")
                          select el;

            var eleven_twentythree = from el in hotelDatabase.bookings.Keys
                              where
                            (hotelDatabase.bookings[el].BookingDate >= DateTime.Parse("07.06.2019"))
                            && (hotelDatabase.bookings[el].BookingDate <= DateTime.Parse("23.06.2019"))
                              select hotelDatabase.bookings[el].ClientId;

            var ourCl = onA.Intersect(eleven_twentythree);

            var ourRooms = from el in hotelDatabase.bookings.Keys
                           where
                           ourCl.Contains(hotelDatabase.bookings[el].ClientId)
                           select hotelDatabase.bookings[el].RoomId;

            var oneCat = from el in ourRooms
                            where (hotelDatabase.rooms[el].Category == 1)
                            select el;

            result += oneCat.Count() + "\nКоды номеров:\n";
            int i = 0;
            foreach (var room in oneCat)
            {
                if (i % 10 == 0)
                    result += "\n";
                result += room + ", ";
                i++;
            }
            logger.Log("Запрос успешно обработан");
            return result.Substring(0, result.Length - 2);
        }

        private string Paragraph6_3()
        {
            logger.Log("Запрос с обращением к трем таблицам");
            string result = "Получившаяся сумма: ";
            if (!isOpen)
            {
                hotelDatabase = new HotelDatabase();
                isOpen = true;
            }

            var fromUfa = from el in hotelDatabase.clients.Keys
                          where
                          hotelDatabase.clients[el].Residence == "г. Уфа"
                          select el;

            var one_sixteen = from el in hotelDatabase.bookings.Keys
                               where
                             (hotelDatabase.bookings[el].BookingDate >= DateTime.Parse("01.06.2019"))
                             && (hotelDatabase.bookings[el].BookingDate <= DateTime.Parse("16.06.2019"))
                               select hotelDatabase.bookings[el].ClientId;

            var ourCl = fromUfa.Intersect(one_sixteen);

            var ourRooms = from el in hotelDatabase.bookings.Keys
                           where 
                           ourCl.Contains(hotelDatabase.bookings[el].ClientId)
                           select hotelDatabase.bookings[el].RoomId;

            var fiveCat = from el in ourRooms
                            where (hotelDatabase.rooms[el].Category == 5)
                             select hotelDatabase.rooms[el].Price;

            result += fiveCat.Sum();
            logger.Log("Запрос успешно обработан");
            return result;
        }

        private string Paragraph6_2()
        {
            logger.Log("Запрос с обращением к двум таблицам");
            string result = "Получившаяся сумма: ";
            if (!isOpen)
            {
                hotelDatabase = new HotelDatabase();
                isOpen = true;
            }
            var three_Twelve = from el in hotelDatabase.bookings.Keys where
                             (hotelDatabase.bookings[el].BookingDate >= DateTime.Parse("03.06.2019"))
                             && (hotelDatabase.bookings[el].BookingDate <= DateTime.Parse("12.06.2019"))
                             select hotelDatabase.bookings[el].RoomId;

            var sevenFloor = from el in three_Twelve
                             where (hotelDatabase.rooms[el].Floor == 7)
                             select hotelDatabase.rooms[el].Price;

            result += sevenFloor.Sum() + "\n";
            logger.Log("Запрос успешно обработан");
            return result;
        }

        private string Paragraph6_1()
        {
            logger.Log("Вызван запрос с обращением к одной таблице");
            string result = "Количество забронированных номеров категории 5: ";
            if (!isOpen)
            {
                hotelDatabase = new HotelDatabase();
                isOpen = true;
            }
            var roomsNum = from el in hotelDatabase.rooms.Keys where
                                             hotelDatabase.rooms[el].Category == 5
                                             select el;
            result += roomsNum.Count() + "\nКоды номеров:\n";
            int i = 0;
            foreach(var room in roomsNum)
            {
                if (i % 10 == 0)
                    result += "\n";
                result += room + ", ";
                i++;
            }
            logger.Log("Запрос успешно обработан");
            return result.Substring(0, result.Length - 2);
        }

        private string Paragraph5()
        {
            textTask = table.SelectedItem.ToString().Substring(38);
            logger.Log("Вызвано добавление элементов");
            string result = string.Empty;
            if (!isOpen)
            {
                hotelDatabase = new HotelDatabase();
                isOpen = true;
            }
            if (textTask == "Клиенты")
            {
                result = "  Код    Фамилия      Имя         Отчество         Место\n" +
                         "клиента                                          жительства\n\n";
                hotelDatabase.AddInClients(int.Parse(value1.Text), value2.Text, value3.Text,
                    value4.Text, value5.Text);
                result += hotelDatabase.PrintHotel(hotelDatabase.clients, "     ");
            }
            else if (textTask == "Бронирование")
            {
                result = "    Код         Код     Код        Дата         Дата        Дата\n" +
                         "бронирования  клиента  номера  бронирования    заезда      выезда\n\n";
                hotelDatabase.AddInBookings(int.Parse(value1.Text), int.Parse(value2.Text),
                    int.Parse(value3.Text), DateTime.Parse(value4.Text), DateTime.Parse(value5.Text),
                    DateTime.Parse(value6.Text));
                result += hotelDatabase.PrintHotel(hotelDatabase.bookings, "        ");
            }
            else if (textTask == "Номера")
            {
                result = "   Код     Этаж   Число   Стоимость   Категория\n" +
                         "  номера          мест    проживания\n\n";
                hotelDatabase.AddInRooms(int.Parse(value1.Text), int.Parse(value2.Text),
                    int.Parse(value3.Text), int.Parse(value4.Text), int.Parse(value5.Text));
                result += hotelDatabase.PrintHotel(hotelDatabase.rooms, "     ");
            }
            logger.Log("Добавление элементов прошло успешно");
            return result;
        }

        private string Paragraph4()
        {
            logger.Log("Вызвано корректировка элементов (по ключу)");
            string result = string.Empty;
            if (!isOpen)
            {
                hotelDatabase = new HotelDatabase();
                isOpen = true;
            }
            if (value1.Text == "1")
            {
                result = "  Код    Фамилия      Имя         Отчество         Место\n" +
                         "клиента                                          жительства\n\n";
                hotelDatabase.CorrectInClients(int.Parse(value2.Text), int.Parse(value3.Text),
                    value4.Text);
                result += hotelDatabase.PrintHotel(hotelDatabase.clients, "     ");
            }
            else if (value1.Text == "2")
            {
                result = "    Код         Код     Код        Дата         Дата        Дата\n" +
                         "бронирования  клиента  номера  бронирования    заезда      выезда\n\n";
                hotelDatabase.CorrectInBookings(int.Parse(value2.Text), int.Parse(value3.Text),
                    value4.Text);
                result += hotelDatabase.PrintHotel(hotelDatabase.bookings, "        ");
            }
            else if (value1.Text == "3")
            {
                result = "   Код     Этаж   Число   Стоимость   Категория\n" +
                         "  номера          мест    проживания\n\n";
                hotelDatabase.CorrectInRooms(int.Parse(value2.Text), int.Parse(value3.Text),
                    value4.Text);
                result += hotelDatabase.PrintHotel(hotelDatabase.rooms, "     ");
            }
            logger.Log("Корректировка элементов (по ключу) прошла успешно");
            return result;
        }

        private string Paragraph3()
        {
            logger.Log("Вызвано удаление элементов (по ключу)");
            string result = string.Empty;
            if (!isOpen)
            {
                hotelDatabase = new HotelDatabase();
                isOpen = true;
            }
            if (value1.Text == "1")
            {
                result = "  Код    Фамилия      Имя         Отчество         Место\n" +
                         "клиента                                          жительства\n\n";
                hotelDatabase.DeleteInClients(int.Parse(value2.Text));
                result += hotelDatabase.PrintHotel(hotelDatabase.clients, "     ");
            }
            else if (value1.Text == "2")
            {
                result = "    Код         Код     Код        Дата         Дата        Дата\n" +
                         "бронирования  клиента  номера  бронирования    заезда      выезда\n\n";
                hotelDatabase.DeleteInBookings(int.Parse(value2.Text));
                result += hotelDatabase.PrintHotel(hotelDatabase.bookings, "        ");
            }
            else if (value1.Text == "3")
            {
                result = "   Код     Этаж   Число   Стоимость   Категория\n" +
                         "  номера          мест    проживания\n\n";
                hotelDatabase.DeleteInRooms(int.Parse(value2.Text));
                result += hotelDatabase.PrintHotel(hotelDatabase.rooms, "     ");
            }
            logger.Log("Удаление элементов (по ключу) прошло успешно");
            return result;
        }

        private string Paragraph2()
        {
            logger.Log("Вызван просмотр базы данных");
            string result = string.Empty;
            if (!isOpen)
            {
                hotelDatabase = new HotelDatabase();
                isOpen = true;
            }
            if (value1.Text == "1")
            {
                result = "  Код    Фамилия      Имя         Отчество         Место\n" +
                         "клиента                                          жительства\n\n";
                result += hotelDatabase.PrintHotel(hotelDatabase.clients, "     ");
            }
            else if (value1.Text == "2")
            {
                result = "    Код         Код     Код        Дата         Дата        Дата\n" +
                         "бронирования  клиента  номера  бронирования    заезда      выезда\n\n";
                result += hotelDatabase.PrintHotel(hotelDatabase.bookings, "        ");
            }
            else if (value1.Text == "3")
            {
                result = "   Код     Этаж   Число   Стоимость   Категория\n" +
                         "  номера          мест    проживания\n\n";
                result += hotelDatabase.PrintHotel(hotelDatabase.rooms, "     ");
            }
            logger.Log("Просмотр базы данных прошел успешно");
            return result;
        }

        private string Paragraph1()
        {
            logger.Log("Вызвано чтение базы данных");
            hotelDatabase = new HotelDatabase();
            logger.Log("Чтение базы данных прошло успешно");
            isOpen = true;
            return "Чтение файла прошло успешно";
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        
    }
}

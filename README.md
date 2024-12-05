# Лабораторная работа №6. LINQ-запросы. Вариант 9
Разработать консольное приложение с дружественным интерфейсом с возможностью выбора
заданий. Приложение должно выполнять следующие функции:
1. Чтение базы данных из excel файла.
2. Просмотр базы данных.
3. Удаление элементов (по ключу).
4. Корректировка элементов (по ключу).
5. Добавление элементов.
6. Реализация 4 запросов (формулировки запросов придумать самостоятельно и отразить в
отчёте, можно использовать запрос, данный в примере):  
  1 запрос с обращением к одной таблице  
  1 запрос с обращением к двум таблицам
  2 запроса с обращением к трем таблицам
2 запроса должны возвращать перечень, 2 запроса одно значение.
7. Во время всего сеанса работы ведется полное протоколирование действий в текстовом
файле (в начале сеанса запросить, будет ли это новый файл или дописывать в уже
существующий).   

Элементами базы данных являются объекты классов согласно вашему варианту. Содержание классов
определить самостоятельно и отразить в отчете (в классах должны присутствовать свойства,
конструкторы, перегруженный метод ToString). Весь функционал приложения реализовать в виде
методов вспомогательного класса с помощью LINQ-запросов.
Предусмотреть обработку возможных ошибок при работе программы.

В файле LR6-var9.xls приведён фрагмент базы данных «Гостиница». База данных состоит из трёх
таблиц. Таблица «Клиенты» содержит данные о клиентах: ФИО и место жительства. Таблица
«Бронирование» содержит информацию о зарегистрированных заявках на бронирование номеров:
код клиента, код номера, номер бронирования, дата бронирования, дата заезда, дата выезда. Таблица
«Номера» содержит информацию о забронированных номерах гостиницы: код номера, номер
комнаты, этаж, число мест, стоимость проживания за сутки, категория гостиницы. На рисунке
приведена схема указанной базы данных.

## 1 Запрос
Определить количество забронированных номеров категории 5 и вывести их коды

## 2 Запрос
Определить общую стоимость проживания за сутки в номерах, находящихся на 
7 этаже и забронированных с 3 по 12 июня включительно

## 3 Запрос
Определите общую стоимость проживания за сутки в номерах категории 5, 
забронированных клиентами из г. Уфа с 1 по 16 июня включительно

## 4 Запрос
Определить общее количество номеров категории 1, забронированных 
клиентами с фамилией, начинающейся на "А" с 11 по 23 июня включительно 
и вывести коды номеров

## Классы
## Класс Client
Реализует первый лист эксель файла

## Поля

```c#
public string Surname;
public string Name;
public string Patronymic;
public string Residence;
```

## Конструторы
## Конструтор по умолчанию

```c#
public Client()
{
    Surname = "";
    Name = "";
    Patronymic = "";
    Residence = "";
}
```

## Конструтор присваивания

```c#
public Client(string surname, string name, string patronymic, string residence)
{
    Surname = surname;
    Name = name;
    Patronymic = patronymic;
    Residence = residence;
}
```

## Метод
```c#
public override string ToString()
```

## Класс Booking
Реализует второй лист эксель файла

## Поля
```c#
public int ClientId;
public int RoomId;
public DateTime BookingDate;
public DateTime CheckInDate;
public DateTime CheckOutDate;
```

## Конструторы
## Конструтор по умолчанию

```c#
public Booking()
{
    ClientId = 0;
    RoomId = 0;
    BookingDate = DateTime.MinValue;
    CheckInDate = DateTime.MinValue;
    CheckOutDate = DateTime.MinValue;
}
```

## Конструтор присваивания

```c#
 public Booking(int clientId, int roomId, DateTime bookingDate, DateTime checkInDate,
     DateTime checkOutDate)
 {
     ClientId = clientId; 
     RoomId = roomId; 
     BookingDate = bookingDate; 
     CheckInDate = checkInDate;
     CheckOutDate = checkOutDate;
 }
```

## Метод
```c#
public override string ToString()
```

## Класс Room
Реализует третий лист эксель файла

## Поля

```c#
public int Floor;
public int Capacity;
public int Price;
public int Category;
```

## Конструторы
## Конструтор по умолчанию

```c#
public Room()
{
    Floor = 0;
    Capacity = 0;
    Price = 0;
    Category = 0;
}
```

## Конструтор присваивания

```c#
public Room(int floor, int capacity, int price, int category)
{
    Floor = floor;
    Capacity = capacity;
    Price = price;
    Category = category;
}
```

## Метод
```c#
public override string ToString()
```

## Класс HotelDatabase
Основной класс взаимодействия

## Поля

```c#
public Dictionary<int, Client> clients { get; }
public Dictionary<int, Room> rooms { get; }
public Dictionary<int, Booking> bookings { get; }
private string pathXLS = Path.GetFullPath(@"..\..\files\LR6-var9.xls");
private string pathXLSX = Path.GetFullPath(@"..\..\files\LR6-var9.xlsx");
```

## Конструтор

```c#
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
```

## Методы

```c#
//Удаление
public void DeleteInRooms(int del)
public void DeleteInBookings(int del)
public void DeleteInClients(int del)

//Корректировка
public void CorrectInRooms(int id, int column, string zam)
public void CorrectInBookings(int id, int column, string zam)
public void CorrectInClients(int id, int column, string zam)

//Добавление
public void AddInRooms(int id, int f, int cap, int p, int cat)
public void AddInBookings(int id, int cid, int rid, DateTime db, DateTime ind, DateTime outd)
public void AddInClients(int id, string n, string sn, string p, string res)

//Вывод
public string PrintHotel<T>(Dictionary<int, T> d, string s)
```

## Тесты
# Пользователь выбриает "В новом файле"
![image](https://github.com/user-attachments/assets/34c4e50f-4b6b-4def-8520-082268f1b8a3)

# Чтение базы данных
![image](https://github.com/user-attachments/assets/5485493f-8f33-4281-8670-1b2310fa5d7d)

# Просмотр базы данных
![image](https://github.com/user-attachments/assets/d47515ce-3b53-43d1-a681-34bda0b3d977)

# Удаление элемента с ключем 3
![image](https://github.com/user-attachments/assets/02751a41-f8f5-4a38-b71e-aef69a211bbe)

# Корректировка элемента с ключем 1, замена в столбце Фамилия на Кошмарик
![image](https://github.com/user-attachments/assets/a279c45f-d91a-471b-a038-22cca342175c)

# Добавление элемента
![image](https://github.com/user-attachments/assets/f2ca9054-82e5-4f4b-9676-01128ea28d67)

# Тест запроса 1
![image](https://github.com/user-attachments/assets/150eac0c-b907-4f72-8768-1609cb7bd483)

# Тест запроса 2 
![image](https://github.com/user-attachments/assets/0407a8ce-e5d6-4155-ac70-a80f0082890b)

# Тест запроса 3
![image](https://github.com/user-attachments/assets/175756ce-8893-4af3-8ced-613911f96e63)

# Тест запроса 4
![image](https://github.com/user-attachments/assets/5bc48c24-700d-4280-ad0a-683f37e8cfa5)

# Пример протокола
![image](https://github.com/user-attachments/assets/2e167057-2cb0-49a3-8ea3-0a8841ac724b)


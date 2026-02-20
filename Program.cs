using System;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            // клиент создает объект-распорядитель Director и конфигурирует его нужным объектом-строителем Builder

            // Создаем распорядителя
            TripDirector director = new TripDirector();

            Console.WriteLine("СЦЕНАРИЙ 1: ПОЕЗДКА НА ТАКСИ");
            Console.WriteLine("---------------------------------");

            TaxiTripBuilder taxiBuilder = new TaxiTripBuilder();

            taxiBuilder.RequestAdultPassenger("Иван Петров");
            taxiBuilder.RequestAdultPassenger("Мария Иванова");
            taxiBuilder.RequestChildPassenger("Петя Иванов"); // кресло надо
            taxiBuilder.RequestAdultPassenger("Анна Сидорова");
            taxiBuilder.RequestAdultPassenger("Лишний пассажир"); // превысит лимит

            // Распорядитель конструирует поездку
            Trip taxiTrip = director.Construct(taxiBuilder);

            taxiTrip.PrintTripInfo();

            Console.WriteLine("\n" + new string('=', 50) + "\n");

            Console.WriteLine("СЦЕНАРИЙ 2: ПОЕЗДКА НА АВТОБУСЕ");
            Console.WriteLine("---------------------------------");

            // Создаем конкретного строителя для автобуса
            BusTripBuilder busBuilder = new BusTripBuilder();

            busBuilder.RequestAdultPassenger("Сергей Смирнов");
            busBuilder.RequestDiscountPassenger("Пенсионер Петр Кузьмич");
            busBuilder.RequestAdultPassenger("Ольга Васильева");
            busBuilder.RequestChildPassenger("Дима Смирнов");
            busBuilder.RequestDiscountPassenger("Ветеран Иван Петрович");
            busBuilder.RequestChildPassenger("Аня Смирнова");

            for (int i = 1; i <= 25; i++)
            {
                busBuilder.RequestAdultPassenger($"Пассажир {i}");
            }

            // Распорядитель конструирует поездку
            Trip busTrip = director.Construct(busBuilder);

            busTrip.PrintTripInfo();

            Console.WriteLine("\n" + new string('=', 50) + "\n");

            Console.WriteLine("СЦЕНАРИЙ 3: ПРОВЕРКА SINGLETON И ОГРАНИЧЕНИЙ");
            Console.WriteLine("---------------------------------");

            TaxiDriver driver1 = TaxiDriver.Instance;
            TaxiDriver driver2 = TaxiDriver.Instance;
            Console.WriteLine($"Один ли водитель такси? {driver1 == driver2}");

            BusDriver busDriver1 = BusDriver.Instance;
            BusDriver busDriver2 = BusDriver.Instance;
            Console.WriteLine($"Один ли водитель автобуса? {busDriver1 == busDriver2}");

            Console.WriteLine("\nРазные представления через одного строителя:");

            // Создаем еще одну поездку на такси, но с другим составом
            TaxiTripBuilder anotherTaxiBuilder = new TaxiTripBuilder();
            anotherTaxiBuilder.RequestAdultPassenger("Клиент 1");
            anotherTaxiBuilder.RequestChildPassenger("Ребенок 1");

            Trip anotherTaxiTrip = director.Construct(anotherTaxiBuilder);
            Console.WriteLine($"Вторая поездка: {anotherTaxiTrip.Passengers.Count} пассажиров, " +
                            $"стоимость {anotherTaxiTrip.TotalPrice} руб.");
        }
    }
}
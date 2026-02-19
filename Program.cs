using System;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=================================");
            Console.WriteLine("ЛАБОРАТОРНАЯ РАБОТА №2: BUILDER");
            Console.WriteLine("=================================\n");

            // ================ CLIENT (Клиент) ================
            // Согласно теории: "клиент создает объект-распорядитель Director 
            // и конфигурирует его нужным объектом-строителем Builder"

            // Создаем распорядителя
            TripDirector director = new TripDirector();

            // ДЕМОНСТРАЦИЯ 1: Поездка на ТАКСИ
            Console.WriteLine(">>> СЦЕНАРИЙ 1: ПОЕЗДКА НА ТАКСИ");
            Console.WriteLine("---------------------------------");
            
            // Создаем конкретного строителя для такси
            TaxiTripBuilder taxiBuilder = new TaxiTripBuilder();
            
            // Клиент конфигурирует строителя (добавляет запросы на пассажиров)
            taxiBuilder.RequestAdultPassenger("Иван Петров");
            taxiBuilder.RequestAdultPassenger("Мария Иванова");
            taxiBuilder.RequestChildPassenger("Петя Иванов"); // Нужно кресло!
            taxiBuilder.RequestAdultPassenger("Анна Сидорова");
            taxiBuilder.RequestAdultPassenger("Лишний пассажир"); // Превысит лимит!
            
            // Распорядитель конструирует поездку
            Trip taxiTrip = director.Construct(taxiBuilder);
            
            // Выводим информацию о поездке
            taxiTrip.PrintTripInfo();

            Console.WriteLine("\n" + new string('=', 50) + "\n");

            // ДЕМОНСТРАЦИЯ 2: Поездка на АВТОБУСЕ
            Console.WriteLine(">>> СЦЕНАРИЙ 2: ПОЕЗДКА НА АВТОБУСЕ");
            Console.WriteLine("---------------------------------");
            
            // Создаем конкретного строителя для автобуса
            BusTripBuilder busBuilder = new BusTripBuilder();
            
            // Клиент конфигурирует строителя (разные категории пассажиров)
            busBuilder.RequestAdultPassenger("Сергей Смирнов");
            busBuilder.RequestDiscountPassenger("Пенсионер Петр Кузьмич");
            busBuilder.RequestAdultPassenger("Ольга Васильева");
            busBuilder.RequestChildPassenger("Дима Смирнов");
            busBuilder.RequestDiscountPassenger("Ветеран Иван Петрович");
            busBuilder.RequestChildPassenger("Аня Смирнова");
            
            // Добавим много пассажиров для демонстрации лимита
            for (int i = 1; i <= 25; i++)
            {
                busBuilder.RequestAdultPassenger($"Пассажир {i}");
            }
            
            // Распорядитель конструирует поездку
            Trip busTrip = director.Construct(busBuilder);
            
            // Выводим информацию о поездке
            busTrip.PrintTripInfo();

            Console.WriteLine("\n" + new string('=', 50) + "\n");

            // ДЕМОНСТРАЦИЯ 3: Проверка Singleton и ограничений
            Console.WriteLine(">>> СЦЕНАРИЙ 3: ПРОВЕРКА SINGLETON И ОГРАНИЧЕНИЙ");
            Console.WriteLine("---------------------------------");
            
            // Проверяем, что водитель такси - действительно Singleton
            TaxiDriver driver1 = TaxiDriver.Instance;
            TaxiDriver driver2 = TaxiDriver.Instance;
            Console.WriteLine($"Один ли водитель такси? {driver1 == driver2}");

            BusDriver busDriver1 = BusDriver.Instance;
            BusDriver busDriver2 = BusDriver.Instance;
            Console.WriteLine($"Один ли водитель автобуса? {busDriver1 == busDriver2}");

            // Демонстрация разных представлений через одного строителя
            Console.WriteLine("\n>>> Разные представления через одного строителя:");
            
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
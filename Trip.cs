namespace Lab2
{
    // ================ PRODUCT (Сложный продукт) ================
    // Согласно теории: "Product - представляет сложный конструируемый объект"
    public class Trip
    {
        // Тип транспорта
        public string VehicleType { get; set; }
        
        // Водитель (Singleton)
        public Driver? Driver { get; set; }
        
        // Список пассажиров
        public List<Passenger> Passengers { get; private set; } = new List<Passenger>();
        
        // Максимальная вместимость
        public int MaxPassengers { get; set; }
        
        // Общая стоимость поездки
        public decimal TotalPrice 
        { 
            get 
            {
                decimal total = 0;
                foreach (var passenger in Passengers)
                {
                    total += passenger.TicketPrice;
                }
                return total;
            }
        }

        // Проверка готовности к отправлению (согласно заданию)
        public bool IsReadyToDepart()
        {
            return Driver != null && Passengers.Count > 0;
        }

        // Информация о поездке
        public void PrintTripInfo()
        {
            Console.WriteLine($"=================================");
            Console.WriteLine($"ТРАНСПОРТ: {VehicleType}");
            Console.WriteLine($"ВМЕСТИМОСТЬ: {MaxPassengers} чел.");
            Console.WriteLine($"ЗАНЯТО МЕСТ: {Passengers.Count} чел.");
            
            if (Driver != null)
            {
                Console.WriteLine($"ВОДИТЕЛЬ: {Driver.Name} (категория {Driver.GetCategory()})");
            }
            else
            {
                Console.WriteLine($"ВОДИТЕЛЬ: НЕ НАЗНАЧЕН!");
            }

            Console.WriteLine($"\nПАССАЖИРЫ:");
            if (Passengers.Count == 0)
            {
                Console.WriteLine("  Нет пассажиров");
            }
            else
            {
                foreach (var passenger in Passengers)
                {
                    Console.WriteLine($"  - {passenger.Name}: {passenger.GetPassengerType()}, " +
                                     $"билет {passenger.TicketPrice} руб.");
                }
            }

            Console.WriteLine($"\nОБЩАЯ СТОИМОСТЬ: {TotalPrice} руб.");
            Console.WriteLine($"ГОТОВНОСТЬ К ОТПРАВЛЕНИЮ: {(IsReadyToDepart() ? "ДА" : "НЕТ")}");
            Console.WriteLine($"=================================\n");
        }
    }
}
namespace Lab2
{
    // ================ CONCRETE BUILDER (Конкретный строитель для ТАКСИ) ================
    // Согласно теории: "ConcreteBuilder - конкретный строитель:
    // - конструирует и собирает вместе части продукта
    // - определяет создаваемое представление и следит за ним"
    public class TaxiTripBuilder : TripBuilder
    {
        private List<string> _adultPassengers = new List<string>();
        private List<string> _childPassengers = new List<string>();

        // Шаг 1: Создание транспортного средства
        public override void BuildVehicle()
        {
            _trip.VehicleType = "ТАКСИ";
            _trip.MaxPassengers = 4; // Лимит для такси
            Console.WriteLine("✅ Создано такси (вместимость 4 чел.)");
        }

        // Шаг 2: Назначение водителя (используем Singleton)
        public override void BuildDriver()
        {
            _trip.Driver = TaxiDriver.Instance;
            Console.WriteLine($"✅ Назначен водитель: {_trip.Driver.Name} " +
                             $"(категория {_trip.Driver.GetCategory()})");
        }

        // Шаг 3: Добавление пассажиров
        public override void BuildPassengers()
        {
            // Добавляем всех накопленных пассажиров с проверкой лимита
            foreach (var name in _adultPassengers)
            {
                if (_trip.Passengers.Count < _trip.MaxPassengers)
                {
                    _trip.Passengers.Add(new TaxiAdultPassenger { Name = name });
                    Console.WriteLine($"  ➕ Добавлен взрослый пассажир: {name}");
                }
                else
                {
                    Console.WriteLine($"  ⚠ Невозможно добавить {name}: достигнут лимит мест!");
                }
            }

            foreach (var name in _childPassengers)
            {
                if (_trip.Passengers.Count < _trip.MaxPassengers)
                {
                    _trip.Passengers.Add(new TaxiChildPassenger { Name = name });
                    Console.WriteLine($"  ➕ Добавлен ребенок (с креслом): {name}");
                }
                else
                {
                    Console.WriteLine($"  ⚠ Невозможно добавить {name}: достигнут лимит мест!");
                }
            }
        }

        // Специфические для такси методы добавления пассажиров
        public void RequestAdultPassenger(string name)
        {
            _adultPassengers.Add(name);
            Console.WriteLine($"📝 Запрос на взрослого пассажира: {name}");
        }

        public void RequestChildPassenger(string name)
        {
            _childPassengers.Add(name);
            Console.WriteLine($"📝 Запрос на ребенка (нужно кресло): {name}");
        }
    }

    // ================ CONCRETE BUILDER (Конкретный строитель для АВТОБУСА) ================
    public class BusTripBuilder : TripBuilder
    {
        private List<string> _adultPassengers = new List<string>();
        private List<string> _discountPassengers = new List<string>();
        private List<string> _childPassengers = new List<string>();

        public override void BuildVehicle()
        {
            _trip.VehicleType = "АВТОБУС";
            _trip.MaxPassengers = 30; // Лимит для автобуса
            Console.WriteLine("✅ Создан автобус (вместимость 30 чел.)");
        }

        public override void BuildDriver()
        {
            _trip.Driver = BusDriver.Instance;
            Console.WriteLine($"✅ Назначен водитель: {_trip.Driver.Name} " +
                             $"(категория {_trip.Driver.GetCategory()})");
        }

        public override void BuildPassengers()
        {
            // Добавляем взрослых
            foreach (var name in _adultPassengers)
            {
                if (_trip.Passengers.Count < _trip.MaxPassengers)
                {
                    _trip.Passengers.Add(new AdultPassenger { Name = name });
                    Console.WriteLine($"  ➕ Добавлен взрослый пассажир: {name}");
                }
                else
                {
                    Console.WriteLine($"  ⚠ Невозможно добавить {name}: автобус полон!");
                }
            }

            // Добавляем льготников
            foreach (var name in _discountPassengers)
            {
                if (_trip.Passengers.Count < _trip.MaxPassengers)
                {
                    _trip.Passengers.Add(new DiscountPassenger { Name = name });
                    Console.WriteLine($"  ➕ Добавлен льготный пассажир: {name}");
                }
                else
                {
                    Console.WriteLine($"  ⚠ Невозможно добавить {name}: автобус полон!");
                }
            }

            // Добавляем детей
            foreach (var name in _childPassengers)
            {
                if (_trip.Passengers.Count < _trip.MaxPassengers)
                {
                    _trip.Passengers.Add(new ChildPassenger { Name = name });
                    Console.WriteLine($"  ➕ Добавлен ребенок: {name}");
                }
                else
                {
                    Console.WriteLine($"  ⚠ Невозможно добавить {name}: автобус полон!");
                }
            }
        }

        // Специфические для автобуса методы добавления пассажиров
        public void RequestAdultPassenger(string name)
        {
            _adultPassengers.Add(name);
            Console.WriteLine($"📝 Запрос на взрослого пассажира: {name}");
        }

        public void RequestDiscountPassenger(string name)
        {
            _discountPassengers.Add(name);
            Console.WriteLine($"📝 Запрос на льготного пассажира: {name}");
        }

        public void RequestChildPassenger(string name)
        {
            _childPassengers.Add(name);
            Console.WriteLine($"📝 Запрос на ребенка: {name}");
        }
    }
}
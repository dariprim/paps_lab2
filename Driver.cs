namespace Lab2
{
    // ================ ПРОДУКТ (часть сложного объекта) ================
    public abstract class Driver
    {
        public string Name { get; set; }
        public abstract string GetCategory();
    }

    // ================ КОНКРЕТНЫЕ ПРОДУКТЫ + SINGLETON ================
    public class TaxiDriver : Driver
    {
        private static TaxiDriver? _instance;
        private static readonly object _lock = new object();

        private TaxiDriver() 
        { 
            Name = "Водитель такси"; 
        }

        public static TaxiDriver Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new TaxiDriver();
                        }
                    }
                }
                return _instance;
            }
        }

        public override string GetCategory() => "B (легковой автомобиль)";
    }

    public class BusDriver : Driver
    {
        private static BusDriver? _instance;
        private static readonly object _lock = new object();

        private BusDriver() 
        { 
            Name = "Водитель автобуса"; 
        }

        public static BusDriver Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new BusDriver();
                        }
                    }
                }
                return _instance;
            }
        }

        public override string GetCategory() => "D (автобус)";
    }
}
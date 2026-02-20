namespace Lab2
{
    // Базовый класс для всех пассажиров
    public abstract class Passenger
    {
        public string Name { get; set; }
        public abstract decimal TicketPrice { get; } // Абстрактное свойство цены
        public abstract string GetPassengerType(); // Тип пассажира
    }

    //КОНКРЕТНЫЕ ПРОДУКТЫ для АВТОБУСА
    public class AdultPassenger : Passenger
    {
        public override decimal TicketPrice => 100m; // Взрослый билет 100 руб
        public override string GetPassengerType() => "Взрослый";
    }

    public class DiscountPassenger : Passenger
    {
        public override decimal TicketPrice => 50m; // Льготный билет 50 руб
        public override string GetPassengerType() => "Льготный";
    }

    public class ChildPassenger : Passenger
    {
        public override decimal TicketPrice => 0m; // Дети бесплатно в автобусе
        public override string GetPassengerType() => "Ребенок";
    }

    //КОНКРЕТНЫЕ ПРОДУКТЫ для ТАКСИ
    public class TaxiAdultPassenger : Passenger
    {
        public override decimal TicketPrice => 300m; // Взрослый в такси 300 руб
        public override string GetPassengerType() => "Взрослый (такси)";
    }

    public class TaxiChildPassenger : Passenger
    {
        public override decimal TicketPrice => 200m; // Ребенок в такси 200 руб
        public override string GetPassengerType() => "Ребенок (такси) + детское кресло";
    }
}
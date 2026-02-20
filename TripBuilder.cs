namespace Lab2
{
    // Builder - строитель: задает абстрактный интерфейс для создания частей объекта Product"
    public abstract class TripBuilder
    {
        // Строитель хранит строящийся продукт
        protected Trip _trip = new Trip();

        // Абстрактные методы для пошагового построения
        public abstract void BuildVehicle();
        public abstract void BuildDriver();
        public abstract void BuildPassengers();

        // Виртуальные методы с пустой реализацией
        public virtual void AddAdultPassenger(string name) { }
        public virtual void AddDiscountPassenger(string name) { }
        public virtual void AddChildPassenger(string name) { }
        public Trip GetTrip()
        {
            return _trip;
        }
    }
}
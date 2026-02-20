namespace Lab2
{
    //Director - распорядитель: конструирует объект, пользуясь интерфейсом Builder"
    public class TripDirector
    {
        public Trip Construct(TripBuilder builder)
        {

            builder.BuildVehicle();

            builder.BuildDriver();

            builder.BuildPassengers();

            return builder.GetTrip();
        }
    }
}
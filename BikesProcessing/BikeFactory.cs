namespace BikesProcessing;

// первая итерация фабрики объектов Bike
public static class BikeFactory
{
    public static Bike CreateBike() {
        return new Bike();
    }    
    
    public static Bike CreateBike(string model) {
        return new Bike();
    }
}

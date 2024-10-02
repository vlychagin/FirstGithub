namespace BikesProcessing;

// Характеристики велосипеда по заданию
public class Bike
{
    // идентикатор
    public int Id { get; set; }

    // модель
    public string Model { get; set; }

    // производитель
    public string Brand { get; set; }

    // цена
    public int Price{ get; set; }

    // год выпуска
    public int Year { get; set; }

    // тип по раме (женский, мужской, детский)
    // это временное решение, допустимые значения обеспечим через UI
    public string Rack { get; set; }
    
    // возраст (взрослый, детский)
    public string Age { get; set; }

    // тип по назначению (городской, шоссейный, трюковый, туристический, горный)
    // это временное решение, допустимые значения обеспечим через UI
    public string Purpose { get; set; }

    // масса велосипеда, кг
    public double Mass { get; set; }

    // размер колес, диаметр x ширина, см 
    public (double D, double W) WeelSize { get; set; }

    // максимальная нагрузка, кг
    public double MaxLoad { get; set; } 

    // количество скоростей
    public int Stages { get; set; }

    // фото велосипеда, формат JPG. 
    public string PathPhoto { get; set; }
} // class Bike

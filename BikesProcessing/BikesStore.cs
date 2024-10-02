namespace BikesProcessing;

// коллекция данных для обработки, методы обработки
// (часть бэкенда для магазина, например )
public class BikesStore
{
    // Коллекция велосипедов
    public List<Bike> Bikes = new ();

    // Выделите велосипеды заданного производителя

    // Выделите велосипеды с заданным диапазоном цены

    // Выделите велосипеды с заданным типом рамы

    // Упорядочите вывод велосипедов по убыванию года выпуска

    // Упорядочите вывод велосипедов по возрастанию цены

    // Упорядочите вывод велосипедов по убыванию максимальной нагрузки


    // Тестовая обработка 1 для исследования многопоточтности
    public List<string> GetStringList(int n) {
        var data = new List<string>();
        for (int i = 0; i < n; i++) {
            data.Add($"Строка {i+1}.");
            Thread.Sleep(200);
        }
        return data;
    } // GetStringList


    // Тестовая обработка 2 для исследования многопоточтности
    public List<int> GetIntegerList(int n) {
        var data = new List<int>();
        for (int i = 0; i < n; i++) {
            data.Add(i + 1000);
            Thread.Sleep(200);
        }
        return data;
    } // GetIntegerList


    // Тестовая обработка 3 для исследования многопоточтности
    public List<(string Name, double Salary)> GetTupleList(int n) {
        List<(string Name, double Salary)> data = new List<(string Name, double Salary)>();
        for (int i = 0; i < n; i++) {
            data.Add(($"Имя{i+1000}", 1000 * (i + 1)));
            Thread.Sleep(200);
        }

        return data;
    } // GetTupleList

} // class BikesStore

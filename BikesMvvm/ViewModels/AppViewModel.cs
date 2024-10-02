using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Threading;
using BikesMvvm.Infrastructure;
using BikesMvvm.Views;
using BikesProcessing;

namespace BikesMvvm.ViewModels;

public class AppViewModel: INotifyPropertyChanged
{
    IEnumerable<Bike> _bikes;
    public IEnumerable<Bike> Bikes {
        get => _bikes;
        set {
            _bikes = value;
            OnPropertyChanged("Bikes");
        } // set
    } // Bikes

    private BikesStore _bikesStore;
    public BikesStore BikesStore {
        get => _bikesStore;

        set {
            _bikesStore = value;
            OnPropertyChanged("BikesStore");
        } // set
    } // BikesStore

    private MainWindow _hostWindow;

    #region команды для исследования многопоточности

    // запуск обработки 1 и вывод в потоке UI
    public RelayCommand Proc1Command { get; init; }

    // запуск обработки 2 и вывод в потоке UI
    public RelayCommand Proc2Command { get; init; }

    // запуск обработки 3 и вывод в потоке UI
    public RelayCommand Proc3Command { get; init; }


    // запуск обработки 1 и вывод в отдельном потоке
    public RelayCommand Thread1Command { get; init; }

    // запуск обработки 2 и вывод в отдельном потоке
    public RelayCommand Thread2Command { get; init; }

    // запуск обработки 3 и вывод в отдельном потоке
    public RelayCommand Thread3Command { get; init; }

    // запуск обработок 2, 3, 3 и вывод в отдельных потоках
    public RelayCommand ThreadAllCommand { get; init; }

    #endregion


    #region команды

    // Формирование коллекции фабричным методом

    // Добавление элемента в коллекцию (фабричным методом и в форме)

    // Редактирование элемента коллекции (фабричным методом и в форме)

    // Удаление элемента из коллекции

    // Вывод коллекции из файла данных

    // Выделите велосипеды заданного производителя

    // Выделите велосипеды с заданным диапазоном цены

    // Выделите велосипеды с заданным типом рамы

    // Упорядочите вывод велосипедов по убыванию года выпуска

    // Упорядочите вывод велосипедов по возрастанию цены

    // Упорядочите вывод велосипедов по убыванию максимальной нагрузки

    // О приложении
    public RelayCommand AboutCommand { get; init; }

    // Выход
    public RelayCommand ExitCommand { get; init; }
    #endregion


    public AppViewModel(MainWindow hostWindow) {
        _bikes = new List<Bike>();
        _bikesStore = new();
        _hostWindow = hostWindow;

        // проверка работы в разных потоках
        Proc1Command = new(Proc1CommandExec);
        Proc2Command = new(Proc2CommandExec);
        Proc3Command = new(Proc3CommandExec);

        Thread1Command = new(o => new Thread(Thread1CommandExec!).Start());
        Thread2Command = new (o => new Thread(Thread2CommandExec!).Start());
        Thread3Command = new(o => new Thread(Thread3CommandExec!).Start());

        ThreadAllCommand = new(o => {
            _hostWindow.TblOut1.Text = _hostWindow.TblOut2.Text = _hostWindow.TblOut3.Text = "";

            new Thread(Thread1CommandExec!).Start();
            new Thread(Thread2CommandExec!).Start();
            new Thread(Thread3CommandExec!).Start();
        });

        AboutCommand = new(o => new AboutWindow().ShowDialog());
        ExitCommand = new(o => Application.Current.Shutdown(0));
    }

    #region Исполнители проверочных команд

    private void Proc1CommandExec(object o) {
        _hostWindow.TblOut1.Text = "";

        var result = _bikesStore.GetStringList(Random.Shared.Next(10, 21));
        var sb = new StringBuilder("Первая обработка. Поток UI\n");
        int i = 0;
        result.ForEach(d => sb.AppendLine($"{++i}) строка '{d}'"));

        _hostWindow.TblOut1.Text = sb.ToString();
    } // Proc1CommandExec

    private void Proc2CommandExec(object o) {
        _hostWindow.TblOut2.Text = "";

        var result = _bikesStore.GetIntegerList(Random.Shared.Next(10, 21));
        var sb = new StringBuilder("Вторая обработка. Поток UI\n");
        int i = 0;
        result.ForEach(d => sb.AppendLine($"{++i}) Число: {d}"));

        _hostWindow.TblOut2.Text = sb.ToString();
    } // Proc2CommandExec

    private void Proc3CommandExec(object o) {
        _hostWindow.TblOut3.Text = "";

        var result = _bikesStore.GetTupleList(Random.Shared.Next(10, 21));
        var sb = new StringBuilder("Третья обработка. Поток UI\n");
        int i = 0;
        result.ForEach(d => sb.AppendLine($"{++i}) {d.Name} -> {d.Salary:n2} руб."));

        _hostWindow.TblOut3.Text = sb.ToString();
    } // Proc3CommandExec

    private void Thread1CommandExec(object o) {
        _hostWindow.Dispatcher.Invoke(DispatcherPriority.Normal, () => _hostWindow.TblOut1.Text = "");

        var result = _bikesStore.GetStringList(Random.Shared.Next(10, 21));
        var sb = new StringBuilder("Первая обработка. Поток UI\n");
        int i = 0;
        result.ForEach(d => sb.AppendLine($"{++i}) строка '{d}'"));

        _hostWindow.Dispatcher.Invoke(DispatcherPriority.Normal, () => _hostWindow.TblOut1.Text = sb.ToString());
    } // Thread1CommandExec

    private void Thread2CommandExec(object o) {
        _hostWindow.Dispatcher.Invoke(DispatcherPriority.Normal, () => _hostWindow.TblOut2.Text = "");

        var result = _bikesStore.GetIntegerList(Random.Shared.Next(10, 21));
        var sb = new StringBuilder("Вторая обработка. Поток UI\n");
        int i = 0;
        result.ForEach(d => sb.AppendLine($"{++i}) Число: {d}"));

        _hostWindow.Dispatcher.Invoke(DispatcherPriority.Normal, () => _hostWindow.TblOut2.Text = sb.ToString());
    } // Thread2CommandExec

    private void Thread3CommandExec(object o) {
        _hostWindow.Dispatcher.Invoke(DispatcherPriority.Normal, () => _hostWindow.TblOut3.Text = "");

        var result = _bikesStore.GetTupleList(Random.Shared.Next(10, 21));
        var sb = new StringBuilder("Третья обработка. Поток UI\n");
        int i = 0;
        result.ForEach(d => sb.AppendLine($"{++i}) {d.Name} -> {d.Salary:n2} руб."));

        _hostWindow.Dispatcher.Invoke(DispatcherPriority.Normal, () => _hostWindow.TblOut3.Text = sb.ToString());
    } // Thread3CommandExec

    #endregion

    #region реализация интерфейса INotifyPropertyChanged
    // событие, зажигающееся при изменении свойства
    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "") {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    } // OnPropertyChanged
    #endregion

}
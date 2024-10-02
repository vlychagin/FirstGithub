using System.Windows;
using BikesMvvm.ViewModels;

namespace BikesMvvm.Views;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow() {
        InitializeComponent();

        DataContext = new AppViewModel(this);
    } // MainWindow
} // class MainWindow

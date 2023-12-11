using mvvm.ViewModel;
using System.Windows;


namespace mvvm
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new StudentViewModel();
    
        }
    }
}

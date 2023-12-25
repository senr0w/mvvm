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
        private void NavigateToSecondWindow_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as StudentViewModel;
            viewModel?.NavigateToSecondWindowCommand.Execute(null);
        }
    }
}

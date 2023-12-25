using mvvm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace mvvm.Page
{
    /// <summary>
    /// Логика взаимодействия для SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        public SecondWindow(Student selectedStudent)
        {
            InitializeComponent();
            DataContext = selectedStudent;
            txtFirstName.SetBinding(TextBlock.TextProperty, "FirstName");
            txtLastName.SetBinding(TextBlock.TextProperty, "LastName");
            txtAge.SetBinding(TextBlock.TextProperty, "Age");
        }
    }
}

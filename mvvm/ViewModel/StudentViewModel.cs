using GalaSoft.MvvmLight.Command;
using mvvm.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace mvvm.ViewModel
{
    public class StudentViewModel : DependencyObject
    {
        public ObservableCollection<Student> Students { get; set; }

        public ICommand AddStudentCommand { get; }
        public ICommand RemoveStudentCommand { get; }
        public string FilterText
        {
            get { return (string)GetValue(FilterTextProperty); }
            set { SetValue(FilterTextProperty, value); }
        }
        public static readonly DependencyProperty FilterTextProperty = DependencyProperty.Register("FilterText", typeof(string), typeof(StudentViewModel), new PropertyMetadata("", FilterText_Changed));

        private static void FilterText_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var current=d as StudentViewModel;
            if(current != null)
            {
                current.Items.Filter = null;
                current.Items.Filter = current.FilterStudent;
            }
        }

        public ICollectionView Items
        {
            get { return (ICollectionView)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }
        public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register("Items", typeof(ICollectionView), typeof(StudentViewModel), new PropertyMetadata(null));

        public StudentViewModel()
        {
            Students = new ObservableCollection<Student>();

            AddStudentCommand = new RelayCommand(AddStudent);
            RemoveStudentCommand = new RelayCommand(RemoveStudent);
            Items = CollectionViewSource.GetDefaultView(Student.GetStudents());
            Items.Filter = FilterStudent;
        }
        private void AddStudent()
        {
            Student newStudent = new Student(){ FirstName = "Имя", LastName = "Фамилия", Age = 20 };

         
            Students.Add(newStudent);
        }

        private void RemoveStudent()
        {
            
        }


        private bool FilterStudent(object obj)
        {
            bool result = true;
            Student current = obj as Student;
            if (!string.IsNullOrWhiteSpace(FilterText) && current != null && !current.FirstName.Contains(FilterText) && !current.LastName.Contains(FilterText) && !current.Age.ToString().Contains(FilterText))
            {
                result = false;
            }
            return result;
        }
    }
}

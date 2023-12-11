using GalaSoft.MvvmLight.Command;
using mvvm.Model;
using System;
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
            Items = CollectionViewSource.GetDefaultView(Students);
            Items.Filter = FilterStudent;
        }


        private MyCommand addStudent;
        public MyCommand AddStudent
        {
            get
            {
                return addStudent ??
                  (addStudent = new MyCommand(obj =>
                  {
                      Students.Add(new Student("Фамилия" , "Имя", 10));
                  }));
            }
        }

        private MyCommand deleteStudent;
        public MyCommand DeleteStudent
        {
            get
            {
                return deleteStudent ??
                    (deleteStudent = new MyCommand(obj =>
                    {
                        Student selectedStudent = obj as Student;
                        if (selectedStudent != null)
                        {
                            Students.Remove(selectedStudent);
                        }
                    }));
            }
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

    public class MyCommand : ICommand
    {
        
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public MyCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}




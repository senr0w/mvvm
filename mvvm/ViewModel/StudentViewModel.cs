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
    public class StudentViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        public ObservableCollection<Student> Students { get; set; } = new ObservableCollection<Student>();
        private Student _selectedStudent;
        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                _selectedStudent = value;
                OnPropertyChanged(nameof(SelectedStudent));
            }
        }

        private string _newFirstName;
        public string NewFirstName
        {
            get { return _newFirstName; }
            set
            {
                _newFirstName = value;
                OnPropertyChanged(nameof(NewFirstName));
            }
        }
        private int _newAge;
        public int NewAge
        {
            get { return _newAge; }
            set
            {
                _newAge = value;
                OnPropertyChanged(nameof(NewAge));
            }
        }
        private string _newLastName;
        public string NewLastName
        {
            get { return _newLastName; }
            set
            {
                _newLastName = value;
                OnPropertyChanged(nameof(NewLastName));
            }
        }

        public ICommand AddStudentCommand { get; private set; }

        public ICommand RemoveStudentCommand { get; private set; }

        public string Error => null;
        public string this[string columnName]
        {
            get
            {
                if (columnName == "NewLastName" && string.IsNullOrWhiteSpace(NewLastName))
                    return "Имя не может быть пустым";
                if (columnName == "NewFirstName" && string.IsNullOrWhiteSpace(NewFirstName))
                    return "Имя не может быть пустым";

                if (columnName == "NewAge" && (NewAge < 16 || NewAge > 150))
                    return "Возраст должен быть в диапазоне от 0 до 150";

                return null;
            }
        }

        public StudentViewModel()
        {
            RemoveStudentCommand = new RelayCommand(RemoveSelectedStudent);
            AddStudentCommand = new RelayCommand(AddStudent);
        }

        private void RemoveSelectedStudent()
        {
            if (SelectedStudent != null)
            {
                Students.Remove(SelectedStudent);
            }
        }

        private void AddStudent()
        {
            Students.Add(new Student { FirstName = NewFirstName, Age = NewAge, LastName= NewLastName });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

      
    }

}




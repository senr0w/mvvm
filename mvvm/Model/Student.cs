
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace mvvm.Model
{
    public class Student :  INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;
        private int age;



        public string FirstName { get { return _firstName; } set { _firstName = value; OnPropertyChanged(nameof(FirstName)); } }
        public string LastName { get { return _lastName; } set { _lastName = value; OnPropertyChanged(nameof(LastName)); } }
        public int Age { get { return age; } set { age = value; OnPropertyChanged(nameof(Age)); } }
   
        public Student(string firstName, string secondName, int age) 
        {
            FirstName = firstName;
            LastName = secondName;
            Age = age;
        }
        public Student() { }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

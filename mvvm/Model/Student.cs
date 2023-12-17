
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace mvvm.Model
{
    public class Student :  INotifyPropertyChanged
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

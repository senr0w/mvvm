
namespace mvvm.Model
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public static Student[] GetStudents()
        {
            var result = new Student[]
            {
                new Student(){LastName="Ivanov", FirstName = "Ivan", Age=10}
            };
            return result;
        }
            

    }
}

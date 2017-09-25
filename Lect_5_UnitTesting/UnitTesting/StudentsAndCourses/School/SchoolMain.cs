using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsAndCourses
{
    public class StudentsAndCoursesTests
    {
        public static void Main()
        {
            Student pesho = new Student("Pesho", "Peshev");
            Student gosho = new Student("Gosho", "Goshev");

            Console.WriteLine("Pesho number: {0}; Gosho number: {1}", pesho.UniqueNumber, gosho.UniqueNumber);
            Console.WriteLine("{0}; {1}", pesho.Name, gosho.Name);

            //Course math = new Course("Math");
            //math.AddStudent(pesho);
            //math.AddStudent(gosho);

            //Console.WriteLine("Students list count after adding 2 students: " + math.listStudent.Count);

            //math.RemoveStudent(pesho);

            //Console.WriteLine("Students list count after removing 1 student: " + math.listStudent.Count);

            //Console.WriteLine(gosho.Courses.Count);
        }
    }
}

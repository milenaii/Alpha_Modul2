using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsAndCourses
{
    public class Student
    {
        private string firstName;
        private string lastName;
        private readonly int uniqueNumber;
        private ICollection<Course> courses;

        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.uniqueNumber = School.UniqueNumber++;
            this.courses = new List<Course>();
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Student's first name can not be null or empty");
                }
                this.firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Student's last name can not be null or empty");
                }
                this.lastName = value;
            }
        }
        public int UniqueNumber
        {
            get
            {
                return this.uniqueNumber;
            }
        }
        public ICollection<Course> Courses
        {
            get
            {
                return new List<Course>(this.courses);
            }
        }

        public string Name
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }

        public void SignCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("Course can not be null!");
            }
            this.courses.Add(course);
            if (!courses.Contains(course))
            {
                course.AddStudent(this);
            }
        }
        public void UnsignCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("Course cannot be null");
            }
            this.courses.Remove(course);
            if (course.listStudent.Contains(this))
            {
                course.RemoveStudent(this);
            }
        }

    }
}

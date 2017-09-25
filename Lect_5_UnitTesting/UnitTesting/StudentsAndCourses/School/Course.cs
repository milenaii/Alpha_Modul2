using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsAndCourses
{
    public class Course
    {
        private ICollection<Student> listStudents;
        private string title;

        public Course(string title)
        {
            this.Title = title;
            this.listStudents = new List<Student>(listStudents);
        }

        public ICollection<Student> listStudent
        {
            get
            {
                return new List<Student>(this.listStudents);
            }
        }
        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Title of course can not be null");
                }
                this.title = value;
            }
        }
        public void AddStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("Student can not be null");
            }
            if (this.listStudents.Count == 30)
            {
                throw new ApplicationException("The number of student of the course is max.The student can not add to this course!");
            }
            else
            {
                if (this.listStudents.Contains(student))
                {
                    throw new ApplicationException("The student cannot be added more than once!");
                }
                else
                {
                    this.listStudents.Add(student);
                    student.SignCourse(this);
                }
            }
        }
        public void RemoveStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("Student cannot be null");
            }

            this.listStudent.Remove(student);
            student.UnsignCourse(this);

        }


    }
}

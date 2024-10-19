using DataAccess.Context;
using Domain.Models;

namespace DataAccess.Repositories
{
    /// <summary>
    /// StudentsRepository will handle CREATE, READ, UPDATE, and DELETE operations on data related to the Students table.
    /// </summary>
    public class StudentsRepository
    {
        /// <summary>
        /// To avoid having to create an instance of StudentDbContext for every method, constructor injection can be used to have a single instance to be used within several methods in a class. Therefore, one copy of StudentDbContext to be shared across the data handling methods. This is achieved by passing an instance of StudentDbContext and assigning it to the Context property.
        /// </summary>
        private StudentDbContext Context { get; }

        /* Alternatively method injection can be used to inject an instance of a class although since several methods will be making use of the StudentDbContext instance, constructor injection is the best way to go. 
         * This way, we have managed to avoid code redundancy, as well as write more resource-friendly code.
         * Database connection instances and data handling is already resource hungry as it is... */
        public StudentsRepository(StudentDbContext _context)
        {
            this.Context = _context;
        }

        public IEnumerable<Student> GetStudents()
        {
            return this.Context.Students;
        }

        public Student? GetStudent(string idCard)
        {
            /* For reference types like strings and classes, == is used to compare memory addresses. 
             * You should use Equals() to compare the data especially for strings. */
            return this.Context.Students.SingleOrDefault(student => student.IdNumber.Equals(idCard));
        }

        public void AddStudent(Student student)
        {
            this.Context.Students.Add(student);
            this.Context.SaveChanges(); //Commit changes to the database. Omit this and changes will not be reflected.
        }

        public void UpdateStudent(Student student)
        {
            Student? originalStudent = this.GetStudent(student.IdNumber);

            if (originalStudent != null)
            {
                originalStudent.Name = student.Name;
                originalStudent.Surname = student.Surname;
                originalStudent.DateOfBirth = student.DateOfBirth;
                originalStudent.GroupFK = student.GroupFK;
                this.Context.SaveChanges();
            }
        }

        public void DeleteStudent(string idCard)
        {
            Student? studentToDelete = this.GetStudent(idCard);

            if (studentToDelete != null)
            {
                this.Context.Students.Remove(studentToDelete);
                this.Context.SaveChanges();
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
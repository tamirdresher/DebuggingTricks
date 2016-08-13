using System.Collections.Generic;
using OzCodeDemo.ClassManagment;

namespace OzCodeDemo.ObjectId
{
    class StudentRepository
    {
        public IEnumerable<Student> GetStudents()
        {
            return new[]
            {
                new Student { Id = 1,Email = "bart@simpson.com", Name = "Bart Simpson"},
                new Student { Id = 2,Email = "lisa@simpson.com", Name = "Lisa Simpson"},
                new Student { Id = 3,Email = "meggie@simpson.com", Name = "Meggie Simpson"},
            };
        }
    }
}
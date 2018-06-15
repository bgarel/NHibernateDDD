using System;
using System.Collections.Generic;
using System.Linq;

namespace Crm.Domain
{
    public class Student
    {
        public virtual Guid Id { get; set; }

        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }

        //private readonly List<Enrollment> _enrollments = new List<Enrollment>();
        //public virtual IReadOnlyList<Enrollment> Enrollments => _enrollments.ToList();

        //public void AddEnrollment(string course, string grade)
        //{
        //    var enrollment = new Enrollment
        //    {
        //        Course = course,
        //        Student = this,
        //        Grade = grade
        //    };
        //    _enrollments.Add(enrollment);
        //}
    }
}

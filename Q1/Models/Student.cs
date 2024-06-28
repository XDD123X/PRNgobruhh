using System;
using System.Collections.Generic;

namespace Q1.Models
{
    public partial class Student
    {
        public Student()
        {
            StudentSubjects = new HashSet<StudentSubject>();
            Classes = new HashSet<Class>();
        }

        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public bool Male { get; set; }
        public DateTime Dob { get; set; }
        public string Note { get; set; } = null!;
        public string? Nationality { get; set; }
        public int LectureId { get; set; }

        public virtual Lecturer Lecture { get; set; } = null!;
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}

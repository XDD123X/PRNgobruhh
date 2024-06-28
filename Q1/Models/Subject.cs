using System;
using System.Collections.Generic;

namespace Q1.Models
{
    public partial class Subject
    {
        public Subject()
        {
            StudentSubjects = new HashSet<StudentSubject>();
        }

        public int Id { get; set; }
        public string Subject1 { get; set; } = null!;

        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}

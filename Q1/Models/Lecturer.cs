using System;
using System.Collections.Generic;

namespace Q1.Models
{
    public partial class Lecturer
    {
        public Lecturer()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public bool Male { get; set; }
        public DateTime Dob { get; set; }
        public string Note { get; set; } = null!;

        public virtual ICollection<Student> Students { get; set; }
    }
}

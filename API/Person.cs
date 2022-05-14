using System;
using System.Collections.Generic;

namespace API
{
    public partial class Person
    {
        public Person()
        {
            Events = new HashSet<Event>();
            PersonCourses = new HashSet<PersonCourse>();
            Teachers = new HashSet<Teacher>();
        }

        public int Id { get; set; }
        public string Surname { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<PersonCourse> PersonCourses { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace API
{
    public partial class Course
    {
        public Course()
        {
            PersonCourses = new HashSet<PersonCourse>();
        }

        public int Id { get; set; }
        public string? Namecourse { get; set; }
        public string? Infcourse { get; set; }
        public int? Nomercourse { get; set; }

        public virtual ICollection<PersonCourse> PersonCourses { get; set; }
    }
}

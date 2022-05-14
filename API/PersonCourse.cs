using System;
using System.Collections.Generic;

namespace API
{
    public partial class PersonCourse
    {
        public int Id { get; set; }
        public int? Personid { get; set; }
        public int? Courseid { get; set; }

        public virtual Course? Course { get; set; }
        public virtual Person? Person { get; set; }
    }
}

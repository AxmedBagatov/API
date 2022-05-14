using System;
using System.Collections.Generic;

namespace API
{
    public partial class Teacher
    {
        public int Id { get; set; }
        public string? Inftext { get; set; }
        public string? Dopinf { get; set; }
        public int? Personid { get; set; }

        public virtual Person? Person { get; set; }
    }
}

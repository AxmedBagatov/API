using System;
using System.Collections.Generic;

namespace API
{
    public partial class Event
    {
        public int Id { get; set; }
        public string? Event1 { get; set; }
        public int? Personid { get; set; }

        public virtual Person? Person { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace FlightDocSys.Models
{
    public partial class TypeDo
    {
        public int TypeDoId { get; set; }
        public string Name { get; set; } = null!;
        public int UserId { get; set; }
        public string? Description { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}

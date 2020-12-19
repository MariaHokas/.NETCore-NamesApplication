using System;
using System.Collections.Generic;

#nullable disable

namespace NamesApplication.Models
{
    public partial class Name
    {
        public Guid NameGuid { get; set; }
        public string Name1 { get; set; }
        public int? Amount { get; set; }
    }
}

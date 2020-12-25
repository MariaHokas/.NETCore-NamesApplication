using System;
using System.Collections.Generic;

#nullable disable

namespace NamesApplication.Models
{
    public partial class NamesTable
    {
        public Guid NameGuid { get; set; }
        public string Names { get; set; }
        public int? Amount { get; set; }
    }
}

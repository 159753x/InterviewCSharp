using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedCodeLibrary.Model
{
    public class TimeEntry
    {
        //Objects of this class represent JSON data fetched from API
        public required string Id { get; set; }
        public string? EmployeeName { get; set; }
        public DateTime StarTimeUtc { get; set; }
        public DateTime EndTimeUtc { get; set; }
        public string? EntryNotes { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}

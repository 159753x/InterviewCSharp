using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedCodeLibrary.Model
{
    public class EmployeeTime
    {
        //Objects of this class represent data that will be displayed on HTML page.
        public EmployeeTime()
        {
        }
        public EmployeeTime(string employeeName)
        {
            EmployeeName = employeeName;
        }

        public required string EmployeeName { get; set; }
        public TimeSpan TimeWorked { get; set; }
    }
}

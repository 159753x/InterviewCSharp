using SharedCodeLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedCodeLibrary.Contoller
{
    public class GeneratingDataHTMLTaskController
    {
        public GeneratingDataHTMLTaskController() { }

        public List<EmployeeTime> GenerateEmployeeTimes(List<TimeEntry> timeEntries) 
        {
            //**this part is if we dont need ordered data, we could use dictionary for faster reading..
            //System.Collections.Generic.Dictionary<string, EmployeeTime> employeeList = new Dictionary<string, EmployeeTime>();
            //foreach (TimeEntry entry in timeEntries)
            //{
            //    if (string.IsNullOrEmpty(entry.EmployeeName))
            //    {
            //        continue;
            //    }
            //    if (employeeList.ContainsKey(entry.EmployeeName))
            //    {
            //        employeeList[entry.EmployeeName].TimeWorked += entry.EndTimeUtc.Subtract(entry.StarTimeUtc);
            //    }
            //    else
            //    {
            //        EmployeeTime employee = new EmployeeTime(entry.EmployeeName)
            //        {
            //            //employee.EmployeeName = entry.EmployeeName;
            //            TimeWorked = entry.EndTimeUtc.Subtract(entry.StarTimeUtc)
            //        };
            //        employeeList.Add(entry.EmployeeName, employee);
            //    }
            //}
            //PrintEmployees(employeeList);


            List<EmployeeTime> eTimes = new List<EmployeeTime>();
            foreach (TimeEntry entry in timeEntries)
            {
                if (string.IsNullOrEmpty(entry.EmployeeName) || entry.DeletedOn < DateTime.Today)
                {
                    //we are skipping if there is not name or if it is deleted on date earlier than today
                    continue;
                }
                else if (eTimes.Any(et => et.EmployeeName == entry.EmployeeName))
                {
                    eTimes.FirstOrDefault(et => et.EmployeeName == entry.EmployeeName).TimeWorked += entry.EndTimeUtc.Subtract(entry.StarTimeUtc);
                }
                else
                {
                    EmployeeTime employee = new EmployeeTime()
                    {
                        EmployeeName = entry.EmployeeName,
                        TimeWorked = entry.EndTimeUtc.Subtract(entry.StarTimeUtc)
                    };
                    eTimes.Add(employee);
                }
            }
            eTimes = eTimes.OrderByDescending(et => et.TimeWorked).ToList();

            return eTimes;
        }
    }
}

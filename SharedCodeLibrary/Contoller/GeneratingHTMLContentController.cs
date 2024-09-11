using SharedCodeLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedCodeLibrary.Contoller
{
    public class GeneratingHTMLContentController
    {
        public GeneratingHTMLContentController() { }

        public string GenerateHTMLContent(List<EmployeeTime> employeeTimes) 
        {
            var html = @"<!DOCTYPE html>
            <html lang='en'>
            <head>
                <meta charset='UTF-8'>
                <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                <title>Employee Time Entries</title>
                <style>
                    table {
                        width: 100%;
                        border-collapse: collapse;
                    }
                    table, th, td {
                        border: 1px solid black;
                    }
                    th, td {
                        padding: 8px;
                        text-align: left;
                    }
                    tr.low-hours {
                        background-color: #ffcccc;
                    }
                </style>
            </head>
            <body>
                <h1>Employee Time Entries</h1>
                <table>
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>Employee Name</th>
                            <th>Total Time Worked</th>
                        </tr>
                    </thead>
                    <tbody>";

            // Add row for each new employee
            var count = 0;
            foreach (var e in employeeTimes)
            {

                var rowClass = e.TimeWorked.TotalHours < 100 ? "low-hours" : "";
                count++;

                html += $@"
            <tr class='{rowClass}'>
                <td>{count}</td>
                <td>{e.EmployeeName}</td>
                <td>{Math.Floor(e.TimeWorked.TotalHours)}:{e.TimeWorked.Minutes}:{e.TimeWorked.Seconds} </td>
            </tr>";
            }


            html += @"
                </tbody>
            </table>
        </body>
        </html>";

            return html;
        }
    }
}

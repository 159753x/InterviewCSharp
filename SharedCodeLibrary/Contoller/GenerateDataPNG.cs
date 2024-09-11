using SharedCodeLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection.Emit;

namespace SharedCodeLibrary.Contoller
{
    public class GenerateDataPNG
    {
        public required List<EmployeeTime> employeeTimes { get; set; }
        public TimeSpan total { get; set; }
        public List<Color> colors { get; set; }

        public GenerateDataPNG() 
        { 
            colors = new List<Color>(); 
        }    

        public void GenerateData() 
        {
            foreach (var entry in employeeTimes)
            {
                //times.Add(entry.TimeWorked);
                //names.Add(entry.EmployeeName);

                var rnd = new Random();
                colors.Add(Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)));
                total += entry.TimeWorked;
            }
        }
    }
}

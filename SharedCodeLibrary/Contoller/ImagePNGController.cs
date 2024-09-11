using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedCodeLibrary.Model;

namespace SharedCodeLibrary.Contoller
{
    public class ImagePNGController
    {
        public ImagePNGController() { }
        public void GenerateImage(List<EmployeeTime> employeeTimes, TimeSpan total, List<Color> colors) 
        {
            int width = 1000;
            int height = 1000;
            Bitmap bitmap = new Bitmap(width, height);

            
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White);

                Rectangle rectangle = new Rectangle(100, 150, 800, 800);


                // Starting angle for the first slice
                float startAngle = 0;

                Font labelFont = new Font("Arial", 10);
                Brush labelBrush = Brushes.Black;
                Font legendFont = new Font("Arial", 14, FontStyle.Bold);
                Font titleFont = new Font("Arial", 18, FontStyle.Bold);

                g.DrawString("Pie Chart for employee's work time", titleFont, labelBrush, 300, 10);
                g.DrawString("Total: " + $@"{Math.Floor(total.TotalHours)}:{total.Minutes}:{total.Seconds}", legendFont, labelBrush, 10, 40);

                // Loop through the employeeTimes and draw each pie slice
                int i = -1;
                foreach(var et in employeeTimes)
                {
                    i++;
                    // Calculate the sweep angle based on the proportion of the value
                    float sweepAngle = (float)(et.TimeWorked / total) * 360;

                    // Create a brush with the color from the list of random colors for the slice
                    using (Brush brush = new SolidBrush(colors.ElementAt(i)))
                    {
                        // Draw the pie slice
                        g.FillPie(brush, rectangle, startAngle, sweepAngle);
                    }

                    // Calculate the angle for label placement
                    float midAngle = startAngle + (sweepAngle / 2);
                    // Convert the mid-angle to radians
                    double radians = (midAngle * Math.PI) / 180;
                    // Calculate the position for the label
                    int labelX = (int)(475 + Math.Cos(radians) * 450);
                    int labelY = (int)(525 + Math.Sin(radians) * 450);
                    g.DrawString(et.EmployeeName + "\n" + $@"{Math.Floor(et.TimeWorked.TotalHours)}:{ et.TimeWorked.Minutes}:{ et.TimeWorked.Seconds}", labelFont, labelBrush, labelX, labelY);

                    // Update the starting angle for the next slice
                    startAngle += sweepAngle;
                }
            }

            // Save the image in PNG file format
            string filePath = "PieChart.png";
            bitmap.Save(filePath, ImageFormat.Png);

            Console.WriteLine($"Pie chart saved as {filePath}");
        }
    }
}

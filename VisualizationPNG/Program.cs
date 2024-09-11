using SharedCodeLibrary.Contoller;
using SharedCodeLibrary.Model;

using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection.Emit;

// Fetching data from REST API endpoint and transfering it in List<TimeEntry> format
var fdc = new FetchDataController();
List<TimeEntry> timeEntries = await fdc.FetchData();

// Transforming fetched data to ordered list (List<EmployeeTime>) of employees and their full working time in hours
var gd = new GeneratingDataHTMLTaskController();
List<EmployeeTime> employeeTimes = gd.GenerateEmployeeTimes(timeEntries);

// generating data for PNG image
var gdp = new GenerateDataPNG()
{
    employeeTimes = employeeTimes
};
gdp.GenerateData();

// making an PNG image
var ipc = new ImagePNGController() { };
ipc.GenerateImage(employeeTimes, gdp.total, gdp.colors);
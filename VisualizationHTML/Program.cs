using SharedCodeLibrary.Contoller;
using SharedCodeLibrary.Model;

// Fetching data from REST API endpoint and transfering it in List<TimeEntry> format
var fdc = new FetchDataController();
List<TimeEntry> timeEntries = await fdc.FetchData();

// Transforming fetched data to ordered list (List<EmployeeTime>) of employees and their full working time in hours
var gd = new GeneratingDataHTMLTaskController();
List<EmployeeTime> employeeTimes = gd.GenerateEmployeeTimes(timeEntries);

// Generating HTML Content in string form for HTML file for visual representation of transformed data
var ghc = new GeneratingHTMLContentController();
string HTMLContent = ghc.GenerateHTMLContent(employeeTimes);

// Generating static HTML file for data visualization in ..InterviewCSharp\VisualizationHTML\bin\Debug\net8.0\ 
await HTMLFileController.HTMLFileGenerator(HTMLContent);




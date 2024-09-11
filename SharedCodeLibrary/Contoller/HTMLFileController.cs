using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SharedCodeLibrary.Contoller
{
    public class HTMLFileController                                                            
    {
        public static async Task HTMLFileGenerator(string HTMLContent) 
        {
            if (string.IsNullOrEmpty(HTMLContent)) 
            {
                Console.WriteLine("HTML file not generated: Content does not exist or empty");
                return;
            }
            await File.WriteAllTextAsync("time_entries.html", HTMLContent);

            Console.WriteLine("HTML file generated: time_entries.html");

            
        }
    }
}

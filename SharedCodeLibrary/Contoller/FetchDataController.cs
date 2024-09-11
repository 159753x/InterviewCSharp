using Newtonsoft.Json;
using SharedCodeLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedCodeLibrary.Contoller
{
    public class FetchDataController
    {
        public FetchDataController() { }

        public async Task<List<TimeEntry>> FetchData() 
        {
            string apiUrl = "https://rc-vault-fap-live-1.azurewebsites.net/api/gettimeentries?code=vO17RnE8vuzXzPJo5eaLLjXjmRW07law99QTD90zat9FfOQJKKUcgQ==";


            var httpClient = new HttpClient();
            var jsonData = await httpClient.GetStringAsync(apiUrl);
            var timeEntries = JsonConvert.DeserializeObject<List<TimeEntry>>(jsonData);

            return timeEntries;
        }
    }
}

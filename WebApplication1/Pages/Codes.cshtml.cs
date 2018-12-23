using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebApplication1.Pages
{
    public class CodesModel : PageModel
    {
        public List<string> ClassList { get; set; }
        public string Message { get; set; } = "XXXXX CodesModel ";
        public void OnGet()
        {
            string baseUri = "https://demo9876.azurewebsites.net/api/GetPersistenceClass?entityName=PoolBuy";
            var client = new WebClient();
            var json = client.DownloadString(baseUri);

            JObject obj = JObject.Parse(json); 
            

            ClassList = new List<string>();

            foreach (var c in obj["result"]["value"].ToList())
            {
                ClassList.Add((string)c["className"]);

            }




        }
    }
}
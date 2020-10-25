using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace CoronavirusTravelBackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : Controller
    {
        Hub hub;
        public RouteController()
        {
            hub = new Hub();
        }
        [Route("/GetRoute")]
        [HttpGet]
        public string Route(string start, string finish)
        {
            var route = hub.FindRoute(start, finish);
            return route != null ? route :  "error"  ;
        }


        [Route("/GetCountryData")]
        [HttpGet]

        public string GetCountryData(string name)
        {
            string data = JsonConvert.SerializeObject(hub.AssociateCountry(name));
            return data;
        }
        
    }
}

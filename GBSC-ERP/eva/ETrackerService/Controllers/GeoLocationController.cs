using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eTrackerInfrastructure.Models.JsonPostClasses;
using eTrackerInfrastructure.Repos.Interfaces;
using System.IO;
using Newtonsoft.Json;
using eTrackerInfrastructure.Helpers;

namespace eTrackerInfrastructure.Controllers
{
    [Route("api/[controller]")]
    public class GeoLocationController : Controller
    {
        private IUserRepository _repo;

        public GeoLocationController(IUserRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("PostLocationCoordinated/{userid}")]
        public IActionResult PostLocationCoordinated([FromBody]JsonLocations locationObj, long userid)
        {
            if (locationObj == null)
                return new BadRequestObjectResult(new { result = "Object does not contain any items" });

            // full path to file in temp location
            var filename = $"LocationHistory_{userid}.json";
            string docFolder = "LocationHistory";

            var filePath = JsonLocationFileHandler.GetJsonFilePath(docFolder, filename);


            // Read existing json data
            var jsonData = JsonLocationFileHandler.ReadFile(filePath);

            // De-serialize to object or create new list
            var locationhistoryarray = JsonConvert.DeserializeObject<List<LocationJson>>(jsonData) ?? new List<LocationJson>();

            foreach (var location in locationObj.LocationJson)
            {
                // Add any new location
                locationhistoryarray.Add(location);

                // Update json data string
                jsonData = JsonConvert.SerializeObject(locationhistoryarray);
                JsonLocationFileHandler.WriteToLocationHistory(filePath, jsonData);
            }


            return new OkObjectResult(new { status = "location hisotry saved" });
        }

        [HttpGet("GetLocationHistory/{userid}")]
        public IList<LocationJson> GetLocationHistory(long userid)
        {
            if (userid == 0)
                new List<LocationJson>();

            var filename = $"LocationHistory_{userid}.json";
            string docFolder = "LocationHistory";

            var filePath = JsonLocationFileHandler.GetJsonFilePath(docFolder, filename);


            // Read existing json data
            var jsonData = JsonLocationFileHandler.ReadFile(filePath);

            return JsonConvert.DeserializeObject<List<LocationJson>>(jsonData) ?? new List<LocationJson>();
        }
    }
}
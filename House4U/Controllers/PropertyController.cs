using House4U.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace House4U.Controllers
{
    [RoutePrefix("api/Property")]
    public class PropertyController : ApiController
    {
        private static List<Property> Propertys = new List<Property>
        {
            new Property(){ID=1, Address = "1 Main Sreet", Email = "Timtooo@Yahoo.com", ExpiryDate = new DateTime(2020,01,01), LType = LeaseType.FullyDelagated, NoBedrooms =2},
            new Property(){ID=2, Address = "2 Main Sreet", Email = "Tim@Yahoo.com", ExpiryDate = new DateTime(2020,04,01), LType = LeaseType.FullyDelagated, NoBedrooms =2},
            new Property(){ID=3, Address = "3 Main Sreet", Email = "Tolom@Yahoo.com", ExpiryDate = new DateTime(2020,03,01), LType = LeaseType.FullyDelagated, NoBedrooms =5}
        };

        [HttpGet]
        [Route("all")]
        public IEnumerable<Property> Get()
        {
            return Propertys;
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var foundLease = Propertys.FirstOrDefault(i => i.ID == id);
            if (foundLease != null)
            {
                return Ok(foundLease);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("emails")]
        public IEnumerable<String> emails()
        {
            return Propertys.Select(c => c.Email).ToList();
        }

        [HttpPost]
        [Route("AddProperty")]
        public IHttpActionResult AddProperty(Property newProp)
        {
            var foundProp = Propertys.FirstOrDefault(i => i.ID == newProp.ID);
            if (foundProp == null)
            {
                Propertys.Add(newProp);
                return Ok();
            }
            else
            {
                return BadRequest("Property Already exists");
            }
        }

        [HttpPut]
        [Route("UpdateProperty")]
        public IHttpActionResult UpdateProperty(Property newProp)
        {
            var foundProp = Propertys.FirstOrDefault(i => i.ID == newProp.ID);
            if (foundProp == null)
            {
                return BadRequest("Property Doesn't Exist");

            }
            else
            {
                foundProp.NoBedrooms = newProp.NoBedrooms;               
                return Ok();
            }
        }

    }
}

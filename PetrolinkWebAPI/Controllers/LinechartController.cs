using PetrolinkWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PetrolinkWebAPI.Controllers
{
    [RoutePrefix("api/linechart")]
    public class LinechartController : ApiController
    {
        [HttpPost]
        [Route("initialData")]
        public HttpResponseMessage GetInitialData(TimeInterval timeInterval)
        {
            List<Linechart> linechartList = new List<Linechart>();
            Random rnd = new Random();

            DateTime tempDate = timeInterval.endDate;
            while (tempDate > timeInterval.startDate)
            {
                linechartList.Add(new Linechart()
                {
                    y = tempDate,
                    x = rnd.Next(1, 1000)
                });
                tempDate = tempDate.AddSeconds(-1);
            }

            return Request.CreateResponse(HttpStatusCode.OK, linechartList);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NamesApplication.Models;

namespace NamesApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NamesController : ControllerBase
    {
        [HttpGet]
        [Route("all")]
        public List<Name> GetAllNamesToList()
        {
            devacademy2021Context db = new devacademy2021Context();
            List<Name> name = db.Names.ToList();
            return name;
        }

        [HttpGet]
        [Route("mostpopular")]
        public IActionResult GetNamesOrderByPopularity()
        {
            devacademy2021Context db = new devacademy2021Context();
            var mostPopular = (from n in db.Names
                               orderby n.Amount descending
                               select new
                               {
                                n.Name1,
                                n.Amount,
                               }).ToList();
            return Ok(mostPopular);
        }

        [HttpGet]
        [Route("alphabeticalorder")]
        public IActionResult GetNamesAlphabeticalOrder()
        {
            devacademy2021Context db = new devacademy2021Context();
            var mostPopular = (from n in db.Names
                               orderby n.Name1
                               select new
                               {
                                   n.Name1,
                                   n.Amount,
                               }).ToList();
            return Ok(mostPopular);
        }

        [HttpGet]
        [Route("takeonename")]
        public IActionResult GetOneName(string name)
        {
            devacademy2021Context db = new devacademy2021Context();
            List<Name> names = db.Names.Where(d => d.Name1 == name).ToList();
            return Ok(names);
        }

        [HttpGet]
        [Route("sum")]
        public IActionResult GetTotalAmount()
        {
            devacademy2021Context db = new devacademy2021Context();
            var totalAmount = db.Names.Select(x => x.Amount).ToList().Sum();
            return Ok(totalAmount);
        }
    }
}

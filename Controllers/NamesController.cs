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
        public List<NamesTable> GetAllNamesToList()
        {
            devAcademy2021Context db = new devAcademy2021Context();
            List<NamesTable> name = db.NamesTables.ToList();
            return name;
        }

        [HttpGet]
        [Route("mostpopular")]
        public IActionResult GetNamesOrderByPopularity()
        {
            devAcademy2021Context db = new devAcademy2021Context();
            var mostPopular = (from n in db.NamesTables
                               orderby n.Amount descending
                               select new
                               {
                                n.Names,
                                n.Amount,
                               }).ToList();
            return Ok(mostPopular);
        }

        [HttpGet]
        [Route("alphabeticalorder")]
        public IActionResult GetNamesAlphabeticalOrder()
        {
            devAcademy2021Context db = new devAcademy2021Context();
            var mostPopular = (from n in db.NamesTables
                               orderby n.Names
                               select new
                               {
                                   n.Names,
                                   n.Amount,
                               }).ToList();
            return Ok(mostPopular);
        }

        [HttpGet]
        [Route("takeonename")]
        public IActionResult GetOneName(string name)
        {
            devAcademy2021Context db = new devAcademy2021Context();
            List<NamesTable> names = db.NamesTables.Where(d => d.Names == name).ToList();
            return Ok(names);
        }

        [HttpGet]
        [Route("sum")]
        public IActionResult GetTotalAmount()
        {
            devAcademy2021Context db = new devAcademy2021Context();
            var totalAmount = db.NamesTables.Select(x => x.Amount).ToList().Sum();
            return Ok(totalAmount);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ExploreCalifornia.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("blog/{year:int?}/{month:int?}/{key}")]
        public IActionResult Post(int year, int month, string key)
        {
            return View();
        }
    }
}
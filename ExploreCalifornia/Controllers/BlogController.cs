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
            return new ContentResult { Content = "Blog posts" };
        }

        [Route("blog/{year:int?}/{month:int?}/{key}")]
        public IActionResult Post(int year, int month, string key)
        {
            return new ContentResult { Content = string.Format("Year: {0}; Month: {1}; Key: {2}", year, month, key) };
        }
    }
}
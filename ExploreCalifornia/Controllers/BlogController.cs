using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExploreCalifornia.Models;

namespace ExploreCalifornia.Controllers
{
    public class BlogController : Controller
    {
        private readonly BlogDataContext _db;
        public BlogController (BlogDataContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("blog/{year:int?}/{month:int?}/{key}")]
        public IActionResult Post(int year, int month, string key)
        {
            var post = new Post
            {
                Title = "My Blog Post",
                Posted = DateTime.Now,
                Author = "G",
                Body = " Test Test Test Test Test Test Test"
            };

            return View(post);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Post post)
        {
            if (!ModelState.IsValid)
                return View();
      
                post.Author = User.Identity.Name;
                post.Posted = DateTime.Now;
                _db.Posts.Add(post);
                _db.SaveChanges();

                return View(post);
     
        }
    }
}
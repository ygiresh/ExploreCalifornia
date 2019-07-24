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
            var posts = _db.Posts.OrderByDescending(x => x.Posted).Take(5).ToArray();
            return View(posts);
        }

        [Route("blog/{year:int?}/{month:int?}/{key}")]
        public IActionResult Post(int year, int month, string key)
        {
            var post = _db.Posts.FirstOrDefault(x => x.Key == key);
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
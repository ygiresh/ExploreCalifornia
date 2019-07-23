﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExploreCalifornia.Models
{
    public class Post
    {
        public long Id { get; set; }

        private string _key;
        public string Key
        {
            get
            {
                return Regex.Replace(Title.ToLower(), "[^a-z0-9]", "-");
            }

            private set
            {
               _key = value;
            }
        }

        [Display(Name ="Post Title")]
        [Required]
        [StringLength(100, MinimumLength =5, ErrorMessage = "Title must be between 5 and 100 characters long" )]
        [DataType(DataType.Password)]
        public string Title { get; set;  }


        public string Author { get; set; }

        [Required]
        [MinLength(100, ErrorMessage = "Blog posts must be at least 100 characters long")]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        public DateTime Posted { get; set; }
    }
}

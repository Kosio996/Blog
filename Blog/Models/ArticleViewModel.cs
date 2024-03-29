﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class ArticleViewModel
    {
        public string Tags { get; set; }

        public int Id { get; set; }

        public int CategoryId { get; set; }        

        public ICollection<Category> Categories { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public string AuthorId { get; set; }

    }
}

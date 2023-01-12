﻿using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

        public ICollection<Blog> Blogs { get; set; }
    }
}
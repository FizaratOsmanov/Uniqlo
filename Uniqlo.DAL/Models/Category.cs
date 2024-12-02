﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Uniqlo.DAL.Models
{
    public class Category : BaseEntity
    {
        public  string CategoryName { get; set; }
        public IEnumerable<Product>? Products { get; set; }
    }
}

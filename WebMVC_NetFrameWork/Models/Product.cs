﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC_NetFrameWork.Models
{
    public class Product
    {
        public int Id { get; set; }

        public  string Name { get; set; }

        public string Description{ get; set; }

        public decimal Price { get; set; }

        public bool IsActive{ get; set; }
    }
}
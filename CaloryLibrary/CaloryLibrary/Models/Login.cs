﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaloryLibrary.Models
{
    public class Login
    {
        public int LoginId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public virtual List<Recipe> Recipes { get; set; }
    }
}

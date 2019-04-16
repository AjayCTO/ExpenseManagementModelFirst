﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJSAuthentication.API.Models
{
    public class Manufacturer
    {
        public int ManufacturerID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public short CategoryID { get; set; }

        public short ProjectID { get; set; }

        public virtual Category Category { get; set; }
        public virtual Project Project { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CustomerType Customertype { get; set; }
    }
}

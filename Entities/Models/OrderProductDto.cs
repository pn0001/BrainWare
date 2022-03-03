﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class OrderProductDto
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public ProductDto Product { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

    }
}

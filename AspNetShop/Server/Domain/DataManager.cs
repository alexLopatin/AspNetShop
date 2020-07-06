﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetShop.Server.Domain.Repositories.Abstract;

namespace AspNetShop.Server.Domain
{
    public class DataManager
    {
        public IProductRepository Products { get; set; }

        public DataManager(IProductRepository products)
        {
            Products = products;
        }
    }
}

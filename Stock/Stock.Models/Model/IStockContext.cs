﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Models
{
    public interface IStockContext
    {
        IEnumerable<Models.Stock> GetAllStock();
    }
}

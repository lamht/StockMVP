using System;
using System.Collections.Generic;
using Stock.Models;
using System.Collections.Concurrent;

namespace Stock.View
{
    public interface IStockView
    {
        event EventHandler OpenMarket;
        event EventHandler CloseMarket;
        event EventHandler Reset;
        ConcurrentDictionary<string, Models.Stock> Stocks { get; set; }        
    }
}

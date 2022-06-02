using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Stock.Models
{
    public class StockContext: IStockContext
    {
        private static readonly  IEnumerable<Stock> stocks = new List<Stock>
            {
                new Stock { Symbol = "MSFT", Price = 30.31m },
                new Stock { Symbol = "APPL", Price = 578.18m },
                new Stock { Symbol = "GOOG", Price = 570.30m }
            };

        IEnumerable<Stock> IStockContext.GetAllStock()
        {
            return stocks;
        }
    }
}

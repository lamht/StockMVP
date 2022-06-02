using System;
using Stock.View;
using Stock.Models;

namespace Stock.Present.Factory
{
    public class StockFactory: IStockFactory
    {
        private static readonly Lazy<IStockFactory> _instance = new Lazy<IStockFactory>
        (() => new StockFactory(),true);

        public static IStockFactory Instance 
        {
            get { return _instance.Value; }
        }
        private StockFactory()
        {

        }
        public IStockPresent CreateStockPresent(IStockView view)
        {
            return new StockPresent(view);
        }


        public IStockContext CreateStockContext()
        {
            return new StockContext();
        }
    }
}

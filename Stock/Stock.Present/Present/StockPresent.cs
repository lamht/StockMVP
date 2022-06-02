using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stock.View;
using System.Collections.Concurrent;
using Stock.Models;
using Stock.Present.Factory;
using System.Threading;

namespace Stock.Present
{
    internal class StockPresent : IStockPresent
    {
        public event EventHandler OnStockChange;
        private IStockView view;

        //lock access for update stock
        private readonly object _updateStockPricesLock = new object();

        //stock can go up or down by a percentage of this factor on each change
        private readonly double _rangePercent = .002;

        private readonly TimeSpan _updateInterval = TimeSpan.FromMilliseconds(250);
        private readonly Random _updateOrNotRandom = new Random();

        private readonly Timer _timer;
        //flag update stock note
        private volatile bool _updatingStockPrices = false;

        private volatile bool _isOpenMarket = false;

        public StockPresent(IStockView view)
        {
            if (view == null)
            {
                throw new NullReferenceException("The StockView can not null!");
            }
            this.view = view;
            this.view.OpenMarket += new EventHandler(OpenMarketEventHandler);
            this.view.CloseMarket += new EventHandler(CloseMarketEventHandler);
            this.view.Reset += new EventHandler(ResetEventHandler);

            GetAllStocks();
            _timer = new Timer(UpdateStockPrices, null, _updateInterval, _updateInterval);
            
        }

        private void ResetEventHandler(object sender, EventArgs e)
        {
            GetAllStocks();
        }

        private void CloseMarketEventHandler(object sender, EventArgs e)
        {
            this._isOpenMarket = false;
        }

        private void OpenMarketEventHandler(object sender, EventArgs e)
        {
            this._isOpenMarket = true;
        }

          

        private void GetAllStocks(){
            if (this.view.Stocks == null)
            {
                this.view.Stocks = new ConcurrentDictionary<string, Models.Stock>();
            }
            else
            {
                this.view.Stocks.Clear();
            }
            IStockContext stockContext = StockFactory.Instance.CreateStockContext();

            var stocks = stockContext.GetAllStock();
            foreach (var stock in stocks)
            {
                this.view.Stocks.TryAdd(stock.Symbol, stock);
            }
        }

        private void UpdateStockPrices(object state)
        {
            if (!_isOpenMarket)
            {
                return;
            }
            lock (_updateStockPricesLock)
            {
                if (!_updatingStockPrices)
                {
                    _updatingStockPrices = true;

                    foreach (var stock in this.view.Stocks.Values)
                    {
                        if (TryUpdateStockPrice(stock))
                        {
                            ChangeStockPrice(stock);
                        }
                    }

                    _updatingStockPrices = false;
                }
            }
        }

        private bool TryUpdateStockPrice(Models.Stock stock)
        {
            // Randomly choose whether to update this stock or not
            var r = _updateOrNotRandom.NextDouble();
            if (r > .1)
            {
                return false;
            }

            // Update the stock price by a random factor of the range percent
            var random = new Random((int)Math.Floor(stock.Price));
            var percentChange = random.NextDouble() * _rangePercent;
            var pos = random.NextDouble() > .51;
            var change = Math.Round(stock.Price * (decimal)percentChange, 2);
            change = pos ? change : -change;

            stock.Price += change;
            return true;
        }

        private void ChangeStockPrice(Models.Stock stock)
        {
            OnStockChange(this, EventArgs.Empty);
        }
        
    }
}

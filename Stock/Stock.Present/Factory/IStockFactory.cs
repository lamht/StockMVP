using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stock.View;
using Stock.Models;

namespace Stock.Present.Factory
{
    public interface IStockFactory
    {
        IStockPresent CreateStockPresent(IStockView view);
        IStockContext CreateStockContext();
    }
}

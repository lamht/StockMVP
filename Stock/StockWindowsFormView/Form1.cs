using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Stock.View;
using Stock.Models;
using System.Collections.Concurrent;
using Stock.Present;
using Stock.Present.Factory;

namespace StockWindowsFormView
{
    public partial class Form1 : Form, IStockView
    {     
        public event EventHandler OpenMarket;

        public event EventHandler CloseMarket;

        public event EventHandler Reset;

        private ConcurrentDictionary<string, Stock.Models.Stock> stocks = new ConcurrentDictionary<string, Stock.Models.Stock>();
        public ConcurrentDictionary<string, Stock.Models.Stock> Stocks
        {
            get
            {
                return stocks;
            }
            set
            {
                stocks = value;
            }
        }
        private IStockPresent present;

        public Form1()
        {
            InitializeComponent();
            present = StockFactory.Instance.CreateStockPresent(this);
            present.OnStockChange += new EventHandler(OnStockChange);
        }

        private void OnStockChange(object sender, EventArgs e)
        {
            UpdateStatusMessage("Stock change");
            InvokeUpdateDataGridView();            
        }

        private void InvokeUpdateDataGridView()
        {
            if (this.dataGridViewStock.InvokeRequired)
            {
                this.dataGridViewStock.BeginInvoke((MethodInvoker)delegate() { UpdateDataGridViewStock(); ; ;});
            }
            else
            {
                UpdateDataGridViewStock();
            }
        }
        private void UpdateDataGridViewStock()
        {
            dataGridViewStock.Rows.Clear();
            
            foreach (var stock in this.Stocks.Values)
            {
                var index = dataGridViewStock.Rows.Add(stock.Symbol, 
                    stock.Price.ToString(), 
                    stock.DayOpen.ToString(), 
                    stock.Change.ToString(), 
                    stock.PercentChange.ToString());
               
            }
        }
        private void SetRowColor(decimal change, int index)
        {
            if (change > 0)
            {
                dataGridViewStock.Rows[index].DefaultCellStyle.BackColor = Color.Green;
            } 
            else if (change < 0)
            {
                dataGridViewStock.Rows[index].DefaultCellStyle.BackColor = Color.Red;
            }
        }
        private void OpenMarketClick(object sender, EventArgs e)
        {
            UpdateStatusMessage("Open market click");
            OpenMarket(this, EventArgs.Empty);
        }
        private void CloseMarketClick(object sender, EventArgs e)
        {
            UpdateStatusMessage("Close market click");
            CloseMarket(this, EventArgs.Empty);
        }
        private void ResetClick(object sender, EventArgs e)
        {
            UpdateStatusMessage("Reset click");
            Reset(this, EventArgs.Empty);
            InvokeUpdateDataGridView();
        }

        private void UpdateStatusMessage(String message)
        {
            if (this.lbStatus.InvokeRequired)
            {
                this.lbStatus.BeginInvoke((MethodInvoker)delegate() { this.lbStatus.Text = message; ;});
            }
            else
            {
                this.lbStatus.Text = message;
            }

        }
    }
}

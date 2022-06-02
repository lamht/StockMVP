namespace StockWindowsFormView
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btOpenMarket = new System.Windows.Forms.Button();
            this.btCloseMarket = new System.Windows.Forms.Button();
            this.btReset = new System.Windows.Forms.Button();
            this.dataGridViewStock = new System.Windows.Forms.DataGridView();
            this.Symbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Open = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Change = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PercentChange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStock)).BeginInit();
            this.SuspendLayout();
            // 
            // btOpenMarket
            // 
            this.btOpenMarket.Location = new System.Drawing.Point(49, 26);
            this.btOpenMarket.Name = "btOpenMarket";
            this.btOpenMarket.Size = new System.Drawing.Size(86, 23);
            this.btOpenMarket.TabIndex = 0;
            this.btOpenMarket.Text = "Open Market";
            this.btOpenMarket.UseVisualStyleBackColor = true;
            this.btOpenMarket.Click += new System.EventHandler(this.OpenMarketClick);
            // 
            // btCloseMarket
            // 
            this.btCloseMarket.Location = new System.Drawing.Point(156, 26);
            this.btCloseMarket.Name = "btCloseMarket";
            this.btCloseMarket.Size = new System.Drawing.Size(82, 23);
            this.btCloseMarket.TabIndex = 0;
            this.btCloseMarket.Text = "Close Market";
            this.btCloseMarket.UseVisualStyleBackColor = true;
            this.btCloseMarket.Click += new System.EventHandler(this.CloseMarketClick);
            // 
            // btReset
            // 
            this.btReset.Location = new System.Drawing.Point(261, 26);
            this.btReset.Name = "btReset";
            this.btReset.Size = new System.Drawing.Size(86, 23);
            this.btReset.TabIndex = 0;
            this.btReset.Text = "Reset";
            this.btReset.UseVisualStyleBackColor = true;
            this.btReset.Click += new System.EventHandler(this.ResetClick);
            // 
            // dataGridViewStock
            // 
            this.dataGridViewStock.AllowUserToAddRows = false;
            this.dataGridViewStock.AllowUserToDeleteRows = false;
            this.dataGridViewStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Symbol,
            this.Price,
            this.Open,
            this.Change,
            this.PercentChange});
            this.dataGridViewStock.Location = new System.Drawing.Point(49, 101);
            this.dataGridViewStock.Name = "dataGridViewStock";
            this.dataGridViewStock.ReadOnly = true;
            this.dataGridViewStock.Size = new System.Drawing.Size(499, 150);
            this.dataGridViewStock.TabIndex = 1;
            // 
            // Symbol
            // 
            this.Symbol.HeaderText = "Symbol";
            this.Symbol.Name = "Symbol";
            this.Symbol.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // Open
            // 
            this.Open.HeaderText = "Open";
            this.Open.Name = "Open";
            this.Open.ReadOnly = true;
            // 
            // Change
            // 
            this.Change.HeaderText = "Change";
            this.Change.Name = "Change";
            this.Change.ReadOnly = true;
            // 
            // PercentChange
            // 
            this.PercentChange.HeaderText = "%";
            this.PercentChange.Name = "PercentChange";
            this.PercentChange.ReadOnly = true;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(46, 270);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(0, 13);
            this.lbStatus.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 302);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.dataGridViewStock);
            this.Controls.Add(this.btReset);
            this.Controls.Add(this.btCloseMarket);
            this.Controls.Add(this.btOpenMarket);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btOpenMarket;
        private System.Windows.Forms.Button btCloseMarket;
        private System.Windows.Forms.Button btReset;
        private System.Windows.Forms.DataGridView dataGridViewStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn Symbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Open;
        private System.Windows.Forms.DataGridViewTextBoxColumn Change;
        private System.Windows.Forms.DataGridViewTextBoxColumn PercentChange;
        private System.Windows.Forms.Label lbStatus;
    }
}


using System;
using System.Collections.Generic;

namespace StockMarket
{
	public class Stock : IStock
	{
        #region Fields and properties
        public Exchange exchange { get; set; }
		public string stockSymbol { get; set; }
		public double basePrice { get; set; }
        #endregion

        #region Constructors
        public Stock(Exchange exchange, string stockSymbol, double basePrice)
		{
			this.exchange = exchange;
			this.stockSymbol = stockSymbol;
			this.basePrice = basePrice;
		}
        #endregion

        #region Methods
        public bool Validate()
		{
			if (this.exchange == Exchange.NONE)
				return false;

			if (this.stockSymbol == string.Empty)
				return false;

			// Stock price can never be 0 or negative. Stock value can be 0 or negative.
			if (this.basePrice <= 0)
				return false;

			return true;
		}
        #endregion
    }

    public class StockOwned : Stock
	{
        #region Fields and properties
        public int totalShares = 0;
		public double totalStockValue = 0;
		public double profit = 0;
		public double loss = 0;
		public DERIVED_BOOLEAN_BUY_SELL buysell = DERIVED_BOOLEAN_BUY_SELL.NONE;
        #endregion

        #region Constructors
        public StockOwned(int totalShares, double totalStockValue,
						double profit, double loss, DERIVED_BOOLEAN_BUY_SELL buysell, // true = buy, false = sell
						  Exchange exchange, string stockSymbol, double basePrice) : base(exchange, stockSymbol, basePrice)
		{
			this.totalShares = totalShares;
			this.totalStockValue = totalStockValue;
			this.profit = profit;
			this.loss = loss;
			this.buysell = buysell;
		}
        #endregion
    }
}
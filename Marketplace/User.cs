using System;
using System.Collections.Generic;

namespace StockMarket
{
    public class User
    {
        #region Fields and properties
        public int UID = 0;
		public string userName = string.Empty;
		public bool isActive = true;
		public Dictionary<int, StockOwned> stocksOwned = new Dictionary<int, StockOwned>(); // ListingID, stockOwned
        #endregion

        #region Constructors
        public User(int UID, string userName, bool isActive)
		{
			this.UID = UID;
			this.userName = userName;
			this.isActive = isActive;
		}
        #endregion

        #region Methods
        #region Buy
        public void Buy(int ListingID, int shares)
		{
			if (!Marketplace.stocks.ContainsKey(ListingID))
			{
				Console.WriteLine("Stock that you want to buy is not listed on our marketplace yet!");
				return;
			}

			Stock stock = Marketplace.stocks[ListingID];
			double totalStockValue = shares * stock.basePrice;

			if (this.stocksOwned.ContainsKey(ListingID)) // Update the value if stock exists
			{
				StockOwned currentStockOwned = this.stocksOwned[ListingID];
				currentStockOwned.totalShares += shares;
				currentStockOwned.totalStockValue += totalStockValue;
				this.stocksOwned[ListingID] = currentStockOwned;
			}
			else // Insert the stock
			{
				StockOwned stockOwned = new StockOwned(shares, totalStockValue, 0, 0, DERIVED_BOOLEAN_BUY_SELL.BUY, stock.exchange, stock.stockSymbol, stock.basePrice);
				this.stocksOwned.Add(ListingID, stockOwned);
			}
		}
        #endregion

        #region Sell
        public void Sell(int ListingID, int numberOfSharesToSell)
		{
			if (this.stocksOwned.ContainsKey(ListingID))
			{
				StockOwned stockDetail = this.stocksOwned[ListingID];
				double originalBasePrice = stockDetail.basePrice;
				double currentBasePrice = Marketplace.GetCurrentStockPrice(ListingID); // Call method to fetch the current stock price

				double originalTotalStockValue = stockDetail.totalStockValue;
				double currentTotalStockValue = currentBasePrice * stockDetail.totalShares;

				double differenceAfterSelling = (currentBasePrice * numberOfSharesToSell) - (originalBasePrice * numberOfSharesToSell);
				if (differenceAfterSelling < 0) // It is a loss
					stockDetail.loss = differenceAfterSelling * -1;
				else if (differenceAfterSelling > 0) // It is profit
					stockDetail.profit = differenceAfterSelling;

				stockDetail.totalShares -= numberOfSharesToSell;
				stockDetail.totalStockValue = currentTotalStockValue - (currentBasePrice * numberOfSharesToSell);
				stockDetail.buysell = DERIVED_BOOLEAN_BUY_SELL.SELL;

				this.stocksOwned[ListingID] = stockDetail;
			}
			else
			{
				Console.WriteLine("You cannot sell the shares that you do not own!");
			}
		}
        #endregion

        #region Display portfolio
        public void DisplayPortfolio()
		{
			Console.WriteLine("--------------------------------------------------------------------------------");
			Console.WriteLine("Sr # | Exchange | Symbol | Total Shares | Total Price | Profit | Loss | BuySell");
			Console.WriteLine("--------------------------------------------------------------------------------");
			foreach (KeyValuePair<int, StockOwned> stockDetail in this.stocksOwned)
			{
				StockOwned stock = stockDetail.Value;
				string buysellFlag = stock.buysell == DERIVED_BOOLEAN_BUY_SELL.BUY ? "Buy" : "Sell";
				Console.WriteLine(stockDetail.Key + " | " + stock.exchange + " | " + stock.stockSymbol +
									" | " + stock.totalShares + " | " + stock.totalStockValue +
									" | " + stock.profit + " | " + stock.loss + " | " + buysellFlag);
			}
		}
        #endregion
        #endregion
    }
}

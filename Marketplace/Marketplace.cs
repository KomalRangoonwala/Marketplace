using System;
using System.Collections.Generic;

namespace StockMarket
{
    public class Marketplace
    {
        #region Fields and properties
        public static Dictionary<int, Stock> stocks = new Dictionary<int, Stock>();
		public static List<User> users = new List<User>();
		public static int ActiveUsers = 0;
        #endregion

        #region Methods
        #region Initialise
        public static void InitialiseMarketplace()
		{
			#region Insert some stocks
			Stock s1 = new Stock(Exchange.NSE, "ACDC", 15);
			Stock s2 = new Stock(Exchange.NSE, "TBB", 6);
			Stock s3 = new Stock(Exchange.NSE, "BSB", 54);
			Stock s4 = new Stock(Exchange.NSE, "GNR", 12);
			stocks.Add(1, s1);
			stocks.Add(2, s2);
			stocks.Add(3, s3);
			stocks.Add(4, s4);

			Stock s5 = new Stock(Exchange.BSE, "BEATLES", 25);
			Stock s6 = new Stock(Exchange.BSE, "PINKFLOYD", 24);
			Stock s7 = new Stock(Exchange.BSE, "RHCP", 12);
			Stock s8 = new Stock(Exchange.BSE, "EAGLES", 3);
			stocks.Add(5, s5);
			stocks.Add(6, s6);
			stocks.Add(7, s7);
			stocks.Add(8, s8);
            #endregion

            #region Insert some default users
            InsertUser(101, "Captain Planet");
			InsertUser(102, "Scooby");
			InsertUser(103, "Bugsy");
			InsertUser(104, "Heidi");
            #endregion
        }
        #endregion

        public static void Display()
		{
			UpdateStockPrices();
			Console.WriteLine("----------------------------");
			Console.WriteLine("Sr # | Exchange | Symbol | Base Price");
			Console.WriteLine("----------------------------");
			foreach (KeyValuePair<int, Stock> stockDetail in stocks)
			{
				Stock stock = stockDetail.Value;
				Console.WriteLine(stockDetail.Key + " | " + stock.exchange + " | " + stock.stockSymbol + " | " + stock.basePrice);
			}
			Console.WriteLine("--------------");
		}

		public static void InsertUser(int UID, string Username)
		{
			User user = new User(UID, Username, true); // User is active by default when it is inserted
			users.Add(user);
			ActiveUsers++;
		}

		public static User GetUser(int UID)
		{
			User fetchedUser = null;
			foreach (User user in users)
			{
				if (user.UID == UID)
				{
					fetchedUser = user;
					break;
				}
			}

			return fetchedUser;
		}

		// Future enhancement: Fetch live rates whenever called through some API if possible
		public static double GetCurrentStockPrice(int ListingID)
		{
			Stock stock = stocks[ListingID];
			return stock.basePrice;
		}

		public static void UpdateStockPrices()
		{
			var rand = new Random();
			foreach (KeyValuePair<int, Stock> stockDetail in stocks)
			{
				int num = rand.Next(1, 1000);
				Stock stock = stockDetail.Value;
				stock.basePrice = num;
			}
		}
        #endregion
    }
}

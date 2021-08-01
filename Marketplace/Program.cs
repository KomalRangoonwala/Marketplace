using System;

namespace StockMarket
{
    class Program
    {
        static void Main(string[] args)
        {
			// Initialise default values for the marketplace
            #region Marketplace initialisation
            Marketplace.InitialiseMarketplace();
			Marketplace.Display();
            #endregion

            #region Get user input
            Console.WriteLine("Enter what you want to do? \n" +
                "1. Display stocks \n" +
                "2. Select user \n" +
                "3. Insert user \n" +
                "4. Buy \n" +
                "5. Sell \n" +
                "6. Display portfolio \n" +
                "7. Exit");
			UserAction userAction = (UserAction)Convert.ToInt32(Console.ReadLine());

			int listingID = 0;
			int shares = 0;
			User currentUser = null;

			while (userAction != UserAction.EXIT)
			{
				switch (userAction)
				{
					#region Display stocks
					case UserAction.DISPLAY_STOCKS:
						Marketplace.Display();
						break;
                    #endregion

                    #region Select user
                    case UserAction.SELECT_USER:
						if (Marketplace.users.Count <= 0)
						{
							Console.WriteLine("There are no users. Insert a user first.");
						}
						else
						{
							foreach (User user in Marketplace.users)
								Console.WriteLine(user.UID + " - " + user.userName);

							Console.WriteLine("Enter a user ID from above to select a user: ");
							int userID = Convert.ToInt32(Console.ReadLine());
							currentUser = Marketplace.GetUser(userID);
						}
						break;
                    #endregion

                    #region Insert user
                    case UserAction.INSERT_USER:
						Console.WriteLine("Enter user ID: ");
						int newUserID = Convert.ToInt32(Console.ReadLine());

						Console.WriteLine("Enter username: ");
						string userName = Console.ReadLine();

						Marketplace.InsertUser(newUserID, userName);
						break;
                    #endregion

                    #region Buy
                    case UserAction.BUY:
						Console.WriteLine("Enter listing ID of the stock that you want to buy: ");
						listingID = Convert.ToInt32(Console.ReadLine());

						Console.WriteLine("Enter # of shares you want to buy: ");
						shares = Convert.ToInt32(Console.ReadLine());
						
						Console.WriteLine(currentUser.UID + " - " + currentUser.userName);
						
						currentUser.Buy(listingID, shares);
						break;
                    #endregion

                    #region Sell
                    case UserAction.SELL:
						Console.WriteLine("Enter listing ID of the stock that you want to sell: ");
						listingID = Convert.ToInt32(Console.ReadLine());

						Console.WriteLine("Enter # of shares you want to sell: ");
						shares = Convert.ToInt32(Console.ReadLine());

						currentUser.Sell(listingID, shares);
						break;
                    #endregion

                    #region Display portfolio
                    case UserAction.DISPLAY_PORTFOLIO:
						currentUser.DisplayPortfolio();
						break;
                    #endregion

                    #region Default
                    default:
						Console.WriteLine("Invalid operation!");
						break;
                    #endregion
                }

				Console.WriteLine("Enter what you want to do? \n" +
				"1. Display stocks \n" +
				"2. Select user \n" +
				"3. Insert user \n" +
				"4. Buy \n" +
				"5. Sell \n" +
				"6. Display portfolio \n" +
				"7. Exit");
				userAction = (UserAction)Convert.ToInt32(Console.ReadLine());
            }
			#endregion
		}
	}
}

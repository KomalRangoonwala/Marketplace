using System;

namespace StockMarket
{
    public enum Exchange
    {
        NONE = 0,
        BSE = 1,
        NSE = 2,
    }

	public enum UserAction
	{
		NONE = 0,
		DISPLAY_STOCKS = 1,
		SELECT_USER = 2,
		INSERT_USER = 3,
		BUY = 4,
		SELL = 5,
		DISPLAY_PORTFOLIO = 6,
		EXIT = 7,
	}

	public enum DERIVED_BOOLEAN_BUY_SELL
	{
		NONE = 0,
		BUY = 1,
		SELL = 2,
	}
}

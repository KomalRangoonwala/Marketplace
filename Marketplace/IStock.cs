using System;
namespace StockMarket
{
    public interface IStock
    {
        #region Properties
        Exchange exchange { get; set; }
        string stockSymbol { get; set; }
        double basePrice { get; set; } // Number of open shares or
        #endregion

        #region Method declaration
        bool Validate();
        #endregion
    }
}

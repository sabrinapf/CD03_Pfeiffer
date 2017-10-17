using CodingDojo4DataLib;
using CodingDojo4DataLib.Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD03_Pfeiffer.ViewModel
{
    // inherits BaseViewModel (basically for property changing)
    class StockEntryViewModel : BaseViewModel
    {
        // StockEntry = provided (library)
        private StockEntry stockEntry;

        // on the basis of euro all other currencies shall be calculated: f. purchase & sales price
        private double salesPriceInEuro;
        private double purchasePriceInEuro;

        // name of StockEntry
        public string Name
        {
            get
            {
                return stockEntry.SoftwarePackage.Name;
            }
            set
            {
                stockEntry.SoftwarePackage.Name = value;
                // call OnChange() method that the selected name has changed
                OnChange("Name");
            }
        }

        // Category (= Group) of StockEntry
        public string Category
        {
            get
            {
                return stockEntry.SoftwarePackage.Category.Name;
            }
            set
            {
                stockEntry.SoftwarePackage.Category.Name = value;
                // call OnChange() method that the selected category has changed
                OnChange("Category");
            }
        }
       
        // Sales Price of StockEntry
        public double SalesPrice
        {
            get
            {
                return stockEntry.SoftwarePackage.SalesPrice;
            }
            set
            {
                stockEntry.SoftwarePackage.SalesPrice = value;
                // call OnChange() method that the selected sales price has changed
                OnChange("SalesPrice");
            }
        }

        // Purchase Price of StockEntry
        public double PurchasePrice
        {
            get
            {
                return stockEntry.SoftwarePackage.PurchasePrice;
            }
            set
            {
                stockEntry.SoftwarePackage.PurchasePrice = value;
                // call OnChange() method that the selected purchase price has changed
                OnChange("PurchasePrice");
            }
        }

        // Amount of Items on Stock of the specific StockEntry
        public int ItemOnStock
        {
            get
            {
                return stockEntry.Amount;
            }
            set
            {
                stockEntry.Amount = value;
                // call OnChange() method that the selected on stock value has changed
                OnChange("ItemOnStock");
            }
        }

        // Constructor, parameter = StockEntry
        public StockEntryViewModel(StockEntry entry)
        {
            stockEntry = entry;
            // save initial value of the price in euro
            salesPriceInEuro = entry.SoftwarePackage.SalesPrice;
            purchasePriceInEuro = entry.SoftwarePackage.PurchasePrice;
        }

        // add method for convertion (from sales price in euro to current currency)
        public void CalculateSalesPriceFromEuro(Currencies currency) // parameter = selected currency
        {
            // CurrencyConverter provided (library)
            this.SalesPrice = CurrencyConverter.ConvertFromEuroTo(currency, salesPriceInEuro);
        }

        // calculate purchase price
        public void CalculatePurchasePriceFromEuro(Currencies currency)
        {
            // CurrencyConverter provided (library)
            this.PurchasePrice = CurrencyConverter.ConvertFromEuroTo(currency, purchasePriceInEuro);
        }
    }
}

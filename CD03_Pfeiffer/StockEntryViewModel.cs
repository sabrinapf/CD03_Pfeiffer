using CodingDojo4DataLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD03_Pfeiffer.ViewModel
{
    class StockEntryViewModel : BaseViewModel
    {
        private StockEntry stockEntry;

        private double salesPriceInEuro;

        public string Name
        {
            get
            {
                return stockEntry.SoftwarePackage.Name;
            }
            set
            {
                stockEntry.SoftwarePackage.Name = value;
                OnChange("Name");
            }
        }

        public string Category
        {
            get
            {
                return stockEntry.SoftwarePackage.Category.Name;
            }
            set
            {
                stockEntry.SoftwarePackage.Category.Name = value;
                OnChange("Category");
            }
        }
        public double SalesPrice
        {
            get
            {
                return stockEntry.SoftwarePackage.SalesPrice;
            }
            set
            {
                stockEntry.SoftwarePackage.SalesPrice = value;
                OnChange("SalesPrice");
            }
        }

        public double PurchasePrice
        {
            get
            {
                return stockEntry.SoftwarePackage.PurchasePrice;
            }
            set
            {
                stockEntry.SoftwarePackage.PurchasePrice = value;
                OnChange("PurchasePrice");
            }
        }

        public int OnStock
        {
            get
            {
                return stockEntry.Amount;
            }
            set
            {
                stockEntry.Amount = value;
                OnChange("Amount");
            }
        }

        public StockEntryViewModel(StockEntry entry)
        {
            stockEntry = entry;
        }
    }
}

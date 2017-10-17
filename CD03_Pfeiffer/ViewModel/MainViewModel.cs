using CodingDojo4DataLib;
using CodingDojo4DataLib.Converter;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CD03_Pfeiffer.ViewModel
{
    // MainViewModel inherits BaseViewModel (basically for property changing)
    class MainViewModel : BaseViewModel
    {
        /* ObservableCollection<T>: Stellt eine dynamische Datenauflistung dar, 
         * die Benachrichtigungen bereitstellt, wenn Elemente hinzugefügt oder 
         * entfernt werden bzw. wenn die gesamte Liste aktualisiert wird.
         * T = Der Typ der Elemente in der Auflistung.
         */ 
        private ObservableCollection<StockEntryViewModel> items = new ObservableCollection<StockEntryViewModel>();

        public ObservableCollection<StockEntryViewModel> Items
        {
            get
            {
                return items;
            }
            set
            {
                items = value;
            }
        }

        // add currency property (type & number of currencies are predefined in the provided library)
        public Array Currencies
        {
            get
            {
                // Enum.GetValues: Ruft ein Array mit den Werten der Konstanten in einer angegebenen Enumeration ab. Rückgabewert = Ein Array, das die Werte der Konstanten in enumType enthält.
                // Currencies = Array of Currencies (provided at library)
                return Enum.GetValues(typeof(Currencies));
            }
        }

        private Currencies selectedCurrency;
        // add selected currency
        public Currencies SelectedCurrency
        {
            get
            {
                return selectedCurrency;
            }
            set
            {
                selectedCurrency = value;
                // call OnChange() method that the selected currency has changed
                OnChange("SelectedCurrency");
                // start convertion of currencies
                StartConvertion();
            }
        }

        private void StartConvertion()
        {
            // run through each item entries
            foreach (var item in Items)
            {
                // sales price shall be shown in the selected currency (method can be found in StockEntryViewModel)
                item.CalculateSalesPriceFromEuro(selectedCurrency);
                // purchase prices shall be shown in the selected currency (method can be found in StockEntryViewModel)
                item.CalculatePurchasePriceFromEuro(selectedCurrency);
            }
        }
                     
        // => from provided library: List of stock entries
        private List<StockEntry> stock;
        
        public MainViewModel()
        {
            // from provided library: Sample Manager (includes the current stock)
            SampleManager manager = new SampleManager();
            stock = manager.CurrentStock.OnStock;

            // for each item in the list stock ...
            foreach(var item in stock)
            {
                // for each entry a new entry in the ObservableCollection is created
                Items.Add(new StockEntryViewModel(item)); // ViewModel data structure is filled
            }
        }
        
    }
}

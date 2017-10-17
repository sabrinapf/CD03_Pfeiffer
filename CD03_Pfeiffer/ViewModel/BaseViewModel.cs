using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD03_Pfeiffer.ViewModel
{
    // INotifyPropertyChanged-Schnittstelle: Benachrichtigt Clients, dass sich ein Eigenschaftswert geändert hat.
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        // PropertyChangedEventHandler-Delegat: Stellt die Methode für die Behandlung der PropertyChanged Ereignis wird ausgelöst, wenn eine Eigenschaft für eine Komponente geändert wird.
        public event PropertyChangedEventHandler PropertyChanged;

        // method OnChange: propertyname = Der Name der geänderten Eigenschaft.
        public void OnChange(string propertyname)
        {
            if(PropertyChanged != null)
            {
                /* PropertyChangedEventHandler parameter: 
                 * sender (Type: System.Object) = Die Quelle des Ereignisses
                 * e (Type: System.ComponentModel.PropertyChangedEventArgs) = Ein PropertyChangedEventArgs, das die Ereignisdaten enthält.
                 */
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CD03_Pfeiffer.Commands
{
    class RelayCommand : ICommand
    {


        private Action execute;
        private Func<bool> canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        // add: implement interface explicitly => possibility to write the code for adding & removing that event handler
        event EventHandler ICommand.CanExecuteChanged
        {
            add
            {
                // register to the requery event from the WPF Command Manager
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                // if it's not suggested, remove registration
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return canExecute();
        }

        public void Execute(object parameter)
        {
            execute();
        }
    }
}

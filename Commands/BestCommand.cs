using System;
using System.Windows.Input;
using Perso.Types;
using Perso.ViewModel;

namespace Perso.Commands
{
    public class BestCommand : ICommand
    {
        public bool Ca { get; set; }
        private PersoViewModel PersoViewModel { get; set; }

        public BestCommand(PersoViewModel persoViewModel) => PersoViewModel = persoViewModel;
        
        public bool CanExecute(object parameter)
        {
            return Ca;
        }

        public void Execute(object parameter)
        {
            int.TryParse(PersoViewModel.Alter, out var alter);
                var p = new Person(PersoViewModel.Name, PersoViewModel.Vorname, alter);
                PersoViewModel.Personen.Add(p);
        }

        event EventHandler ICommand.CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        private event EventHandler CanExecuteChanged;
    }
}
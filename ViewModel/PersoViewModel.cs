using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Perso.Annotations;
using Perso.Commands;
using Perso.Types;

namespace Perso.ViewModel
{
    public class PersoViewModel : INotifyPropertyChanged
    {
        private string _alter;
        private string _name;
        private string _vorname;

        public PersoViewModel()
        {
            BestCommand = new BestCommand(this) {Ca = false};
            Personen = new List<Person>();
        }


        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Vorname
        {
            get => _vorname;
            set
            {
                _vorname = value;
                OnPropertyChanged();
            }
        }

        public string Alter
        {
            get => _alter;
            set
            {
                _alter = value;
                OnPropertyChanged();
            }
        }

        public BestCommand BestCommand { get; set; }

        public List<Person> Personen { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            if (!string.IsNullOrEmpty(_alter) && !string.IsNullOrEmpty(_name) && !string.IsNullOrEmpty(_vorname))
                BestCommand.Ca = true;
            else
                BestCommand.Ca = false;
        }
    }
}
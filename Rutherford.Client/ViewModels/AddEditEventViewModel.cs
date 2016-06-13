using Rutherford.Client.Views;
using Rutherford.Client.WpfClasses;
using Rutherford.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Rutherford.Client.ViewModels
{
    public class AddEditEventViewModel : ViewModelBase
    {
        protected Action CloseWindow { get; set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        private RelayCommand _updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (_updateCommand == null)
                {
                    _updateCommand = new RelayCommand(updateHandler, canUpdateHandler);
                }
                return _updateCommand;
            }
        }

        private RelayCommand _closeCommand;
        public ICommand CloseCommand
        {
            get
            {
                if (_closeCommand == null)
                    _closeCommand = new RelayCommand(closeHandler, (o) => true);
                return _closeCommand;
            }
        }

        private int? _eventId;
        public int? EventId
        {
            get
            {
                return _eventId;
            }
            set
            {
                _eventId = value;
                OnPropertyChanged("EventId");
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
                if(_updateCommand != null)
                    _updateCommand.RaiseCanExecuteChanged();
            }
        }

        private DateTime _date;
        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                OnPropertyChanged("Date");
            }
        }

        private string _location;
        public string Location
        {
            get { return _location; }
            set
            {
                _location = value;
                OnPropertyChanged("Location");
            }
        }

        private decimal _price;
        public decimal Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged("Price");
            }
        }

        private int _totalTickets;
        public int TotalTickets
        {
            get { return _totalTickets; }
            set
            {
                _totalTickets = value;
                OnPropertyChanged("TotalTickets");
            }
        }

        private string _notes;
        public string Notes
        {
            get { return _notes; }
            set
            {
                _notes = value;
                OnPropertyChanged("Notes");
            }
        }

        private void closeHandler(object param)
        {
            this.CloseWindow();
        }

        private bool canUpdateHandler(object param)
        {
            if (string.IsNullOrWhiteSpace(this.Name))
                return false;

            return true;
        }

        private void updateHandler(object param)
        {
            if(this.EventId == null)
            {
                using (IUnitOfWork uow = UnitOfWork.Get())
                {
                    uow.RutherfordService.AddEvent(this.Name, this.Date, this.Location, this.Price, this.TotalTickets, this.Notes);
                }
            }
            else
            {
                using (IUnitOfWork uow = UnitOfWork.Get())
                {
                    uow.RutherfordService.UpdateEvent(this.EventId.Value, this.Name, this.Date, this.Location, this.Price, this.TotalTickets, this.Notes);
                }
            }
            this.CloseWindow();
        }

        public AddEditEventViewModel(Event update)
        {
            if (update == null)
            {
                this.Title = "Add";
                this.Date = DateTime.Now;
            }
            else
            {
                this.Title = "Edit";
                this.EventId = update.EventId;
                this.Name = update.Name;
                this.Date = update.Date ?? DateTime.Now;
                this.Location = update.Location;
                this.Price = update.Price;
                this.TotalTickets = update.TotalTickets;
                this.Notes = update.Notes;
            }
        }

        public static void Show(Event update)
        {
            var vm = new AddEditEventViewModel(update);
            var v = new AddEditEventView();
            vm.CloseWindow = v.Close;
            v.DataContext = vm;

            v.ShowDialog();
        }
    }
}

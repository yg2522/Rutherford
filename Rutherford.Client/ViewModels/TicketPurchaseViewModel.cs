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
    public class TicketPurchaseViewModel : ViewModelBase
    {
        protected Action CloseWindow { get; set; }

        private RelayCommand _purchaseCommand;
        public ICommand PurchaseCommand
        {
            get
            {
                if (_purchaseCommand == null)
                {
                    _purchaseCommand = new RelayCommand(purchaseHandler, canPurchaseHandler);
                }
                return _purchaseCommand;
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

        private string _customerName;
        public string CustomerName
        {
            get
            {
                return _customerName;
            }
            set
            {
                _customerName = value;
                OnPropertyChanged("CustomerName");
                if (_purchaseCommand != null)
                    _purchaseCommand.RaiseCanExecuteChanged();
            }
        }

        private IEnumerable<EventViewModel> _events;
        public IEnumerable<EventViewModel> Events
        {
            get
            {
                return _events;
            }
            set
            {
                _events = value;
                OnPropertyChanged("Events");
            }
        }

        private EventViewModel _selectedEvent;
        public EventViewModel SelectedEvent
        {
            get
            {
                return _selectedEvent;
            }
            set
            {
                _selectedEvent = value;
                OnPropertyChanged("SelectedEvent");
                if(_purchaseCommand != null)
                    _purchaseCommand.RaiseCanExecuteChanged();
            }
        }

        private int _qty;
        public int Qty
        {
            get
            {
                return _qty;
            }
            set
            {
                _qty = value;
                OnPropertyChanged("Qty");
                if (_purchaseCommand != null)
                    _purchaseCommand.RaiseCanExecuteChanged();
            }
        }

        private decimal _creditCardNumber;
        public decimal CreditCardNumber
        {
            get
            {
                return _creditCardNumber;
            }
            set
            {
                _creditCardNumber = value;
                OnPropertyChanged("CreditCardNumber");
                if (_purchaseCommand != null)
                    _purchaseCommand.RaiseCanExecuteChanged();
            }
        }

        public TicketPurchaseViewModel()
        {
            refreshEvents();
        }

        private void refreshEvents()
        {
            using (IUnitOfWork uow = UnitOfWork.Get())
            {
                var events = uow.RutherfordService.GetEvents();
                this.Events = events.Select(x => new EventViewModel(x)).ToArray();
                this.SelectedEvent = this.Events.FirstOrDefault();
            }
        }

        private void closeHandler(object param)
        {
            this.CloseWindow();
        }

        private bool canPurchaseHandler(object param)
        {
            if (string.IsNullOrWhiteSpace(this.CustomerName))
                return false;
            if (this.SelectedEvent == null)
                return false;
            if (this.Qty <= 0)
                return false;
            return true;
        }

        private void purchaseHandler(object param)
        {
            using (IUnitOfWork uow = UnitOfWork.Get())
            {
                uow.RutherfordService.AddTransaction(this.CustomerName, this.SelectedEvent.EventId, this.Qty, this.CreditCardNumber);
            }
            this.CloseWindow();
        }

        public static void Show()
        {
            var vm = new TicketPurchaseViewModel();
            var v = new TicketPurchaseView();
            
            v.DataContext = vm;
            vm.CloseWindow = v.Close;

            v.Show();
        }
    }
}

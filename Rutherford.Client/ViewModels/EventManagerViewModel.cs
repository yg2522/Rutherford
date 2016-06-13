using Rutherford.Client.Views;
using Rutherford.Client.WpfClasses;
using Rutherford.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Rutherford.Client.ViewModels
{
    public class EventManagerViewModel : ViewModelBase
    {
        public EventManagerViewModel()
        {
            refreshEvents();
        }

        private RelayCommand _addEventCommand;
        public ICommand AddEventCommand
        {
            get
            {
                if (_addEventCommand == null)
                    _addEventCommand = new RelayCommand(addEventHandler, (o) => true);
                return _addEventCommand;
            }
        }

        private RelayCommand _removeEventCommand;
        public ICommand RemoveEventCommand
        {
            get
            {
                if (_removeEventCommand == null)
                    _removeEventCommand = new RelayCommand(removeEventHandler, canRemoveEventHandler);
                return _removeEventCommand;
            }
        }

        private RelayCommand _editEventCommand;
        public ICommand EditEventCommand
        {
            get
            {
                if (_editEventCommand == null)
                    _editEventCommand = new RelayCommand(editEventHandler, canEditEventHandler);
                return _editEventCommand;
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
                if(_removeEventCommand != null)
                    _removeEventCommand.RaiseCanExecuteChanged();
                if(_editEventCommand != null)
                    _editEventCommand.RaiseCanExecuteChanged();
            }
        }

        private void refreshEvents()
        {

            using (IUnitOfWork uow = UnitOfWork.Get())
            {
                var e = uow.RutherfordService.GetEvents();
                this.Events = e.Select(x => new EventViewModel(x)).ToArray();
            }
        }

        private void addEventHandler(object parameters)
        {
            AddEditEventViewModel.Show(null);
            refreshEvents();
        }

        private void removeEventHandler(object parameters)
        {
            using (IUnitOfWork uow = UnitOfWork.Get())
            {
                uow.RutherfordService.RemoveEvent(this.SelectedEvent.EventId);
            }
            refreshEvents();
        }

        private bool canRemoveEventHandler(object parameters)
        {
            return this.SelectedEvent != null;
        }

        private void editEventHandler(object parameters)
        {
            AddEditEventViewModel.Show(this.SelectedEvent.Event);
            refreshEvents();
        }

        private bool canEditEventHandler(object parameters)
        {
            return this.SelectedEvent != null;
        }

        public static void Show()
        {
            EventManagerViewModel vm = new EventManagerViewModel();
            EventManagerView v = new EventManagerView();
            v.DataContext = vm;

            v.Show();
        }
    }
}

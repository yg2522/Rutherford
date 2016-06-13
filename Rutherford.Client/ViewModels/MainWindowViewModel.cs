using Rutherford.Client.Managers;
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
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
        }

        private ICommand _eventManagerCommand;
        public ICommand EventManagerCommand
        {
            get
            {
                if(_eventManagerCommand == null)
                {
                    _eventManagerCommand = new RelayCommand(eventManagerHandler, (o) => true);
                }
                return _eventManagerCommand;
            }
        }

        private ICommand _ticketPurchaseCommand;
        public ICommand TicketPurchaseCommand
        {
            get
            {
                if (_ticketPurchaseCommand == null)
                {
                    _ticketPurchaseCommand = new RelayCommand(ticketPurchaseHandler, (o) => true);
                }
                return _ticketPurchaseCommand;
            }
        }

        private ICommand _purchaseHistoryCommand;
        public ICommand PurchaseHistoryCommand
        {
            get
            {
                if (_purchaseHistoryCommand == null)
                {
                    _purchaseHistoryCommand = new RelayCommand(purchaseHistoryHandler, (o) => true);
                }
                return _purchaseHistoryCommand;
            }
        }

        private void eventManagerHandler(object param)
        {
            EventManagerViewModel.Show();
        }

        private void ticketPurchaseHandler(object param)
        {
            TicketPurchaseViewModel.Show();
        }

        private void purchaseHistoryHandler(object param)
        {
            var dialog = new System.Windows.Forms.SaveFileDialog();
            dialog.DefaultExt = "txt";
            dialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                return;
            var path = dialog.FileName;
            byte[] fileInfo = null;
            using (IUnitOfWork uow = UnitOfWork.Get())
            {
                fileInfo = uow.RutherfordService.GetPurchaseHistoryReport(Encoding.UTF8);
            }

            if (fileInfo == null)
                return;

            Utility.NinjectHelper.Get<IFileManager>().WriteFile(path, fileInfo);
        }
    }
}

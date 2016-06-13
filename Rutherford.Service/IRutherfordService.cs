using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rutherford.Service
{
    public interface IRutherfordService : IDisposable
    {
        #region Customer
        Customer AddCustomer(string name);
        Customer GetCustomer(int customerId);
        IEnumerable<Customer> GetCustomers();
        Customer RemoveCustomer(int customerId);
        Customer UpdateCustomer(int customerId, string name);
        #endregion

        #region Event
        Event AddEvent(string name, DateTime date, string location, decimal price, int totalTickets, string notes);
        Event GetEvent(int eventId);
        IEnumerable<Event> GetEvents();
        Event RemoveEvent(int eventId);
        Event UpdateEvent(int eventId, string name, DateTime date, string location, decimal price, int totalTickets, string notes);
        #endregion

        #region Transaction
        Transaction AddTransaction(string custName, int eventId, int qty, decimal ccNumber);
        Transaction GetTransaction(int customerId, int eventId);
        IEnumerable<Transaction> GetTransactions();
        IEnumerable<Transaction> GetCustomerTransactions(int customerId);
        IEnumerable<Transaction> GetEventTransactions(int eventId);
        byte[] GetPurchaseHistoryReport(Encoding encode);
        #endregion
    }
}

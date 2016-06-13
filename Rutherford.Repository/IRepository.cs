using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rutherford.Repository
{
    public interface IRepository : IDisposable
    {
        #region Add
        AddCustomer_Result AddCustomer(string name);
        AddEvent_Result AddEvent(string name, DateTime date, string location, decimal price, int totalTickets, string notes);
        AddTransaction_Result AddTransaction(int customerId, int eventId, int qty, decimal paid, DateTime date, decimal ccNumber);
        #endregion

        #region Get
        GetCustomer_Result GetCustomer(int customerId);
        IEnumerable<GetCustomers_Result> GetCustomers();
        GetEvent_Result GetEvent(int eventId);
        IEnumerable<GetEvents_Result> GetEvents();
        int GetTotalPurchasedEventTickets(int eventId);
        GetTransaction_Result GetTransaction(int customerId, int eventId);
        IEnumerable<GetTransactions_Result> GetTransactions();
        IEnumerable<GetCustomerTransaction_Result> GetCustomerTransactions(int customerId);
        IEnumerable<GetEventTransaction_Result> GetEventTransactions(int eventId);
        #endregion

        #region Remove
        RemoveCustomer_Result RemoveCustomer(int customerId);
        RemoveEvent_Result RemoveEvent(int eventId);
        #endregion

        #region Update
        UpdateCustomer_Result UpdateCustomer(int customerId, string name);
        UpdateEvent_Result UpdateEvent(int eventId, string name, DateTime date, string location, decimal price, int totalTickets, string notes);
        #endregion
    }
}

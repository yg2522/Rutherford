using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rutherford.Repository
{
    public class Repository : IRepository
    {
        private RutherfordEntities _entity;
        public Repository(string connectionString)
        {
            _entity = new RutherfordEntities(connectionString);
        }

        public void Dispose()
        {
            _entity.Dispose();
        }

        #region Repo Calls
        #region Add
        public AddCustomer_Result AddCustomer(string name)
        {
            return _entity.AddCustomer(name).FirstOrDefault();
        }

        public AddEvent_Result AddEvent(string name, DateTime date, string location, decimal price, int totalTickets, string notes)
        {
            return _entity.AddEvent(name, date, location, price, totalTickets, notes).FirstOrDefault();
        }

        public AddTransaction_Result AddTransaction(int customerId, int eventId, int qty, decimal paid, DateTime date, decimal ccNumber)
        {
            return _entity.AddTransaction(customerId, eventId, qty, paid, date, ccNumber).FirstOrDefault();
        }
        #endregion

        #region Get
        public int GetTotalPurchasedEventTickets(int eventId)
        {
            return _entity.GetTotalPurchasedEventTickets(eventId).First().Value;
        }
        public GetCustomer_Result GetCustomer(int customerId)
        {
            return _entity.GetCustomer(customerId).FirstOrDefault();
        }

        public IEnumerable<GetCustomers_Result> GetCustomers()
        {
            return _entity.GetCustomers().ToArray();
        }

        public GetEvent_Result GetEvent(int eventId)
        {
            return _entity.GetEvent(eventId).FirstOrDefault();
        }

        public IEnumerable<GetEvents_Result> GetEvents()
        {
            return _entity.GetEvents().ToArray();
        }

        public GetTransaction_Result GetTransaction(int customerId, int eventId)
        {
            return _entity.GetTransaction(customerId, eventId).FirstOrDefault();
        }

        public IEnumerable<GetTransactions_Result> GetTransactions()
        {
            return _entity.GetTransactions().ToArray();
        }

        public IEnumerable<GetCustomerTransaction_Result> GetCustomerTransactions(int customerId)
        {
            return _entity.GetCustomerTransaction(customerId).ToArray();
        }

        public IEnumerable<GetEventTransaction_Result> GetEventTransactions(int eventId)
        {
            return _entity.GetEventTransaction(eventId).ToArray();
        }
        #endregion

        #region Remove
        public RemoveCustomer_Result RemoveCustomer(int customerId)
        {
            return _entity.RemoveCustomer(customerId).FirstOrDefault();
        }

        public RemoveEvent_Result RemoveEvent(int eventId)
        {
            return _entity.RemoveEvent(eventId).FirstOrDefault();
        }
        #endregion

        #region Update
        public UpdateCustomer_Result UpdateCustomer(int customerId, string name)
        {
            return _entity.UpdateCustomer(customerId, name).FirstOrDefault();
        }

        public UpdateEvent_Result UpdateEvent(int eventId, string name, DateTime date, string location, decimal price, int totalTickets, string notes)
        {
            return _entity.UpdateEvent(eventId, name, date, location, price, totalTickets, notes).FirstOrDefault();
        }
        #endregion
        #endregion
    }
}

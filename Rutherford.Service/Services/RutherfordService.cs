using Rutherford.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Rutherford.Service.Services
{
    /// <summary>
    /// Business logic for events and ticket purchases
    /// </summary>
    public class RutherfordService : IRutherfordService
    {
        private IRepository _repo;

        public RutherfordService(IRepository repo)
        {
            _repo = repo;
        }

        public void Dispose()
        {
            _repo.Dispose();
            _repo = null;
        }

        #region Customer
        /// <summary>
        /// Adds customer to the repo
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Customer AddCustomer(string name)
        {
            var cust = _repo.AddCustomer(name);
            return ObjectFactory.GetCustomer(cust);
        }

        /// <summary>
        /// Gets a customer from the repo
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public Customer GetCustomer(int customerId)
        {
            var cust = _repo.GetCustomer(customerId);
            return ObjectFactory.GetCustomer(cust);
        }

        /// <summary>
        /// Gets all the customers from the repo
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Customer> GetCustomers()
        {
            var custs = _repo.GetCustomers();
            return custs.Select(c => ObjectFactory.GetCustomer(c)).ToArray();
        }

        /// <summary>
        /// Removes a customer from the repo
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public Customer RemoveCustomer(int customerId)
        {
            var cust = _repo.RemoveCustomer(customerId);
            return ObjectFactory.GetCustomer(cust);
        }

        /// <summary>
        /// Updates a customer in the repo
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public Customer UpdateCustomer(int customerId, string name)
        {
            var cust = _repo.UpdateCustomer(customerId, name);
            return ObjectFactory.GetCustomer(cust);
        }
        #endregion

        #region Event
        /// <summary>
        /// Adds an event to the repo
        /// </summary>
        /// <param name="name"></param>
        /// <param name="date"></param>
        /// <param name="location"></param>
        /// <param name="price"></param>
        /// <param name="totalTickets"></param>
        /// <param name="notes"></param>
        /// <returns></returns>
        public Event AddEvent(string name, DateTime date, string location, decimal price, int totalTickets, string notes)
        {
            var ev = _repo.AddEvent(name, date, location, price, totalTickets, notes);
            return ObjectFactory.GetEvent(ev);
        }

        /// <summary>
        /// Gets an event from the repo
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        public Event GetEvent(int eventId)
        {
            var ev = _repo.GetEvent(eventId);
            return ObjectFactory.GetEvent(ev);
        }

        /// <summary>
        /// Gets all the events from the repo
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Event> GetEvents()
        {
            var evs = _repo.GetEvents();
            return evs.Select(e => ObjectFactory.GetEvent(e)).ToArray();
        }

        /// <summary>
        /// Removes an event from the repo
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        public Event RemoveEvent(int eventId)
        {
            var ev = _repo.RemoveEvent(eventId);
            return ObjectFactory.GetEvent(ev);
        }

        /// <summary>
        /// Updates an event in the repo
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="name"></param>
        /// <param name="date"></param>
        /// <param name="location"></param>
        /// <param name="price"></param>
        /// <param name="totalTickets"></param>
        /// <param name="notes"></param>
        /// <returns></returns>
        public Event UpdateEvent(int eventId, string name, DateTime date, string location, decimal price, int totalTickets, string notes)
        {
            var ev = _repo.UpdateEvent(eventId, name, date, location, price, totalTickets, notes);
            return ObjectFactory.GetEvent(ev);
        }
        #endregion

        #region Transaction
        /// <summary>
        /// Adds a transaction to the repo
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="eventId"></param>
        /// <param name="qty"></param>
        /// <param name="paid"></param>
        /// <param name="date"></param>
        /// <param name="ccNumber"></param>
        /// <returns></returns>
        public Transaction AddTransaction(string custName, int eventId, int qty, decimal ccNumber)
        {
            var e = _repo.GetEvent(eventId);
            int total = _repo.GetTotalPurchasedEventTickets(eventId);
            if (e.TotalTickets - total - qty < 0) //check if you purchased too many
                return null;
            var cust = _repo.AddCustomer(custName);
            decimal paid = qty * e.Price;
            DateTime date = DateTime.Now;
            var trans = _repo.AddTransaction(cust.CustomerId, eventId, qty, paid, date, ccNumber);
            return ObjectFactory.GetTransaction(trans);
        }

        /// <summary>
        /// Gets a transaction from the repo
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="eventId"></param>
        /// <returns></returns>
        public Transaction GetTransaction(int customerId, int eventId)
        {
            var trans = _repo.GetTransaction(customerId, eventId);
            return ObjectFactory.GetTransaction(trans);
        }

        /// <summary>
        /// Gets all transactions from the repo
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Transaction> GetTransactions()
        {
            var trans = _repo.GetTransactions();
            return trans.Select(t => ObjectFactory.GetTransaction(t)).ToArray();
        }

        /// <summary>
        /// Gets all the transactions for a customer
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public IEnumerable<Transaction> GetCustomerTransactions(int customerId)
        {
            var trans = _repo.GetCustomerTransactions(customerId);
            return trans.Select(t => ObjectFactory.GetTransaction(t)).ToArray();
        }

        /// <summary>
        /// Gets all the transactions for an event
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        public IEnumerable<Transaction> GetEventTransactions(int eventId)
        {
            var trans = _repo.GetEventTransactions(eventId);
            return trans.Select(t => ObjectFactory.GetTransaction(t)).ToArray();
        }

        /// <summary>
        /// Gets all the transactions that have happened through the system and encodes them into a report as a byte array
        /// </summary>
        /// <param name="encode"></param>
        /// <returns></returns>
        public byte[] GetPurchaseHistoryReport(Encoding encode)
        {
            byte[] report = null;
            Dictionary<int, GetEvents_Result> events = _repo.GetEvents().ToDictionary(x => x.EventId, x => x);
            Dictionary<int, GetCustomers_Result> customers = _repo.GetCustomers().ToDictionary(x => x.CustomerId, x => x);
            var transactions = _repo.GetTransactions();
            StringBuilder reportString = new StringBuilder();
            foreach(var transaction in transactions)
            {
                reportString.AppendLine(string.Format("Customer: {0}, Event: {1}, Quantity: {2}, Paid: {3}, Purchase Date: {4}, Credit Card: {5}", customers[transaction.CustomerId].Name, events[transaction.EventId].Name, transaction.Qty, transaction.Paid, transaction.Date, transaction.CreditCardNumber));
            }
            report = encode.GetBytes(reportString.ToString());
            return report;
        }
        #endregion
    }
}

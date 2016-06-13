using Rutherford.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rutherford.Service
{
    internal static class ObjectFactory
    {
        #region Customer
        /// <summary>
        /// Creates a customer from an add customer result repository object
        /// </summary>
        /// <param name="edmxObj">the add customer repository object</param>
        /// <returns>a customer</returns>
        public static Customer GetCustomer(AddCustomer_Result edmxObj)
        {
            return new Customer()
            {
                CustomerId = edmxObj.CustomerId,
                Name = edmxObj.Name,
            };
        }

        /// <summary>
        /// Creates a customer from a get customer result repository object
        /// </summary>
        /// <param name="edmxObj">the get customer repository object</param>
        /// <returns>a customer</returns>
        public static Customer GetCustomer(GetCustomer_Result edmxObj)
        {
            return new Customer()
            {
                CustomerId = edmxObj.CustomerId,
                Name = edmxObj.Name,
            };
        }

        /// <summary>
        /// Creates a customer from a get customers result repository object
        /// </summary>
        /// <param name="edmxObj">the get customers repository object</param>
        /// <returns>a customer</returns>
        public static Customer GetCustomer(GetCustomers_Result edmxObj)
        {
            return new Customer()
            {
                CustomerId = edmxObj.CustomerId,
                Name = edmxObj.Name,
            };
        }

        /// <summary>
        /// Creates a customer from a remove customer result repository object
        /// </summary>
        /// <param name="edmxObj">the remove customer repository object</param>
        /// <returns>a customer</returns>
        public static Customer GetCustomer(RemoveCustomer_Result edmxObj)
        {
            return new Customer()
            {
                CustomerId = edmxObj.CustomerId,
                Name = edmxObj.Name,
            };
        }

        /// <summary>
        /// Creates a customer from an updat4e customer result repository object
        /// </summary>
        /// <param name="edmxObj">the update customer repository object</param>
        /// <returns>a customer</returns>
        public static Customer GetCustomer(UpdateCustomer_Result edmxObj)
        {
            return new Customer()
            {
                CustomerId = edmxObj.CustomerId,
                Name = edmxObj.Name,
            };
        }
        #endregion

        #region Event
        /// <summary>
        /// Creates an event from an add event result repository object
        /// </summary>
        /// <param name="edmxObj">the add event repository object</param>
        /// <returns>an event</returns>
        public static Event GetEvent(AddEvent_Result edmxObj)
        {
            return new Event()
            {
                EventId = edmxObj.EventId,
                Name = edmxObj.Name,
                Date = edmxObj.Date,
                Location = edmxObj.Location,
                Price = edmxObj.Price,
                TotalTickets = edmxObj.TotalTickets,
                Notes = edmxObj.Notes,
            };
        }

        /// <summary>
        /// Creates an event from a get event result repository object
        /// </summary>
        /// <param name="edmxObj">the get event repository object</param>
        /// <returns>an event</returns>
        public static Event GetEvent(GetEvent_Result edmxObj)
        {
            return new Event()
            {
                EventId = edmxObj.EventId,
                Name = edmxObj.Name,
                Date = edmxObj.Date,
                Location = edmxObj.Location,
                Price = edmxObj.Price,
                TotalTickets = edmxObj.TotalTickets,
                Notes = edmxObj.Notes,
            };
        }

        /// <summary>
        /// Creates an event from a get events result repository object
        /// </summary>
        /// <param name="edmxObj">the get events repository object</param>
        /// <returns>an event</returns>
        public static Event GetEvent(GetEvents_Result edmxObj)
        {
            return new Event()
            {
                EventId = edmxObj.EventId,
                Name = edmxObj.Name,
                Date = edmxObj.Date,
                Location = edmxObj.Location,
                Price = edmxObj.Price,
                TotalTickets = edmxObj.TotalTickets,
                Notes = edmxObj.Notes,
            };
        }

        /// <summary>
        /// Creates an event from a remove event result repository object
        /// </summary>
        /// <param name="edmxObj">the remove event repository object</param>
        /// <returns>an event</returns>
        public static Event GetEvent(RemoveEvent_Result edmxObj)
        {
            return new Event()
            {
                EventId = edmxObj.EventId,
                Name = edmxObj.Name,
                Date = edmxObj.Date,
                Location = edmxObj.Location,
                Price = edmxObj.Price,
                TotalTickets = edmxObj.TotalTickets,
                Notes = edmxObj.Notes,
            };
        }

        /// <summary>
        /// Creates an event from an update event result repository object
        /// </summary>
        /// <param name="edmxObj">the update event repository object</param>
        /// <returns>an event</returns>
        public static Event GetEvent(UpdateEvent_Result edmxObj)
        {
            return new Event()
            {
                EventId = edmxObj.EventId,
                Name = edmxObj.Name,
                Date = edmxObj.Date,
                Location = edmxObj.Location,
                Price = edmxObj.Price,
                TotalTickets = edmxObj.TotalTickets,
                Notes = edmxObj.Notes,
            };
        }
        #endregion

        #region Transaction
        /// <summary>
        /// Creates a transaction from an add transaction result repository object
        /// </summary>
        /// <param name="edmxObj">the add transaction repository object</param>
        /// <returns>an transaction</returns>
        public static Transaction GetTransaction(AddTransaction_Result edmxObj)
        {
            return new Transaction()
            {
                CustomerId = edmxObj.CustomerId,
                EventId = edmxObj.EventId,
                Qty = edmxObj.Qty,
                Paid = edmxObj.Paid,
                Date = edmxObj.Date,
                CreditCardNumber = edmxObj.CreditCardNumber,
            };
        }

        /// <summary>
        /// Creates a transaction from a get customer transaction result repository object
        /// </summary>
        /// <param name="edmxObj">the get customer transaction repository object</param>
        /// <returns>an transaction</returns>
        public static Transaction GetTransaction(GetCustomerTransaction_Result edmxObj)
        {
            return new Transaction()
            {
                CustomerId = edmxObj.CustomerId,
                EventId = edmxObj.EventId,
                Qty = edmxObj.Qty,
                Paid = edmxObj.Paid,
                Date = edmxObj.Date,
                CreditCardNumber = edmxObj.CreditCardNumber,
            };
        }

        /// <summary>
        /// Creates a transaction from a get event transaction result repository object
        /// </summary>
        /// <param name="edmxObj">the get event transaction repository object</param>
        /// <returns>an transaction</returns>
        public static Transaction GetTransaction(GetEventTransaction_Result edmxObj)
        {
            return new Transaction()
            {
                CustomerId = edmxObj.CustomerId,
                EventId = edmxObj.EventId,
                Qty = edmxObj.Qty,
                Paid = edmxObj.Paid,
                Date = edmxObj.Date,
                CreditCardNumber = edmxObj.CreditCardNumber,
            };
        }

        /// <summary>
        /// Creates a transaction from a get transaction result repository object
        /// </summary>
        /// <param name="edmxObj">the get transaction repository object</param>
        /// <returns>an transaction</returns>
        public static Transaction GetTransaction(GetTransaction_Result edmxObj)
        {
            return new Transaction()
            {
                CustomerId = edmxObj.CustomerId,
                EventId = edmxObj.EventId,
                Qty = edmxObj.Qty,
                Paid = edmxObj.Paid,
                Date = edmxObj.Date,
                CreditCardNumber = edmxObj.CreditCardNumber,
            };
        }

        /// <summary>
        /// Creates a transaction from a get transactions result repository object
        /// </summary>
        /// <param name="edmxObj">the get transactions repository object</param>
        /// <returns>an transaction</returns>
        public static Transaction GetTransaction(GetTransactions_Result edmxObj)
        {
            return new Transaction()
            {
                CustomerId = edmxObj.CustomerId,
                EventId = edmxObj.EventId,
                Qty = edmxObj.Qty,
                Paid = edmxObj.Paid,
                Date = edmxObj.Date,
                CreditCardNumber = edmxObj.CreditCardNumber,
            };
        }
        #endregion
    }
}

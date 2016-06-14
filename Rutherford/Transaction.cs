using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rutherford
{
    /// <summary>
    /// POCO to represent a transaction
    /// </summary>
    public class Transaction
    {
        public int CustomerId { get; set; }
        public int EventId { get; set; }
        public int Qty { get; set; }
        public decimal? Paid { get; set; }
        public DateTime? Date { get; set; }
        public decimal? CreditCardNumber { get; set; }
    }
}

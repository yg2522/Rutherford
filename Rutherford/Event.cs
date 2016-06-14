using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rutherford
{
    /// <summary>
    /// POCO to represent an event
    /// </summary>
    public class Event
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public DateTime? Date { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public int TotalTickets { get; set; }
        public string Notes { get; set; }
    }
}

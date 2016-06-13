using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rutherford.Client.ViewModels
{
    public class EventViewModel
    {
        private Event _e;
        public EventViewModel(Event e)
        {
            _e = e;
        }
        public Event Event { get { return _e; } }
        public int EventId { get { return _e.EventId; } }
        public string Name { get { return _e.Name; } }
        public string Date { get { return _e.Date == null ? string.Empty : _e.Date.ToString(); } }
        public string Location { get { return _e.Location; } }
        public string Price { get { return _e.Price.ToString(); } }
        public int TotalTickets { get { return _e.TotalTickets; } }
        public string Notes { get { return _e.Notes; } }
    }
}

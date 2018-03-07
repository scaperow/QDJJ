using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Core
{
    public class Table : DataTable
    {
        public Dictionary<string, Dictionary<string, EventHandler>>
            Events = new Dictionary<string, Dictionary<string, EventHandler>>();

        public Table()
        {
        }
        public Table(string tableName)
            : base(tableName)
        {
        }

        public void Register(string field, string id, EventHandler handler)
        {
            Dictionary<string, EventHandler<EventArgs>> events;

            if (!this.Events.Contains(field))
            {
                this.Events[field] = new Dictionary<string, EventHandler>();
            }

            events = this.Events[field];
            events[id] = handler;
        }
    }
}

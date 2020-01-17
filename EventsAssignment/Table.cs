using System;
using System.Collections.Generic;
using System.Text;

namespace EventsAssignment
{
    public class Table
    {
        public delegate void TableOpenEventHandler(object source, EventArgs e);

        public event TableOpenEventHandler TableOpenEvent;
        public void Open()
        {
            Console.WriteLine("Table is open!");
            if (TableOpenEvent != null)
            {
                TableOpenEvent(this, EventArgs.Empty);
            }
        }
    }

}

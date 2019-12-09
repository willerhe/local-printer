using System;
using System.Collections.Generic;
using System.Text;

namespace GprinterDEMO
{
    class Configer
    {
        private string topic;
        private List<Printer> printers;

        public Configer()
        {
        }

        public Configer(string topic, List<Printer> printers)
        {
            this.topic = topic;
            this.printers = printers;
        }

        public string Topic { get => topic; set => topic = value; }
        internal List<Printer> Printers { get => printers; set => printers = value; }
    }
}

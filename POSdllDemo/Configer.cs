using System.Collections.Generic;

namespace GprinterDEMO
{
    class Configer
    {
        public string Topic;
        public string Token;
        public List<Printer> Printers;

        public Configer(string topic, string token, List<Printer> printers)
        {
            this.Topic = topic;
            this.Token = token;
            this.Printers = printers;
        }
        public Configer()
        {
        }

     
    }
}

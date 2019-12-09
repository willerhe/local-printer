using System;
using System.Collections.Generic;
using System.Text;

namespace GprinterDEMO
{
    class Printer
    {
        private string Name;
        private string Type;
        private string IP;
        private int Port;
        private int ProductID;
        private int VendorID;
        private int OutEq;
        private int InEq;

        public Printer() { }
        public Printer(string name, string type, string iP, int port, int productID, int vendorID, int outEq, int inEq)
        {
            Name = name;
            Type = type;
            IP = iP;
            Port = port;
            ProductID = productID;
            VendorID = vendorID;
            OutEq = outEq;
            InEq = inEq;
        }

        public string Name1 { get => Name; set => Name = value; }
        public string Type1 { get => Type; set => Type = value; }
        public string IP1 { get => IP; set => IP = value; }
        public int Port1 { get => Port; set => Port = value; }
        public int ProductID1 { get => ProductID; set => ProductID = value; }
        public int VendorID1 { get => VendorID; set => VendorID = value; }
        public int OutEq1 { get => OutEq; set => OutEq = value; }
        public int InEq1 { get => InEq; set => InEq = value; }
    }
}

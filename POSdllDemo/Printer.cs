using System;
using System.Collections.Generic;
using System.Text;

namespace GprinterDEMO
{
    class Printer
    {
        public string PrintName;
        public string PrintType;
        public string PrintIP;
        public int PrintPort;
        public int ProductID;
        public int VendorID;
        public int OutEq;
        public int InEq;

        public Printer() { }
        public Printer(string name, string type, string iP, int port, int productID, int vendorID, int outEq, int inEq)
        {
            PrintName = name;
            PrintType = type;
            PrintIP = iP;
            PrintPort = port;
            ProductID = productID;
            VendorID = vendorID;
            OutEq = outEq;
            InEq = inEq;
        }

    }
}

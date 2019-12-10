using GprinterTest;
using System;
using System.Collections.Generic;
using System.Text;

namespace GprinterDEMO
{
    class PrintHelper
    {
        public static libUsbContorl.UsbOperation NewUsb = new libUsbContorl.UsbOperation();



        public static void USBPrinter(Printer p, Dictionary<string, object> order)
        {
            
            NewUsb.FindUSBPrinter();
            for (int k = 0; k < NewUsb.USBPortCount; k++)
            {
                int i = 0;
                if (NewUsb.LinkUSB(k))
                {
                    byte[] shiftsize = { 0x1d, 0x57, 0xd0, 0x01 };//偏移量
                    byte[] KanjiMode = { 0x1c, 0x26 };//汉字模式

                    SendData2USB(shiftsize);
                    SendData2USB(KanjiMode);

                    #region 打印信息测试
                    string strSend;
                    byte[] SendData = { 0x1b, 0x61, 0x01, 0x1b, 0x21, 0x30, 0x1c, 0x57, 0x01 };
                    byte[] enddata = { 0x0a };//换行

                    SendData2USB(SendData);

                    // 桌号
                    string strSendData = (string)order[""] + "号桌";
                    SendData2USB(strSendData);

                    SendData2USB(new byte[] { 0x0a, 0x0a });
                    SendData2USB(new byte[] { 0x1b, 0x61, 0x00, 0x1b, 0x21, 0x00, 0x1c, 0x57, 0x00 });
                    SendData2USB("名称      单价   数量  金额");
                    SendData2USB(enddata);
                    SendData2USB("---------------------------");
                    SendData2USB(enddata);
                    SendData2USB("烤包子    11      11    11");
                    SendData2USB(enddata);
                    SendData2USB("---------------------------");
                    SendData2USB(enddata);
                    SendData2USB("合计：111元");
                    SendData2USB(enddata);
                    SendData2USB(enddata);
                    SendData2USB(enddata);
                    SendData2USB(enddata);
                    SendData2USB(enddata);
                    #endregion

                    /*#region 字体打印测试
                    SendData2USB(KanjiMode);
                    SendData = new byte[16];
                    int linecount = 3;
                    byte bit = 0xa1, Zone = 0xa1;
                    for (i = 0; i < 16; i += 2)
                    {
                        SendData[i] = Zone;
                        SendData[i + 1] = bit;
                        bit++;
                    }
                    SendData2USB(enddata);
                    SendData2USB(SendData);

                    Zone = 0xb0;
                    bit = 0xa1;
                    for (i = 0; i < linecount; i++)
                    {
                        for (int j = 0; j < 16; j += 2)
                        {
                            SendData[j] = Zone;
                            SendData[j + 1] = bit;
                            Zone++;
                        }
                        bit++;
                        SendData2USB(enddata);
                        SendData2USB(SendData);
                    }
                    SendData2USB(enddata);
                    SendData2USB(enddata);
                    #endregion*/

                    SendData2USB(new byte[] { 0x10, 0x04, 0x01 });//查询状态
                    byte[] readData = new byte[] { };
                    NewUsb.ReadDataFmUSB(ref readData);
                    NewUsb.CloseUSBPort();
                }
            }

        }

        internal static void USBPrinterTest(Printer p)
        {

            NewUsb.FindUSBPrinter();
            for (int k = 0; k < NewUsb.USBPortCount; k++)
            {
                int i = 0;
                if (NewUsb.LinkUSB(k))
                {
                    byte[] shiftsize = { 0x1d, 0x57, 0xd0, 0x01 };//偏移量
                    byte[] KanjiMode = { 0x1c, 0x26 };//汉字模式

                    SendData2USB(shiftsize);
                    SendData2USB(KanjiMode);

                    #region 打印信息测试
                    string strSend;
                    byte[] SendData = { 0x1b, 0x61, 0x01, 0x1b, 0x21, 0x30, 0x1c, 0x57, 0x01 };
                    byte[] enddata = { 0x0a };//换行

                    SendData2USB(SendData);

                    // 桌号
                    string strSendData = "小票测试";
                    SendData2USB(strSendData);

                    SendData2USB(new byte[] { 0x0a, 0x0a });
                    SendData2USB(new byte[] { 0x1b, 0x61, 0x00, 0x1b, 0x21, 0x00, 0x1c, 0x57, 0x00 });
                    SendData2USB("名称      单价   数量  金额");
                    SendData2USB(enddata);
                    SendData2USB("---------------------------");
                    SendData2USB(enddata);
                    SendData2USB("烤包子    11      11    11");
                    SendData2USB(enddata);
                    SendData2USB("---------------------------");
                    SendData2USB(enddata);
                    SendData2USB("合计：111元");
                    SendData2USB(enddata);
                    SendData2USB(enddata);
                    SendData2USB(enddata);
                    SendData2USB(enddata);
                    SendData2USB(enddata);
                    #endregion
                    SendData2USB(new byte[] { 0x10, 0x04, 0x01 });//查询状态
                    byte[] readData = new byte[] { };
                    NewUsb.ReadDataFmUSB(ref readData);
                    NewUsb.CloseUSBPort();
                }
            }
        }

        internal static void NetworkPrinterTest(Printer p)
        {
            Console.WriteLine("网口测试");
            LoadPOSDll PosPrint = new LoadPOSDll();
            //POS_COM_DTR_DSR 0x00 流控制为DTR/DST  
            //POS_COM_RTS_CTS 0x01 流控制为RTS/CTS 
            //POS_COM_XON_XOFF 0x02 流控制为XON/OFF 
            //POS_COM_NO_HANDSHAKE 0x03 无握手 
            //POS_OPEN_PARALLEL_PORT 0x12 打开并口通讯端口 
            //POS_OPEN_BYUSB_PORT 0x13 打开USB通讯端口 
            //POS_OPEN_PRINTNAME 0X14 打开打印机驱动程序 
            //POS_OPEN_NETPORT 0x15 打开网络接口 

            if (PosPrint.OpenNetPort("192.168.1.124"))//当参数nParam的值为POS_OPEN_NETPORT时，表示打开指定的网络接口，如“192.168.10.251”表示网络接口IP地址，打印时参考
            {
                //驱动打印句柄
                IntPtr Gp_IntPtr = PosPrint.POS_IntPtr;
            }
            if (LoadPOSDll.POS_StartDoc())
            {
                byte[] by_SendData = System.Text.Encoding.Default.GetBytes("test print\r\n");
                LoadPOSDll.POS_WriteFile(PosPrint.POS_IntPtr, by_SendData, (uint)by_SendData.Length);
                LoadPOSDll.POS_WriteFile(PosPrint.POS_IntPtr, new byte[] { 0x0a }, 1);
                LoadPOSDll.POS_EndDoc();
            }
        }

        internal static void SmartPrinter(string v)
        {
            Dictionary<string,Object> order =  Strconv.String2Dict(v);
            USBPrinter(null,order);
            NetworkPrinter(null, order);
        }

        private static void SendData2USB(byte[] str)
        {
            NewUsb.SendData2USB(str, str.Length);
        }
        private static void SendData2USB(string str)
        {
            byte[] by_SendData = System.Text.Encoding.GetEncoding(54936).GetBytes(str);
            SendData2USB(by_SendData);
        }

        public static void NetworkPrinter(Printer p, Dictionary<string, object> order)
        {
            Console.WriteLine("网口测试");
            LoadPOSDll PosPrint = new LoadPOSDll();
            //POS_COM_DTR_DSR 0x00 流控制为DTR/DST  
            //POS_COM_RTS_CTS 0x01 流控制为RTS/CTS 
            //POS_COM_XON_XOFF 0x02 流控制为XON/OFF 
            //POS_COM_NO_HANDSHAKE 0x03 无握手 
            //POS_OPEN_PARALLEL_PORT 0x12 打开并口通讯端口 
            //POS_OPEN_BYUSB_PORT 0x13 打开USB通讯端口 
            //POS_OPEN_PRINTNAME 0X14 打开打印机驱动程序 
            //POS_OPEN_NETPORT 0x15 打开网络接口 

            if (PosPrint.OpenNetPort("192.168.1.124"))//当参数nParam的值为POS_OPEN_NETPORT时，表示打开指定的网络接口，如“192.168.10.251”表示网络接口IP地址，打印时参考
            {
                //驱动打印句柄
                IntPtr Gp_IntPtr = PosPrint.POS_IntPtr;
            }
            if (LoadPOSDll.POS_StartDoc())
            {
                byte[] by_SendData = System.Text.Encoding.Default.GetBytes("test print\r\n");
                LoadPOSDll.POS_WriteFile(PosPrint.POS_IntPtr, by_SendData, (uint)by_SendData.Length);
                LoadPOSDll.POS_WriteFile(PosPrint.POS_IntPtr, new byte[] { 0x0a }, 1);
                LoadPOSDll.POS_EndDoc();
            }

        }
    }
}

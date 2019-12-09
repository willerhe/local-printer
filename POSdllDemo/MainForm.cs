using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GprinterDEMO
{
    public partial class MainForm : Form
    {
        private static List<Printer> list;

        internal static List<Printer> List { get => list; set => list = value; }

        public MainForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        // 初始化数据
        internal void InitData()
        {
            Console.WriteLine("加载本地打印机");
            FrameHelper.AutoSizeColumn(this.dataGridView1);

            // 获取本地的配置文件
            Configer config = GetLocalConfig();
            foreach (Printer printer in config.Printers)
            {
                int index = this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[index].Cells[0].Value = printer.Name1 ;
                this.dataGridView1.Rows[index].Cells[1].Value = printer.Type1;
                this.dataGridView1.Rows[index].Cells[2].Value = "正常";
                this.dataGridView1.Rows[index].Cells[3].Value = "测试";
                this.dataGridView1.Rows[index].Cells[4].Value = "删除";
                
            }
            Console.WriteLine("监听mqtt消息");

        }

        // todo 读取本地的config文件
        private Configer GetLocalConfig()
        {
            
            
            list = new List<Printer>();
            string name = "USB打印机";
            string type = "USB";
            string iP = "";

            int port = 9100;
            int productID = 1;
            int vendorID = 1;
            int outEq = 1;
            int inEq = 1;

            Printer p1 = new Printer(name, type, iP,  port,  productID,  vendorID,  outEq,  inEq);
            Printer p2 = new Printer("网络打印机", "NETWORK", "192.168.1.124",  9100,  0,  0,  0,  0);
            list.Add(p1);
            list.Add(p2);

            Configer configer = new Configer("prod/printer/10009",list);

            return configer;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddUsbPrinterForm addUsbPrinterForm = new AddUsbPrinterForm();
            addUsbPrinterForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddNetworkPrinterForm addNetworkPrinterForm = new AddNetworkPrinterForm();
            addNetworkPrinterForm.ShowDialog();
        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine("点击了view event",e.ColumnIndex);

            if(e.ColumnIndex == 3)
            {
                Printer p = list[e.RowIndex];
                if(p.Type1 == "USB")
                {
                    PrintHelper.USBPrinter(p);
                }
                else if (p.Type1 == "NETWORK")
                {
                    PrintHelper.NetworkPrinter(p);
                }
                // 测试打印
                
            }
        }
    }
}

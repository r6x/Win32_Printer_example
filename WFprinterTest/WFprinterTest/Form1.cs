using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Printing;
using System.Drawing.Printing;
using System.Management;

namespace WFprinterTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

    
        private void button1_Click(object sender, EventArgs e)
        {

            string alalal;
            ManagementObjectSearcher searcher = new
        ManagementObjectSearcher("SELECT * FROM CIM_LogicalDevice where Default=True");

            string printerName = "";
            foreach (ManagementObject printer in searcher.Get())
            {
                printerName = printer["Name"].ToString().ToLower();
                label10.Text="Printer :" + printerName;
                // PrintProps(printer, "WorkOffline");
                //Console.WriteLine();
               label9.Text=printer["Availability"].ToString();
                switch (Int32.Parse(printer["PrinterStatus"].ToString()))
                {
                    case 1: label1.Text="Other"; break;
                    case 2: label2.Text = "another"; break;
                    case 3: label3.Text = "Idle"; break;
                    case 4: label4.Text = "printing"; break;
                    case 5: label5.Text = "warmup"; break;
                    case 6: label6.Text = "stopped printing"; break;
                    case 7: label7.Text = "offline"; break;
                }
            }

            //alalal = objInst.Description;
            /*
            PrintDocument pd = new PrintDocument();
            LocalPrintServer server = new LocalPrintServer();
            PrintQueue pq = server.GetPrintQueue(pd.PrinterSettings.PrinterName);
            //alalal = pd.PrinterSettings.;
           label1.Text = pd.PrinterSettings.PrinterName;
            label2.Text = "Is Offline: " + pq.IsOffline.ToString();
            label3.Text = "Is waiting: " + pq.IsWaiting.ToString();
            label4.Text = "Is busy: " + pq.IsBusy.ToString();
            label5.Text = "Is in Error: " + pq.IsInError.ToString();
            label6.Text = "Is initializing: " + pq.IsInitializing.ToString();
            label7.Text = "Is not avaliable: " + pq.IsNotAvailable.ToString();
            label8.Text = "Is out of paper: " + pq.IsOutOfPaper.ToString();
            label9.Text = "Is IO active: " + pq.IsIOActive.ToString();
            label10.Text = "Is server unknown: ";
            */
            // MessageBox.Show("Printer name " + pd.PrinterSettings.PrinterName + "IsNotAvaliable " + printQueue.IsNotAvailable.ToString()
            //    + " IsInError " + printQueue.IsInError.ToString() + " IsOfflne "
            //   + printQueue.IsOffline.ToString() + "queue ststays " + printQueue.QueueStatus, "mesage");
        }
    }
}

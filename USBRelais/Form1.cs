using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibUsbDotNet;
using LibUsbDotNet.Main;

namespace USBRelais
{
    public partial class Form1 : Form
    {
        public static UsbDevice MyUsbDevice;
        public static UsbDeviceFinder MyUsbFinder = new UsbDeviceFinder(0x16C0, 0x05DC);

        public Form1()
        {
            InitializeComponent();
        }

        private Boolean getStatus()
        {
            int transferred;
            byte[] buffer = new byte[1] { 0x00 };

            UsbSetupPacket setupPkt = new UsbSetupPacket((byte)(UsbCtrlFlags.Recipient_Interface | UsbCtrlFlags.RequestType_Vendor | UsbCtrlFlags.Direction_In), 4, 0, 0, 0);
            MyUsbDevice.ControlTransfer(ref setupPkt, buffer, buffer.Length, out transferred);
            if (transferred == 1)
            {
                return (buffer[0] == 0);
            }
            return false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ErrorCode ec = ErrorCode.None;

            try
            {
                MyUsbDevice = UsbDevice.OpenUsbDevice(MyUsbFinder);
                if (MyUsbDevice == null) throw new Exception("Device not Found.");
                timer1.Enabled = true;
            }
            catch
            {
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int transferred;
            byte[] buffer = new byte[1] { 0x00 };

            UsbSetupPacket setupPkt = new UsbSetupPacket((byte) (UsbCtrlFlags.Recipient_Interface | UsbCtrlFlags.RequestType_Vendor | UsbCtrlFlags.Direction_In), 1, 0, 0, 0);
            MyUsbDevice.ControlTransfer(ref setupPkt, buffer, buffer.Length, out transferred);
            checkBox1.Checked = getStatus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            checkBox1.Checked = getStatus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int transferred;
            byte[] buffer = new byte[1] { 0x00 };

            UsbSetupPacket setupPkt = new UsbSetupPacket((byte)(UsbCtrlFlags.Recipient_Interface | UsbCtrlFlags.RequestType_Vendor | UsbCtrlFlags.Direction_In), 2, 0, 0, 0);
            MyUsbDevice.ControlTransfer(ref setupPkt, buffer, buffer.Length, out transferred);
            checkBox1.Checked = getStatus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int transferred;
            byte[] buffer = new byte[1] { 0x00 };

            UsbSetupPacket setupPkt = new UsbSetupPacket((byte)(UsbCtrlFlags.Recipient_Interface | UsbCtrlFlags.RequestType_Vendor | UsbCtrlFlags.Direction_In), 3, 0, 0, 0);
            MyUsbDevice.ControlTransfer(ref setupPkt, buffer, buffer.Length, out transferred);
            checkBox1.Checked = getStatus();
        }
    }
}

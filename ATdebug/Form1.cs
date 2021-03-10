using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Runtime.InteropServices;

namespace ATdebug
{
    public partial class ATcontrol : Form
    {
        string[] baudrates = { "9600", "19200", "38400", "57600", "74880", "115200" };
        string[] ATcommands = { "Restore ESP-01 _AT+RESTORE", "Reset ESP-01 _AT+RST", "Show info _AT+GMR",
            "Show SYSRAM _AT+SYSRAM?", "Show UART setup _AT+UART_CUR?",
            "Show connection status _AT+CIPSTATUS", "Show AP Connection _AT+CWJAP?",
            "WiFi mode Client _AT+CWMODE=1", "WiFi mode Server _AT+CWMODE=2",
            "Close connection _AT+CIPCLOSE",
            "Get local IP _AT+CIFSR",
            "Allow single connection _AT+CIPMUX=0", "Allow multiple connection _AT+CIPMUX=1",
            "Show AP-survey _AT+CWLAP", 
            "Local Echo Off _ATE0", "Local Echo On _ATE1",  };
        // private SerialPort port = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
        // static SerialPort _serialPort;
        string dataIn;
        string wifi_SSID;
        string wifi_PWD;
        string host_name;
        string host_IP;
        int uartFlag = 0;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        const int EM_SETCUEBANNER = 0x1501;

        public ATcontrol()
        {
            InitializeComponent();

            _serialPort = new SerialPort();
            UpdateCOM();
            InitBaud();
            InitATcommand();
            // Put something in the TB to indicate expected format
            // tbWeb.Text = "http://192.168.2.111/index.html";
            SendMessage(tbWeb.Handle, EM_SETCUEBANNER, 1, "http://192.168.2.111/index.html");
        }

        private void UpdateCOM()
        {
            cbSelectCOM.Items.Clear();
            // Get a list of serial port names.
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                cbSelectCOM.Items.Add(port);
            }
            if (cbSelectCOM.Items.Count > 0)
                cbSelectCOM.SelectedIndex = 0;
        }

        private void InitATcommand()
        {
            int i = -1;
            // Insert text up to the _ 
            cbATcommand.Items.Clear();
            foreach (string command in ATcommands)
            {
                i = command.IndexOf('_');
                if (i > 0)
                    cbATcommand.Items.Add(command.Substring(0,i-1));
            }
        }

        private void InitBaud()
        {
            cbSelectBaud.Items.Clear();
            foreach (string baud in baudrates)
            {
                cbSelectBaud.Items.Add(baud);
            }
            cbSelectBaud.SelectedIndex = 5;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateCOM();
        }

        private void cbSelectCOM_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_serialPort.IsOpen)
                    _serialPort.Close();
                _serialPort.PortName = cbSelectCOM.Text;
                _serialPort.Open();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbSelectBaud_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_serialPort.IsOpen)
                    _serialPort.Close();
                _serialPort.BaudRate = Convert.ToInt32(cbSelectBaud.Text);
                _serialPort.RtsEnable = false;
                _serialPort.DtrEnable = false;
                _serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataReceived);

                _serialPort.Open();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

 

        private void tbSSID_TextChanged(object sender, EventArgs e)
        {
            wifi_SSID = tbSSID.Text;
            tbDebug.Text = wifi_SSID;
        }

        private void tbPasswd_TextChanged(object sender, EventArgs e)
        {
            wifi_PWD = tbPasswd.Text;
            // tbDebug.Text = wifi_PWD;
            btnCWJAP.Enabled = true;
        }

        private void btnCWJAP_Click(object sender, EventArgs e)
        {
            // Connect to WLAN
            string buffer;
            buffer = "AT+CWJAP=\"" + wifi_SSID + "\",\"" + wifi_PWD + "\"";
            tbDebug.Text = buffer;
            if (_serialPort.IsOpen)
            {
                _serialPort.Write(buffer);
                _serialPort.Write("\r\n");
            }
        }

 

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbDataIn.Clear();
        }

        private void cbATcommand_SelectedIndexChanged(object sender, EventArgs e)
        {
            int j = -1;
            string command = "";

            // Execute the command selected...
            string currentCmd = cbATcommand.Text;
            if (_serialPort.IsOpen)
            {
                // 1.1: Match selected text to the list ATCommands
                foreach (string cmd in ATcommands)
                {
                    if (cmd.Contains(currentCmd))
                    {
                        j = cmd.IndexOf('_');
                        if (j > 0)
                        {
                            j++;
                            command = cmd.Substring(j);
                        }
                        break;
                    }
                }
                if (j > 0)
                {
                    _serialPort.Write(command);
                    _serialPort.Write("\r\n");
                }
            }
        }
 
        private void tbHost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                host_name = tbHost.Text;
                tbDebug.Text = "Hostname " + host_name;
                if (_serialPort.IsOpen)
                {
                    string buffer = "AT+CIPDOMAIN=\"" + tbHost.Text + "\"";
                    _serialPort.Write(buffer);
                    _serialPort.Write("\r\n");
                }
            }
        }

        private void tbPing_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                host_IP = tbPing.Text;
                tbDebug.Text = "Address " + host_IP;
                if (_serialPort.IsOpen)
                {
                    string buffer = "AT+PING=\"" + tbPing.Text + "\"";
                    tbDebug.Text = buffer;
                    _serialPort.Write(buffer);
                    _serialPort.Write("\r\n");
                }
            }
        }

        private void tbManuel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                string buffer = tbManuel.Text;
                if (_serialPort.IsOpen)
                {
                    _serialPort.Write(buffer);
                    _serialPort.Write("\r\n");
                }
            }
        }

        private void tbWeb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                string buffer = tbWeb.Text;
                if (buffer.Length > 10)
                {
                    if (_serialPort.IsOpen)
                    {
                        // 1.   Send AT+CIPMUX=1
                        // 2.   Send: AT+CIPSTART=4,"TCP","<host-part>",80
                        // 3.   Build string
                        //          GET <path> HTTP/1.1/r/n
                        //          User-agent: ESP-01
                        //          Host: <host-part>/r/n\r\n
                        // 4. Send AT+CIPSEND=4,<total length incl \r\n>
                        _serialPort.Write(buffer);
                        _serialPort.Write("\r\n");
                    }
                }
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (_serialPort.IsOpen)
            {
                _serialPort.Write("AT+CIPMUX=0");
                _serialPort.Write("\r\n");
                Task.Delay(100).Wait();
                _serialPort.Write("AT+CIPSTART=\"TCP\",\"api.coindesk.com\",80");
                _serialPort.Write("\r\n");
                Task.Delay(5000).Wait();
                _serialPort.Write("AT+CIPSEND=86");
                _serialPort.Write("\r\n");
                Task.Delay(5000).Wait();
                _serialPort.Write("GET /v1/bpi/currentprice.json HTTP/1.1");
                _serialPort.Write("\r\n");
                Task.Delay(200).Wait();
                _serialPort.Write("User-agent: ESP-01");
                _serialPort.Write("\r\n");
                Task.Delay(200).Wait();
                _serialPort.Write("Host: api.coindesk.com");
                _serialPort.Write("\r\n\r\n");
                Task.Delay(200).Wait();

            }
        }

        private void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            dataIn = _serialPort.ReadExisting();
            this.Invoke(new EventHandler(showData));
        }

        private void showData(object sender, EventArgs e)
        {
            // Some interpretation of received data....
            tbDataIn.AppendText(dataIn);
            if (dataIn.Contains("OK"))
                if (dataIn.Contains("+CIPDOMAIN"))
                {
                    int i = dataIn.IndexOf(':');
                    int j = dataIn.IndexOf('\r');
                    tbPing.Text = dataIn.Substring(i + 1, j - i - 1);

                }
        }
    }
}
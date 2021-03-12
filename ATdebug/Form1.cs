using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ATdebug
{
    public partial class ATcontrol : Form
    {
        string[] baudrates = { "9600", "19200", "38400", "57600", "74880", "115200" };
        string[] ATcommands = { "Select a command _x", "Restore ESP-01 _AT+RESTORE", "Reset ESP-01 _AT+RST", "Show info _AT+GMR",
            "Show SYSRAM _AT+SYSRAM?", "Show UART setup _AT+UART_CUR?",
            "Show connection status _AT+CIPSTATUS", "Show AP Connection _AT+CWJAP?",
            "WiFi mode Client _AT+CWMODE=1", "WiFi mode Server _AT+CWMODE=2",
            "Close connection _AT+CIPCLOSE",
            "Get local IP _AT+CIFSR",
            "Allow single connection _AT+CIPMUX=0", "Allow multiple connection _AT+CIPMUX=1",
            "Show AP-survey _AT+CWLAP", 
            "Local Echo Off _ATE0", "Local Echo On _ATE1",  };
        // private SerialPort port = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);

        static SerialPort _serialPort;
        private string dataIn;
        string wifi_SSID;
        string wifi_PWD;
        string host_name;
        string host_IP;
        int flagBitcoin = 0;
        int flagBitCoinDisplay = 0;
 
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        const int EM_SETCUEBANNER = 0x1501;

        public ATcontrol()
        {
            InitializeComponent();

            _serialPort = new SerialPort();
            //==    this.myDelegate = new AddDataDelegate(retrieveSerial);
            UpdateCOM();
            InitBaud();
            InitATcommand();
            // Put something in the TB to indicate expected format
            // tbWeb.Text = "http://192.168.2.111/index.html";
            SendMessage(tbWeb.Handle, EM_SETCUEBANNER, 1, "http://192.168.2.111/index.html");
            this.timer1.Enabled = true;
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
            this.timer1.Enabled = false;
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
                _serialPort.Handshake = Handshake.None;

                _serialPort.Open();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void parseJson(string data)
        {
            var bitcoin = JObject.Parse(data);
            string dollar = (string)bitcoin["bpi"]["USD"]["rate_float"];
            tbBitcoin.Text = dollar;
            tbDataIn.Visible = false;
            tbBitcoin.Visible = true;
            labelBitcoin.Visible = true;
            flagBitCoinDisplay = 5;
            // tbDataIn.AppendText(bitcoin["bpi"]["USD"]["rate_float"]);
            int i = 12;

        }

        // sendCmd accept two arguments:
        //  cmd which is the command to be sent
        //  timeout is number of seconds to wait for an OK or ERROR
        private Boolean sendCmd(string cmd, int timeout)
        {
            int uartFlag = 0;
            int counter = 0;

            this.timer1.Stop();             // Disable reading UART data at two places
            saveLog(cmd, 1);
            _serialPort.DiscardInBuffer();
            if (cmd.Length > 0)
                _serialPort.Write(cmd);
            _serialPort.Write("\r\n");
            tbDataIn.AppendText("==> Entering sendCmd <===\r\n");
            dataIn = "";
            long now = DateTimeOffset.Now.ToUnixTimeSeconds();
            while (uartFlag == 0)
            {
                // just wait for a reply
                dataIn += _serialPort.ReadExisting();
                if (dataIn.Contains("OK"))
                {
                    uartFlag = 1;
                }
                if (dataIn.Contains("ERROR"))
                {
                    uartFlag = -1;
                }
                if (dataIn.Contains("CONNECT")) { 
                    pbConnectStatus.BackColor = Color.Green;
                    tbDataIn.AppendText("RECEIVED CONNECT\r\n");
                }
                if (dataIn.Contains("CLOSED"))
                {
                    pbConnectStatus.BackColor = Color.Red;
                    uartFlag = 1;
                }
                if (dataIn.Contains("+CIPDOMAIN:"))
                {
                    int start = dataIn.IndexOf(':');
                    int end = dataIn.IndexOf('\r', start);
                    if (end > start)
                        tbPing.Text = dataIn.Substring(start + 1, end - start - 1);
                }
                if ((DateTimeOffset.Now.ToUnixTimeSeconds() - now) >= timeout)
                {
                    uartFlag = -2;
                    tbDataIn.AppendText("TIMEOUT REACHED\r\n");
                }
                Thread.Yield();
                Task.Delay(200).Wait();
                counter++;
            }
            tbDataIn.AppendText(dataIn);

            /*
             * Check if this was a bitcoin test
             */
            if ((flagBitcoin == 1) && dataIn.Contains("200 OK"))
            {
                int header = dataIn.IndexOf("+IPD");
                if (header > 0)
                {
                    // Get Body part
                    int body = dataIn.IndexOf("\r\n\r\n", header);
                    if (body > 0) {
                        body += 4;
                        int end = dataIn.IndexOf("CLOSED", body);
                        if (body > 0)
                        {
                            // MessageBox.Show(dataIn.Substring(body, end-body), "BitCoin");
                            saveLog(dataIn.Substring(body, end - body), 3);
                            parseJson(dataIn.Substring(body, end - body));
                        }
                        else
                        {
                            // MessageBox.Show(dataIn.Substring(body), "BitCoin");
                            saveLog(dataIn.Substring(body), 3);
                            parseJson(dataIn.Substring(body));
                        }
                    }
                }

                flagBitcoin = 0;
            }
            tbDataIn.AppendText("==> Leaving sendCmd <===\r\n");
            this.timer1.Start();             // Enable reading UART data in function "timer1_Tick"
            if (uartFlag == 1)
                return true;
            else
                return false;   // ERROR or timeout
        }

        private void tbSSID_TextChanged(object sender, EventArgs e)
        {
            wifi_SSID = tbSSID.Text;
        }

        private void tbPasswd_TextChanged(object sender, EventArgs e)
        {
            wifi_PWD = tbPasswd.Text;
            btnCWJAP.Enabled = true;
        }

        private void btnCWJAP_Click(object sender, EventArgs e)
        {
            // Connect to WLAN
            string buffer;
            // First set mode to client
            sendCmd("AT+CWMODE=1", 10);

            buffer = "AT+CWJAP=\"" + wifi_SSID + "\",\"" + wifi_PWD + "\"";
            if (_serialPort.IsOpen)
            {
                sendCmd(buffer, 10);
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
                            if (cmd.Substring(j).Length > 2)
                                command = cmd.Substring(j);
                        }
                        break;
                    }
                }
                if (j > 0)
                {
                    if (command.Length > 2)
                        sendCmd(command, 10);
                }
            }
            cbATcommand.SelectedIndex = 0;
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
                    sendCmd(buffer, 10);
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
                    sendCmd(buffer, 10);
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
                    sendCmd(buffer, 10);
                }
            }
        }

        private void getWebContent(string host, string file, int flagSomething)
        {
            Boolean status = false;
            Boolean cont = true;
            string string1 = "";
            string string2 = "";
            string string3 = "";
            string string4 = "";

            if (_serialPort.IsOpen)
            {
                // Prepare to analyze the returned json-data
                if (flagSomething == 1)
                    flagBitcoin = 1;
                else
                    flagBitcoin = 0;

                saveLog("Starting:", 1);
                saveLog("AT+CIPMUX=0", 1);

                status = sendCmd("AT+CIPMUX=0", 5);
                if (!status)
                {
                    tbDebug.Text = "Timeout CIPMUX";
                    cont = false;
                }
                if (status && cont)
                {
                    saveLog("AT+CIPSTART", 10);
                    status = sendCmd("AT+CIPSTART=\"TCP\",\"" + host + "\",80", 10);
                    if (!status)
                    {
                        tbDebug.Text = "Timeout CIPSTART";
                        cont = false;
                    }
                }

                if (status && cont)
                {
                    // prepare the request
                    string1 = "GET " + file + " HTTP/1.1\r\n";
                    string2 = "User-agent: ESP-01\r\n";
                    string3 = "Host: " + host + "\r\n";
                    string4 = "Connection: close\r\n";
                    int request_length = 2 + string1.Length + string2.Length + string3.Length + string4.Length;

                    status = sendCmd("AT+CIPSEND=" + request_length.ToString(), 10);
                    if (!status)
                    {
                        tbDebug.Text = "Timeout CIPSEND";
                        cont = false;
                    }
                }

                if (status && cont)
                {
                    _serialPort.Write(string1);
                    _serialPort.Write(string2);
                    _serialPort.Write(string3);
                    _serialPort.Write(string4);
                    status = sendCmd("", 30);
                    if (!status)
                    {
                        tbDebug.Text = "Timeout GET";
                        cont = false;
                    }
                }
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            getWebContent("api.coindesk.com", "/v1/bpi/currentprice.json", 1);
        }
        private void tbWeb_KeyDown(object sender, KeyEventArgs e)
        {
            int p = 0;
            int q = 0;

            if (e.KeyCode == Keys.Return)
            {
                string url = tbWeb.Text;
                if (url.Length > 10)
                {
                    // Fetch and verify a complete URL
                    // http://www.something.com/index3.html
                    p = url.IndexOf('/');
                    if (p > 0)
                    {
                        p += 2;
                        q = url.IndexOf('/', p);
                        if (q > 0)
                        {
                            // I now have the whole string
                            string host = url.Substring(p, q - p);
                            string file = url.Substring(q);
                            // string buffer = String.Format("I have host: {0} and file {1}", host, file);
                            // MessageBox.Show(buffer, "Summary");
                            if (_serialPort.IsOpen)
                                getWebContent(host, file, 0);
                        }
                    }
                }
                if (q == 0)
                    MessageBox.Show("Something was found in error in the URL-string\r\nShould be on the format http://192.168.1.10/index.html\r\nor http://www.someserver.com/indexpage.html", "Error in URL");
            }
        }

        private void saveLog(string line, int direction)
        {
            string fn = @"c:\temp\debug.log";
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(fn, true))
            {
                switch (direction)
                {
                    case 0:
                        file.Write("<== ");
                        break;
                    case 1:
                        file.Write("==> ");
                        break;
                    default:
                        file.Write("<=> ");
                        break;
                }

                file.WriteLine(line);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Any Bitcoin display
            if (flagBitCoinDisplay > 0)
            {
                flagBitCoinDisplay--;
                if (flagBitCoinDisplay == 0)
                {
                    tbDataIn.Visible = true;
                    tbBitcoin.Visible = false;
                    labelBitcoin.Visible = false;
                }
            }
            if (_serialPort.IsOpen)
            {
                string temp = _serialPort.ReadExisting();
                if (temp.Length > 1)
                {
                    saveLog(temp, 3);
                    tbDataIn.AppendText("Received by timer routine:\r\n");
                    tbDataIn.AppendText(temp);

                    if (temp.Contains("CONNECT"))
                        pbConnectStatus.BackColor = Color.Green;
                    if (temp.Contains("CLOSED"))
                        pbConnectStatus.BackColor = Color.Red;
                }
            }
        }
    }
}
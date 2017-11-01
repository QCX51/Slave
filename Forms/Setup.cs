using System;
using System.Windows.Forms;
using Classes;
using System.Net;
using System.Net.Sockets;
namespace Forms
{
    internal partial class Setup : Form
    {

        public Setup()
        {
            InitializeComponent();
            IPvXBox.Text = AppData.ENDPOINT.IPvX;
            PtNoBox.Text = Convert.ToString(AppData.ENDPOINT.PtNo);
            CloseLink.Click += new EventHandler(delegate (object o, EventArgs ev)
            { DialogResult = DialogResult.No; this?.Close(); });
            ConnectBtn.MouseDown += new MouseEventHandler(delegate (object o, MouseEventArgs e)
            { System.Threading.Tasks.Task.Factory.StartNew(new Action(BeginConnect)); });
        }

        private void BeginConnect()
        {
            string IPvX = IPvXBox.Text;
            int PtNo = Convert.ToInt32(PtNoBox.Text);
            string StatusText = string.Format("Connecting to: {0}\non port: {1}", IPvX, PtNo);
            UpdateButtonStatus(false, "Connecting");
            if (Network.GetIPHostEntry(ref IPvX)) { UpdateStatusText(StatusText); }
            else
            {
                UpdateStatusText("Error: " + IPvX);
                UpdateButtonStatus(true, "Connect");
                return;
            }
            Socket TcpSocket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            try { TcpSocket.Connect(IPAddress.Parse(IPvX), PtNo); }
            catch (Exception ex)
            {
                UpdateStatusText("Error: " + ex.Message);
                UpdateButtonStatus(true, "Connect");
                return;
            }
            if (TcpSocket.Connected)
            {
                UpdateButtonStatus(true, "Connect");
                UpdateStatusText(string.Format("Connected to: {0}\non port: {1}", IPvX, PtNo));
                System.Threading.Thread.Sleep(3000);
                Registry.SaveIPEndPoint(IPvX, PtNo);
                DialogResult = DialogResult.Yes;
                this?.Close(); TcpSocket?.Close();
            }
            else
            {
                UpdateStatusText("The remote host is not available\nplease try again later.");
                UpdateButtonStatus(true, "Connect");
            }
        }

        private void UpdateButtonStatus(bool enabled, string text)
        {
            if (ConnectBtn.InvokeRequired)
            {
                ConnectBtn.Invoke(new Action<bool, string>(UpdateButtonStatus), enabled, text);
            }
            else { ConnectBtn.Enabled = enabled; ConnectBtn.Text = text; }
        }

        private void UpdateStatusText(string status)
        {
            if (StatusBox.InvokeRequired)
            {
                StatusBox.Invoke(new Action<string>(UpdateStatusText), status);
            }
            else { StatusBox.Text = status; }
        }

        private void PtNoBox_TextChanged(object sender, EventArgs e)
        {
            int PortNo;
            int RandomPort = new Random().Next(AppData.DEFAULT.MIN_PORT_NO, AppData.DEFAULT.MAX_PORT_NO);
            PortNo = int.TryParse(PtNoBox.Text.Trim(), out PortNo) ? PortNo : RandomPort;
            PtNoBox.Text = PortNo.ToString();
        }

        private void PtNoBox_Validated(object sender, EventArgs e)
        {
            int Port;
            PtNoBox.Text = (int.TryParse(PtNoBox.Text.Trim(), out Port) && Port >= AppData.DEFAULT.MIN_PORT_NO) ? Port.ToString() : AppData.DEFAULT.MIN_PORT_NO.ToString();
            if (Port < AppData.DEFAULT.MIN_PORT_NO)
            { UpdateStatusText("Port number must be greater or equal than " + PtNoBox.Text); return; }
            PtNoBox.Text = (int.TryParse(PtNoBox.Text.Trim(), out Port) && Port < AppData.DEFAULT.MAX_PORT_NO) ? Port.ToString() : AppData.DEFAULT.MAX_PORT_NO.ToString();
            if (Port > AppData.DEFAULT.MAX_PORT_NO)
            { UpdateStatusText("Port number must be less or equal than " + PtNoBox.Text); return; }
        }
    }
}

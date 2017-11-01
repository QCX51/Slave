using Classes;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Media;
using System.Reflection;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Forms
{
    internal partial class Slave : Form
    {
        internal static System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer()
        {
            Interval = 1000
        };
        public static string AppGUID
        {
            get { try { return Assembly.GetExecutingAssembly().GetCustomAttribute
                      <System.Runtime.InteropServices.GuidAttribute>().Value; }
                catch { return Guid.NewGuid().ToString(); }
            }
        }

        internal Slave()
        {
            this.InitializeComponent();
            // Timer Text Rendering
            TimerTxt.FlatStyle = FlatStyle.Flat;
            TimerTxt.UseCompatibleTextRendering = true;
            TimerTxt.Font = Fonts.Default(54F);
            TimerTxt.BackColor = Color.Black;
            TimerTxt.TextAlign = ContentAlignment.TopCenter;
            // End Rendering
            /*
            Application.ApplicationExit += new EventHandler(OnProcessExit);
            Application.ThreadExit += new EventHandler(OnProcessExit);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(OnUnhandledException);
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
            */
            Registry.ReadRegData();
            timer.Tick += OnTimerTick;
            @TcpClient.OnDataAvailable += OnDataAvailable;
            this.FormClosing += new FormClosingEventHandler(this.FormClosingEvent);
            this.KeyDown += new KeyEventHandler(this.ShowLoginForm);
            Task.Factory.StartNew(new Action(this.StartupThread));
            Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - Width, Screen.PrimaryScreen.WorkingArea.Height - Height);
        }

        private void GetRecvData(string RcevData)
        {
            if (RcevData.Length < 32 || !RcevData.Substring(0, 32).Equals(AppData.PROPERTIES.SERVER_ID_STR))
            { return; }
            string[] sData = RcevData.Substring(32).Split(
                new string[] { "::" }, StringSplitOptions.RemoveEmptyEntries);
            if (sData.Length == 3) { ExecuteCommand(sData[0], sData[1]); }
        }

        private void StartTimer(int Time, string Command)
        {
            if (Command.Equals(AppData.COMMAND.CHECKOUT))
            {
                Invoke(new Action(timer.Stop));
                if (!AppData.PROPERTIES.TimeOver)
                { Task.Factory.StartNew(new Action(() => ToggleDesktop(true))); }
                AppData.PROPERTIES.TimeOver = false;
            }
            else
            {
                AppData.TIME.Time = Time;
                AppData.TIME.Total = AppData.TIME.Time;
                this.Invoke(new Action(timer.Stop));
                AppData.PROPERTIES.Command = Command;
                Task.Factory.StartNew(new Action(() => ToggleDesktop(false)));
                this.Invoke(new Action(timer.Start));
            }
        }

        private void ExecuteCommand(string Command, string Args)
        {
            int Time = int.TryParse(Args, out Time) ? Time : 0;
            switch (Command)
            {
                case AppData.COMMAND.SHUTDOWN:
                    if (Time <= 0) { OnTimeOver(Command); break; }
                    else { StartTimer(Time, Command); }
                    break;
                case AppData.COMMAND.RESTART:
                    if (Time <= 0) { OnTimeOver(Command); break; }
                    else { StartTimer(Time, Command); }
                    break;
                case AppData.COMMAND.SIGNOUT:
                    if (Time <= 0) { OnTimeOver(Command); break; }
                    else { StartTimer(Time, Command); }
                    break;
                case AppData.COMMAND.SLEEP:
                    if (Time <= 0) { OnTimeOver(Command); break; }
                    else { StartTimer(Time, Command); }
                    break;
                case AppData.COMMAND.HIBERNATE:
                    if (Time <= 0) { OnTimeOver(Command); break; }
                    else { StartTimer(Time, Command); }
                    break;
                case AppData.COMMAND.STOPWATCH:
                    if (Time >= 1000)
                    { StartTimer(Time, AppData.COMMAND.TIMER); }
                    else { StartTimer(Time, AppData.COMMAND.STOPWATCH); }
                    break;
                case AppData.COMMAND.TIMER:
                    if (Time < 1000)
                    { StartTimer(Time, AppData.COMMAND.STOPWATCH); }
                    else { StartTimer(Time, AppData.COMMAND.TIMER); }
                    break;
                case AppData.COMMAND.CHECKOUT:
                    StartTimer(Time, Command);
                    break;
                case AppData.COMMAND.UPDATE:
                    if (AppData.PROPERTIES.Command != AppData.COMMAND.STOPWATCH && Time > 0)
                    { AppData.TIME.Time += Time; AppData.TIME.Total += Time; }
                    break;
                case AppData.COMMAND.MSGBOX:
                    ShowMessageBox(Args);
                    break;
                case AppData.COMMAND.BALLOONTIP:
                    ShowBalloonTip(Args);
                    break;
                case AppData.COMMAND.EXECUTE:
                    RunCommand(Args);
                    break;
                case AppData.COMMAND.SECURITY:
                    UpdateKeyData(Args);
                    break;
            }
        }

        private void UpdateKeyData(string KeyData)
        {
            //using (StringReader KeyData = new StringReader(AppData.PROPERTIES.KeyData))
            using (XmlReader xmlReader = XmlReader.Create(KeyData))
            {
                while (xmlReader.Read())
                {
                    switch (xmlReader.NodeType)
                    {
                        case XmlNodeType.Attribute:
                            break;
                        case XmlNodeType.Element:
                            if (xmlReader.Name.Equals("KeyData") && KeyData.Contains("</Data>"))
                            {
                                AppData.SECURITY.UserName = xmlReader.GetAttribute("UserName");
                                AppData.SECURITY.Password = xmlReader.GetAttribute("Password");
                                AppData.SECURITY.UserGUID = xmlReader.GetAttribute("UserGUID");
                                Registry.SaveKeyData(AppData.SECURITY.UserName, AppData.SECURITY.Password, AppData.SECURITY.UserGUID);
                            }
                            break;
                        case XmlNodeType.Text:
                            break;
                        case XmlNodeType.XmlDeclaration:
                            break;
                        case XmlNodeType.ProcessingInstruction:
                            break;
                        case XmlNodeType.Comment:
                            break;
                        case XmlNodeType.EndElement:
                            break;
                    }
                }
            }
            /*string[] Key;
            if (KeyData.Contains("<KeyData>") && KeyData.Contains("</KeyData>"))
            {
                Key = KeyData.Split(new string[] { "<KeyData>", "</KeyData>" }
                , StringSplitOptions.RemoveEmptyEntries);
            }
            else if (KeyData.Contains("<KeyData>"))
            {
                AppData.PROPERTIES.BufferSize += 32;
                return;
            }
            else { return; }
            Key = Key[0].Split(new string[] { "::" }, StringSplitOptions.RemoveEmptyEntries);
            if (KeyData.Length >= 3)
            {
                AppData.SECURITY.UserName = Key[0];
                AppData.SECURITY.Password = Key[1];
                AppData.SECURITY.UserGUID = Key[2];
                Registry.SaveKeyData(Key[0], Key[1], Key[2]);
            }
            */
        }

        private void RunCommand(string Args)
        {
            string FileName = Path.Combine(Environment.SystemDirectory, "cmd.exe");
            string arguments = "/Q /T:0C /C " + Args;
            if (!File.Exists(FileName)) return;
            ProcessStartInfo StartInfo = new ProcessStartInfo();
            StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            StartInfo.Arguments = arguments;
            StartInfo.CreateNoWindow = true;
            StartInfo.ErrorDialog = false;
            StartInfo.FileName = FileName;
            StartInfo.UseShellExecute = false;
            StartInfo.WorkingDirectory = Application.StartupPath;
            Process process;
            try { process = Process.Start(StartInfo); }
            catch { return; }
            finally { Thread.Sleep(5000); }
            if (process == null || process.HasExited) return;
            process.Kill();
            process.Close();
        }

        private void ShowMessageBox(object message)
        {
            MessageBox.Show(
                message is string ? message.ToString() : "Empty Message.", "Message from server",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                (MessageBoxOptions)4096);
        }

        private void ShowBalloonTip(object message)
        {
            if ((message is string) && ((string)message).ToString().Trim().Equals(""))
                return;
            else if (!(message is string)) return;
            using (NotifyIcon notifyIcon = new NotifyIcon())
            {
                notifyIcon.Visible = true;
                notifyIcon.BalloonTipText = (string)message;
                notifyIcon.BalloonTipTitle = "Message from server";
                notifyIcon.Icon = this.Icon;
                notifyIcon.Text = this.Name;
                SystemSounds.Asterisk.Play();
                notifyIcon.ShowBalloonTip(8000);
                Thread.Sleep(8000);
            }
        }

        private void ShowSetup()
        {
            using (Setup setup = new Setup())
            {
                setup.BackgroundImageLayout = ImageLayout.Stretch;
                setup.BackgroundImage = null;
                setup.AllowTransparency = true;
                setup.AutoSize = false;
                setup.ControlBox = false;
                setup.Enabled = true;
                setup.BackColor = Color.DeepSkyBlue;
                setup.ForeColor = Color.Silver;
                setup.FormBorderStyle = FormBorderStyle.None;
                setup.KeyPreview = true;
                setup.MaximizeBox = false;
                setup.MaximumSize = new Size(250, 350);
                setup.MinimizeBox = false;
                setup.MinimumSize = setup.MaximumSize;
                setup.Name = "Setup";
                setup.Icon = global::Slave.Resources.Clock;
                setup.Opacity = 1.0;
                setup.ShowIcon = true;
                setup.ShowInTaskbar = true;
                setup.Text = setup.Name;
                setup.TopMost = true;
                setup.FormClosing += new FormClosingEventHandler(this.FormClosingEvent);
                setup.WindowState = FormWindowState.Normal;
                setup.StartPosition = FormStartPosition.CenterScreen;
                setup.FormClosed += new FormClosedEventHandler(this.SetupFormClosed);
                DialogResult Result = setup.ShowDialog();
            }
        }

        private void SetupFormClosed(object sender, FormClosedEventArgs evt)
        {
            if (((sender is Form) && !((Form)sender).IsDisposed) && ((Form)sender).DialogResult == DialogResult.Yes)
                Task.Factory.StartNew(new Action(() => this.ToggleDesktop(false)));
        }

        private void ShowLogin()
        {
            using (Login login = new Login())
            {
                login.BackgroundImageLayout = ImageLayout.Stretch;
                login.BackgroundImage = null;
                login.AllowTransparency = true;
                login.AutoSize = false;
                login.ControlBox = false;
                login.Enabled = true;
                login.BackColor = Color.DeepSkyBlue;
                login.ForeColor = Color.Silver;
                login.FormBorderStyle = FormBorderStyle.None;
                login.KeyPreview = true;
                login.MaximizeBox = false;
                login.MaximumSize = new Size(250, 350);
                login.MinimizeBox = false;
                login.MinimumSize = login.MaximumSize;
                login.Name = "Login";
                login.Icon = global::Slave.Resources.Clock;
                login.Opacity = 1.0;
                login.ShowIcon = true;
                login.ShowInTaskbar = true;
                login.Text = login.Name;
                login.TopMost = true;
                login.FormClosing += new FormClosingEventHandler(this.FormClosingEvent);
                login.WindowState = FormWindowState.Normal;
                login.StartPosition = FormStartPosition.CenterScreen;
                login.FormClosed += new FormClosedEventHandler(this.OnLoginFormClosed);
                login.BringToFront();
                DialogResult Result = login.ShowDialog();
            }
        }

        private void OnLoginFormClosed(object sender, EventArgs evt)
        {
            if (((sender is Form) && !((Form)sender).IsDisposed) && ((Form)sender).DialogResult == DialogResult.Yes)
                ((Form)sender).Invoke(new Action(ShowSetup));
        }

        private static void Trace(string Output)
        {
            foreach (TraceListener listener in Debug.Listeners)
            { listener.WriteLine(Output); }
        }

        private void FormClosingEvent(object sender, FormClosingEventArgs Event)
        {
            if ((sender is Form) && !((Form)sender).IsDisposed && ((Form)sender).DialogResult.Equals(DialogResult.Yes | DialogResult.No))
            { Event.Cancel = false; } else { Event.Cancel = true; }
            switch (Event.CloseReason)
            {
                case CloseReason.ApplicationExitCall:
                    Slave.Trace("CloseReason: ApplicationExitCall");
                    break;
                case CloseReason.FormOwnerClosing:
                    Slave.Trace("CloseReason: FormOwnerClosing");
                    break;
                case CloseReason.MdiFormClosing:
                    Slave.Trace("CloseReason: MdiFormClosing");
                    break;
                case CloseReason.None:
                    Slave.Trace("CloseReason: None");
                    break;
                case CloseReason.TaskManagerClosing:
                    Slave.Trace("CloseReason: TaskManagerClosing");
                    break;
                case CloseReason.UserClosing:
                    Slave.Trace("CloseReason: UserClosing");
                    break;
                case CloseReason.WindowsShutDown:
                    Slave.Trace("CloseReason: WindowsShutDown");
                    break;
                default:
                    Slave.Trace("CloseReason: Default");
                    break;
            }
        }

        private void ShowLoginForm(object sender, KeyEventArgs Event)
        {
            if (Event.Control && Event.Shift & Event.KeyCode == Keys.L)
                ((Form)sender).Invoke(new Action(ShowLogin));
        }
        
        private void LockScreen()
        {
            using (Form Lock = new Form())
            {
                Lock.BackColor = Color.Black;
                //Lock.TransparencyKey = Lock.BackColor;
                Lock.BackgroundImageLayout = ImageLayout.Tile;
                Lock.BackgroundImage = global::Slave.Resources.Screen;
                Lock.AllowTransparency = true;
                Lock.AutoSize = false;
                Lock.ControlBox = false;
                Lock.Enabled = true;
                Lock.ForeColor = Color.DodgerBlue;
                Lock.FormBorderStyle = FormBorderStyle.None;
                Lock.KeyPreview = true;
                Lock.MaximizeBox = false;
                Lock.MaximumSize = Screen.PrimaryScreen.Bounds.Size;
                Lock.MinimizeBox = false;
                Lock.MinimumSize = Lock.MaximumSize;
                Lock.Name = "Lock";
                Lock.Icon = global::Slave.Resources.Lock;
                Lock.Opacity = 1.0;
                Lock.ShowIcon = true;
                Lock.ShowInTaskbar = true;
                Lock.Text = Lock.Name;
                Lock.TopMost = true;
                Lock.FormClosing += new FormClosingEventHandler(FormClosingEvent);
                Lock.WindowState = FormWindowState.Maximized;
                Lock.StartPosition = FormStartPosition.CenterScreen;
                Lock.KeyDown += new KeyEventHandler(ShowLoginForm);
                using (Label label = new Label())
                using (Panel panel = new Panel())
                {
                    panel.BackColor = Color.Transparent;
                    panel.BackgroundImage = global::Slave.Resources.Locked;
                    panel.BackgroundImageLayout = ImageLayout.Stretch;
                    panel.Size = new Size(160, 160);
                    panel.Location = new Point((Lock.Width / 2 - panel.Width / 2), (Lock.Height / 2));
                    panel.MouseUp += Panel_MouseUp;
                    panel.MouseDown += Panel_MouseDown;
                    panel.Cursor = Cursors.Hand;
                    label.Text = "Desbloquear";
                    label.AutoSize = false;
                    label.Cursor = Cursors.Hand;
                    label.MouseUp += Panel_MouseUp;
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    label.Size = new Size(200, 34);
                    label.Font = new Font(SystemFonts.MessageBoxFont.FontFamily, 14F, FontStyle.Bold, GraphicsUnit.Point);
                    label.BackColor = Color.Black;
                    label.BorderStyle = BorderStyle.None;
                    label.ForeColor = Color.White;
                    label.Location = new Point(Lock.Width / 2 - label.Width / 2, panel.Location.Y + panel.Height);
                    Lock.Controls.Add(label);
                    Lock.Controls.Add(panel);
                    DialogResult Result = Lock.ShowDialog();
                }
                GC.Collect();
            }
        }
        private void Panel_MouseUp(object sender, MouseEventArgs e)
        {
            if ((sender is Panel) && !((Panel)sender).IsDisposed)
            {
                ((Panel)sender).BackgroundImage = global::Slave.Resources.Locked;
                Invoke(new Action(() => ExecuteCommand(AppData.COMMAND.STOPWATCH, "0")));
            }
            else if (sender is Label && !((Label)sender).IsDisposed)
            {
                Invoke(new Action(() => ExecuteCommand(AppData.COMMAND.STOPWATCH, "0")));
            }
        }

        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is Panel && !((Panel)sender).IsDisposed)
            { ((Panel)sender).BackgroundImage = global::Slave.Resources.Unlocked; }
        }

        private void StartupThread()
        {
            @TcpClient.Connect(AppData.ENDPOINT.IPvX, AppData.ENDPOINT.PtNo);
            if (AppData.TIME.Time > 0)
            {
                this.Invoke(new Action(timer.Start));
                Task.Factory.StartNew(new Action(() => this.ToggleDesktop(false)));
            }
            else
                Task.Factory.StartNew(new Action(() => this.ToggleDesktop(true)));
        }

        private void OnDataAvailable(object sender, byte[] e)
        {
            GetRecvData(Encoding.ASCII.GetString(e));
        }

        private string DisplayTimeFormat(int Time)
        {
            decimal TickH = Math.Floor(Convert.ToDecimal(Time / 3600000 % 24));
            decimal TickM = Math.Floor(Convert.ToDecimal(Time / 60000 % 60));
            decimal TickS = Math.Floor(Convert.ToDecimal(Time / 1000 % 60));
            string TimeH = TickH < 10 ? "0" + TickH : TickH.ToString();
            string TimeM = TickM < 10 ? "0" + TickM : TickM.ToString();
            string TimeS = TickS < 10 ? "0" + TickS : TickS.ToString();
            if (TickH + TickM + TickS == decimal.Zero) { return "--:--:--"; }
            return TimeH + ":" + TimeM + ":" + TimeS;
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            if (AppData.PROPERTIES.Command != AppData.COMMAND.STOPWATCH)
            {
                AppData.TIME.Time = AppData.TIME.Time > 0 ? AppData.TIME.Time -= 1000 : 0;
                AppData.TIME.Used = AppData.TIME.Total - AppData.TIME.Time;
                AppData.TIME.Left = AppData.TIME.Time;
                AppData.TIME.Time = AppData.TIME.Time > 86400000 ? 86400000 : AppData.TIME.Time;
                if (AppData.TIME.Time <= 0)
                { OnTimeOver(AppData.PROPERTIES.Command); }
            }
            else
            {
                AppData.TIME.Time = AppData.TIME.Time < 86400000 ? AppData.TIME.Time += 1000 : 86400000;
                AppData.TIME.Used = AppData.TIME.Time;
                AppData.TIME.Left = 0;
            }
            Registry.SaveElapsedTime(Convert.ToString(AppData.TIME.Time));
            TimerTxt.Invoke(new Action(() => TimerTxt.Text = DisplayTimeFormat(AppData.TIME.Time)));
        }

        private void OnTimeOver(string Command)
        {
            switch (Command)
            {
                case AppData.COMMAND.SIGNOUT:
                    this.Invoke(new Action(timer.Stop));
                    SystemSounds.Beep.Play();
                    ExitWinEx.LogOff(true);
                    break;
                case AppData.COMMAND.SHUTDOWN:
                    this.Invoke(new Action(timer.Stop));
                    SystemSounds.Beep.Play();
                    ExitWinEx.Shutdown(true);
                    break;
                case AppData.COMMAND.RESTART:
                    this.Invoke(new Action(timer.Stop));
                    SystemSounds.Beep.Play();
                    ExitWinEx.Restart(true);
                    break;
                case AppData.COMMAND.SLEEP:
                    this.Invoke(new Action(timer.Stop));
                    SystemSounds.Beep.Play();
                    if (AppData.TIME.Time <= 0)
                    { Task.Factory.StartNew(new Action(() => ToggleDesktop(true))); }
                    ExitWinEx.Sleep(true);
                    break;
                case AppData.COMMAND.HIBERNATE:
                    this.Invoke(new Action(timer.Stop));
                    SystemSounds.Beep.Play();
                    if (AppData.TIME.Time <= 0)
                    { Task.Factory.StartNew(new Action(() => ToggleDesktop(true))); }
                    ExitWinEx.Hibernate(true);
                    break;
                default:
                    this.Invoke(new Action(timer.Stop));
                    SystemSounds.Beep.Play();
                    AppData.PROPERTIES.TimeOver = true;
                    Task.Factory.StartNew(new Action(() => ToggleDesktop(true)));
                    break;
            }
        }

        private void InvokeForm(Form OpenForm)
        {
            if (!OpenForm.IsDisposed && OpenForm.InvokeRequired)
            {
                OpenForm.Invoke(new Action(() => InvokeForm(OpenForm)));
            }
            else if (!OpenForm.IsDisposed)
            {
                OpenForm.DialogResult = DialogResult.No;
                OpenForm?.Close();
            }
        }

        private void CloseOpenForms()
        {
            FormCollection OpenForms = Application.OpenForms;
            for (int Index = 0; Index < OpenForms.Count; Index++)
            {
                if (!OpenForms[Index].IsDisposed && OpenForms[Index].Name != Name)
                { InvokeForm(OpenForms[Index]); }
            }
        }
        
        private void ToggleDesktop(bool SecureDesktop)
        {
            if (SecureDesktop)
            {
                Desktop.SwitchDesktop(Desktop.NewDesktop);
                Desktop.SetThreadDesktop(Desktop.NewDesktop);
                this.Invoke(new Action(this.Hide));
                CloseOpenForms();
                LockScreen();
            }
            else
            {
                Desktop.SwitchDesktop(Desktop.OldDesktop);
                Desktop.SetThreadDesktop(Desktop.OldDesktop);
                this.Invoke(new Action(this.Show));
                CloseOpenForms();
            }
        }

        [PrincipalPermission(SecurityAction.Demand, Role = @"BUILTIN\Administrators")]
        public static void AdministratorTask()
        {
        }

        private static bool IsAdminRole
        {
            get
            {
                using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
                { return new WindowsPrincipal(identity).IsInRole(WindowsBuiltInRole.Administrator); }
            }
        }

        internal static class Program
        {
            private static bool IsNotRunning;
            [STAThread]
            internal static void Main(string[] Args)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(true);
                using (Mutex mutex = new Mutex(true, AppGUID, out IsNotRunning))
                {
                    string ExecutablePath = Application.ExecutablePath.Replace('/', '\\').ToLower();
                    if (IsAdminRole && Args.Length > 0 && Args[0].Equals(AppGUID) && IsNotRunning)
                    { Taskschd.CreateTask(AppGUID, ExecutablePath, Taskschd.TaskGUID, true, true, 0, 0); }
                    if (IsAdminRole && Args.Length > 0 && Args[0].Equals(Taskschd.TaskGUID) && IsNotRunning)
                    { Application.Run(new Slave()); }
                    if (!IsAdminRole && IsNotRunning && !Taskschd.TaskExists(AppGUID, ExecutablePath, true))
                    { ExecuteUAC(); }
                }
            }
            
            private static bool ExecuteUAC()
            {
                using (Process process = new Process())
                {
                    ProcessStartInfo StartInfo = new ProcessStartInfo();
                    StartInfo.Verb = "RunAs";
                    StartInfo.UseShellExecute = true;
                    StartInfo.Arguments = AppGUID;
                    StartInfo.FileName = Application.ExecutablePath;
                    process.StartInfo = StartInfo;
                    try { return process.Start(); }
                    catch { return false; }
                }
            }
        }
    }
}
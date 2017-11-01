using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace Classes
{
    /// <summary>
    /// Copyright (C) 2017 Alain Eus. Rivera
    /// </summary>
    internal static class @TcpClient
    {
        #region Global Vars
        private static bool isConnecting;
        internal static bool isConnected;
        private static Socket TcpSocket;
        #endregion
        #region Global Events
        internal static event EventHandler<byte[]> OnDataAvailable;
        internal static event EventHandler<Socket> OnSocketClosed;
        #endregion
        /// <summary>
        /// Connect to remote server
        /// </summary>
        /// <param name="IPvX">Remote IPv4|IPv6 Address</param>
        /// <param name="PtNo">Remote port Number</param>
        internal static void Connect(string IPvX, int PtNo)
        {
            if (!isConnecting) { isConnecting = true; BeginConnect(IPvX, PtNo); }
            else
            {
                AppData.ENDPOINT.IPvX = IPvX;
                AppData.ENDPOINT.PtNo = PtNo;
                TcpSocket?.Close();
                return;
            }
        }

        private static void Reconnect()
        {
            
            Thread.Sleep(5000);
            if (isConnecting) { isConnecting = false; }
            Connect(AppData.ENDPOINT.IPvX, AppData.ENDPOINT.PtNo);
        }
        

        private static void BeginConnect(string IPvX, int PtNo)
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            { IPvX = AppData.DEFAULT.IPV4; }
            TcpSocket = new Socket(SocketType.Stream, ProtocolType.Tcp)
            { ExclusiveAddressUse = false, ReceiveTimeout = 3000, SendTimeout = 3000 };
            AsyncCallback AsCallback = new AsyncCallback(EndConnect);
            try { TcpSocket.BeginConnect(IPvX, PtNo, AsCallback, TcpSocket); }
            catch (Exception ex) { Trace("BeginConnect:" + ex.Message, TcpSocket); Reconnect(); }
            finally { TcpSocket = null; AsCallback = null; }
        }

        private static void EndConnect(IAsyncResult IAsResult)
        {
            
            Socket TcpSocket = IAsResult.AsyncState as Socket;
            if (TcpSocket?.Connected != true) { Reconnect(); return; }
            try { TcpSocket.EndConnect(IAsResult); }
            catch (Exception ex) { Trace("EndConnect:" + ex.Message, TcpSocket); return; }
            if (!isConnected) { isConnected = true; }
            WaitCallback waitCallback = new WaitCallback(BeginReceive);
            ThreadPool.QueueUserWorkItem(waitCallback, TcpSocket);
            waitCallback = new WaitCallback(BeginSend);
            ThreadPool.QueueUserWorkItem(waitCallback, TcpSocket);
        }

        private static void BeginReceive(object socket)
        {
            Socket TcpSocket = socket as Socket;
            if (TcpSocket != null && !TcpSocket.Connected) return;
            byte[] buffer = new byte[AppData.PROPERTIES.BufferSize];
            object[] Objects = new object[2] { buffer, TcpSocket };
            AsyncCallback callback = new AsyncCallback(EndReceive);
            try { TcpSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, callback, Objects); }
            catch (Exception ex) { Trace("BeginReceive:" + ex.Message, TcpSocket); }
            finally { buffer = null; Objects = null; }
        }

        private static void EndReceive(IAsyncResult IAsResult)
        {
            object[] Objects = IAsResult.AsyncState as object[];
            Socket TcpSocket = Objects[1] as Socket;
            byte[] Bytes = Objects[0] as byte[];
            if (Convert.ToInt32(Bytes.GetValue(0)) <= 0) { return; }
            try { TcpSocket.EndReceive(IAsResult); BeginReceive(TcpSocket); }
            catch (Exception ex) { Trace("EndReceive:" + ex.Message, TcpSocket); return; }
            if (OnDataAvailable != null) { OnDataAvailable.Invoke(TcpSocket, Bytes); }
        }

        private static void BeginSend(object socket)
        {
            Socket TcpSocket = socket as Socket;
            if (TcpSocket != null && !TcpSocket.Connected) return;
            byte[] buffer = Encoding.ASCII.GetBytes(AppData.PROPERTIES.CLIENT_ID_STR + GetUserData());
            AsyncCallback callback = new AsyncCallback(EndSend);
            try { TcpSocket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, callback, TcpSocket); }
            catch (Exception ex) { Trace("BeginSend:" + ex.Message, TcpSocket); }
            finally { TcpSocket = null; buffer = null; }
        }

        private static void EndSend(IAsyncResult IAsResult)
        {
            Socket TcpSocket = IAsResult.AsyncState as Socket;
            try { TcpSocket.EndSend(IAsResult); Thread.Sleep(1000); BeginSend(TcpSocket); }
            catch (Exception ex) { Trace("EndSend:" + ex.Message, TcpSocket); }
            finally { TcpSocket = null; GC.Collect(); }
        }

        private static string GetUserData()
        {
            return Network.Username + "::" + Network.Hostname + "::" + Network.IPv4 + "::"
                + Network.PhysicalAddress + "::" + Convert.ToString(AppData.TIME.Used) + "::"
                + Convert.ToString(AppData.TIME.Left) + "::" + AppData.PROPERTIES.TimeOver.ToString()
                + "::" + Forms.Slave.timer.Enabled.ToString() + "::";
        }

        private static void Trace(string LogText, Socket TcpSocket)
        {
            OnSocketClosed?.Invoke(LogText, TcpSocket);
            foreach (TraceListener debug in Debug.Listeners)
            { debug.WriteLine(LogText); }
            if (isConnected) { isConnected = false; Reconnect(); }
        }
    }
}

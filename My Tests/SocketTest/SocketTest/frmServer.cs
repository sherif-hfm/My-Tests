using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketTest
{
    public partial class frmServer : Form
    {
        private Socket client;
        public ManualResetEvent allDone = new ManualResetEvent(false);
        private long msgseq = 0;
        public frmServer()
        {
            InitializeComponent();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            Thread connect = new Thread(BeginAccept);
            connect.Start();
        }
        private void BeginAccept()
        {
            //IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostEntry(IPAddress.Any));
            //IPAddress ipAddress = ipHostInfo.AddressList[0];

            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, 11000);

            // Create a TCP/IP socket.
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and listen for incoming connections.
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(100);

                while (true)
                {
                    // Set the event to nonsignaled state.
                    allDone.Reset();

                // Start an asynchronous socket to listen for connections.
                Log("Waiting for a connection...");
                listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);

                // Wait until a connection is made before continuing.
                allDone.WaitOne();
                }

            }
            catch (Exception ex)
            {
                Log(ex.ToString());
            }
        }
        public  void AcceptCallback(IAsyncResult ar)
        {
            // Signal the main thread to continue.
            allDone.Set();
            // Get the socket that handles the client request.
            Socket listener = (Socket)ar.AsyncState;
            client = listener.EndAccept(ar);
            Log("Accept connection " + client.LocalEndPoint.ToString());
            // Create the state object.
            StateObject state = new StateObject();
            state.workSocket = client;
            Log("Begin Receive");
            client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
            //listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
        }
        public  void ReadCallback(IAsyncResult ar)
        {
            try
            {
                String content = String.Empty;
                // Retrieve the state object and the handler socket
                // from the asynchronous state object.
                StateObject state = (StateObject)ar.AsyncState;
                client = state.workSocket;
                if (client != null)
                {
                    if (client.Connected ==true)
                    {
                        // Read data from the client socket. 
                        int bytesRead = client.EndReceive(ar);

                        if (bytesRead > 0)
                        {
                            state.sb.Clear();
                            // There  might be more data, so store the data received so far.
                            state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
                            // Check for end-of-file tag. If it is not there, read 
                            // more data.
                            content = state.sb.ToString();
                            Log2(string.Format("Read {0} bytes from socket. \n Data : {1}", content.Length, content));
                            state.sb.Clear();
                            Log("Begin Receive");
                            client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
                        } 
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }
        private void Log(string txt)
        {
            if (!InvokeRequired)
            {
                //txtLog.Text = DateTime.Now.ToLongTimeString() + "  " + txt + Environment.NewLine + txtLog.Text;
                txtLog.Text = DateTime.Now.ToLongTimeString() + "  " + txt;
            }
            else
            {
                BeginInvoke(new Action<string>(Log), txt);
            }
        }
        private void Log2(string txt)
        {
            if (!InvokeRequired)
            {
                //txtLog2.Text = DateTime.Now.ToLongTimeString() + "  " + txt + Environment.NewLine + txtLog2.Text;
                txtLog2.Text = DateTime.Now.ToLongTimeString() + "  " + txt;
            }
            else
            {
                Invoke(new Action<string>(Log2), txt);
            }
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            byte[] byteData = Encoding.ASCII.GetBytes("Hi guest " + msgseq.ToString());
            client.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), client);
            msgseq++;
        }
        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                client = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.
                int bytesSent = client.EndSend(ar);
                Log(string.Format("Sent {0} bytes to Client.", bytesSent));

                // Signal that all bytes have been sent.
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        private void btnSendTimer_Click(object sender, EventArgs e)
        {
            timSend.Enabled = true;
        }
        private void timSend_Tick(object sender, EventArgs e)
        {
            byte[] byteData = Encoding.ASCII.GetBytes("Hi guest " + msgseq.ToString());
            client.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), client);
            msgseq++;
        }
        private void btnStopTimer_Click(object sender, EventArgs e)
        {
            timSend.Enabled = false;

        }
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            client.Close();
            //client.Disconnect(false);
            //client.Dispose();
            client = null;
        }
    }
}

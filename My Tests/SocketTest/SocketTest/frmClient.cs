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
    public partial class frmClient : Form
    {
        private Socket client;
        private ManualResetEvent connectDone = new ManualResetEvent(false);
        private long msgseq = 0;

        public frmClient()
        {
            InitializeComponent();
        }

        private void frmClient_Load(object sender, EventArgs e)
        {
           
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);

            // Create a TCP/IP socket.
            Socket mainClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // Connect to the remote endpoint.
            Log("Start Connection To Host" );
            mainClient.BeginConnect(remoteEP, new AsyncCallback(ConnectCallback), mainClient);
        }

        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                client = (Socket)ar.AsyncState;
                
                // Complete the connection.
                client.EndConnect(ar);
                Log(string.Format("Socket connected to {0}", client.RemoteEndPoint.ToString()));

                StateObject state = new StateObject();
                state.workSocket = client;
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
            }
            catch (Exception ex)
            {
                Log(ex.Message);
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
                Invoke(new Action<string>(Log), txt);
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
            byte[] byteData = Encoding.ASCII.GetBytes("Hi Host " + msgseq.ToString());
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
                Log(string.Format("Sent {0} bytes to server.", bytesSent));

                // Signal that all bytes have been sent.
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void ReadCallback(IAsyncResult ar)
        {
            try
            {
                String content = String.Empty;
                // Retrieve the state object and the handler socket
                // from the asynchronous state object.
                StateObject state = (StateObject)ar.AsyncState;
                client = state.workSocket;

                // Read data from the client socket. 
                if (client.Connected == true)
                {
                    int bytesRead = client.EndReceive(ar);

                    if (bytesRead > 0)
                    {
                        state.sb.Clear();
                        // There  might be more data, so store the data received so far.
                        state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
                        // Check for end-of-file tag. If it is not there, read 
                        // more data.
                        content = state.sb.ToString();
                        // Not all data received. Get more.
                        Log2(string.Format("Read {0} bytes from socket. \n Data : {1}", content.Length, content));
                        state.sb.Clear();
                        Log("Begin Receive");
                        client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnSendTimer_Click(object sender, EventArgs e)
        {
            timSend.Enabled = true;
        }

        private void timSend_Tick(object sender, EventArgs e)
        {
            try
            {
                if (client != null)
                {
                    if (client.Connected == true)
                    {
                        byte[] byteData = Encoding.ASCII.GetBytes("Hi Host " + msgseq.ToString());
                        client.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), client);
                        msgseq++;
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btnStopTimer_Click(object sender, EventArgs e)
        {
            timSend.Enabled = false;
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            client.Close();
            client = null;
        }


    }
}

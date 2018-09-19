using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace OpenMsWordServer
{
    class Program
    {

        static private string guid = "258EAFA5-E914-47DA-95CA-C5AB0DC85B11";
        public static ManualResetEvent allDone = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            StartListening();
            Console.ReadKey();
        }

        private static void StartListening()
        {
            using (Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP))
            {
                listener.Bind(new IPEndPoint(IPAddress.Any, 8080));
                listener.Listen(128);

                while (true)
                {
                    // Set the event to nonsignaled state.
                    allDone.Reset();

                    // Start an asynchronous socket to listen for connections.
                    Console.WriteLine("Waiting for a connection...");
                    listener.BeginAccept(new AsyncCallback(OnAccept), listener);

                    // Wait until a connection is made before continuing.
                    allDone.WaitOne();
                }
            }
        }

        private static void OnAccept(IAsyncResult ar)
        {

            allDone.Set();

            // Get the socket that handles the client request.
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            // Create the state object.
            StateObject state = new StateObject();
            state.workSocket = handler;


            byte[] buffer = new byte[1024];
            try
            {

                var i = handler.Receive(buffer);
                var headerStr = System.Text.Encoding.UTF8.GetString(buffer);


                // Get Key
                var key = new Regex("Sec-WebSocket-Key: (.*)").Match(headerStr).Groups[1].Value.Trim();

                // Generate Key
                var acceptKey = AcceptKey(ref key);

                var newLine = Environment.NewLine;

                var response = "HTTP/1.1 101 Switching Protocols" + newLine
                     + "Upgrade: websocket" + newLine
                     + "Connection: Upgrade" + newLine
                     + "Sec-WebSocket-Accept: " + acceptKey + newLine + newLine;

                // Send Handshaking
                handler.Send(System.Text.Encoding.UTF8.GetBytes(response));

                byte[] receiveBuffer = new byte[1024];
                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);

                //// once the message is received decode it in different formats
                //Console.WriteLine(DecodeMessage(receiveBuffer));

                //Console.WriteLine("send data to client");
                //Thread.Sleep(3000);

                //var sendData = EncodeMessage("Hello Client");
                //client.Send(sendData);

                //Thread.Sleep(10000);//wait for message to be send
            }
            catch (SocketException exception)
            {
                //throw exception;
            }

        }

        public static void ReadCallback(IAsyncResult ar)
        {
            String content = String.Empty;

            // Retrieve the state object and the handler socket
            // from the asynchronous state object.
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;

            // Read data from the client socket. 
            int bytesRead = handler.EndReceive(ar);

            string msg = DecodeMessage(state.buffer);
            if(msg=="OpenMsWordNew")
            {
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = @"D:\DocFlowFiles\DocTemp.docx";
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                    process.Start();
                    process.WaitForExit();
                }
            }

            Thread.Sleep(1000);


            byte[] fileData = File.ReadAllBytes(@"D:\DocFlowFiles\DocTemp.docx");
            
            FileConvertSrvWCF.FileConvertSrvClient srv = new FileConvertSrvWCF.FileConvertSrvClient();
            var imgData = srv.DocToImageConvert(fileData);
            File.WriteAllBytes(@"D:\DocFlowFiles\session.jpg", imgData);

            var sendData = EncodeMessage("MsWordClosed");
            handler.Send(sendData);

        }

        private static byte[] EncodeMessage(string _dataStr)
        {
            byte[] data = System.Text.Encoding.UTF8.GetBytes(_dataStr);
            byte[] result = new byte[data.Length + 2];
            Array.Copy(data, 0, result, 2, data.Length);
            result[0] = 129;
            result[1] = (byte)data.Length;

            return result;

        }

        private static string DecodeMessage(byte[] _data)
        {
            string result = "";

            int msgLen = (int)_data[1] - 128;
            Byte[] decoded = new Byte[msgLen];
            Byte[] encoded = new byte[msgLen];
            Array.Copy(_data, 6, encoded, 0, msgLen);
            byte[] key = new byte[] { _data[2], _data[3], _data[4], _data[5] };

            for (int i = 0; i < msgLen; i++)
            {
                decoded[i] = (Byte)(encoded[i] ^ key[i % 4]);
            }
            result = System.Text.Encoding.UTF8.GetString(decoded);
            return result;
        }

        private static string AcceptKey(ref string key)
        {
            string longKey = key + guid;
            byte[] hashBytes = ComputeHash(longKey);
            return Convert.ToBase64String(hashBytes);
        }

        static SHA1 sha1 = SHA1CryptoServiceProvider.Create();
        private static byte[] ComputeHash(string str)
        {
            return sha1.ComputeHash(System.Text.Encoding.ASCII.GetBytes(str));
        }
    }

    public class StateObject
    {
        // Client  socket.
        public Socket workSocket = null;
        // Size of receive buffer.
        public const int BufferSize = 1024;
        // Receive buffer.
        public byte[] buffer = new byte[BufferSize];
    }
}

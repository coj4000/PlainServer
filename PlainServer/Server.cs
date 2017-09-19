using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PlainServer
{
    class Server
    {

        public void Start()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, 10001);
            server.Start();
            while (true)
            {
                TcpClient socket = server.AcceptTcpClient();
                Task.Run(() =>
                {
                    TcpClient localSocket = socket;
                    DoClient(localSocket);

                });

            }
        }
        private static void DoClient(TcpClient socket)
        {
            using (NetworkStream ns = socket.GetStream())
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {
                string line = sr.ReadLine();
                Console.WriteLine($"{line}");
                if (line != String.Empty)
                {
                    sw.WriteLine("Sendt");
                    sw.Flush();
                }
                Console.ReadLine();
            }
        }
    }
}

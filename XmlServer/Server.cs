using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ModelLib;

namespace XmlServer
{
    class Server
    {

        public void Start()
        {
            TcpListener server = new TcpListener(IPAddress.Any, 10002);
            server.Start();
            while (true)
            {
                TcpClient socket = server.AcceptTcpClient();
                Console.WriteLine("new client");
                Task.Run(() =>
                {
                    TcpClient localSocket = socket;
                    Console.WriteLine("Local socket");
                    DoClient(localSocket);

                });

            }
        }
        private void DoClient(TcpClient socket)
        {
            
            using (NetworkStream ns = socket.GetStream())
            using (StreamReader sr = new StreamReader(ns))
            //using (StreamWriter sw = new StreamWriter(ns))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Car));
                //string line = sr.ReadLine();
                //Console.WriteLine($"{line}");
                Car car = new Car();
                car = (Car)serializer.Deserialize(sr);
                Console.WriteLine(car.ToString());
                //if (line != String.Empty)
                //{
                //    sw.WriteLine("Sendt");
                //    sw.Flush();
                //}
                Console.ReadLine();
            }
        }
    }
}

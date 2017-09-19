using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ModelLib;

namespace XmlClient
{
    class Client
    {
        public void Start()
        {

            using (TcpClient socket = new TcpClient("localhost", 10002))
            using (NetworkStream ns = socket.GetStream())
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns) { AutoFlush = true })
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Car));
                Car car = new Car();
                car.model = "tesla";
                car.color = "red";
                car.registrationnr = "EL23400";
                serializer.Serialize(sw, car);
                sw.Flush();
                //string line = sr.ReadLine();
                Console.WriteLine($"{car.ToString()}");
                Console.ReadLine();
            }

        }
    }
}

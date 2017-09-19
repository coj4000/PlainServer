using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ModelLib;

namespace PlainClient
{
    class Client
    {
        public void Start()
        {

            using (TcpClient socket = new TcpClient("localhost", 10001))
            using (NetworkStream ns = socket.GetStream())
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns) { AutoFlush = true })
            { 

            Car car = new Car();
            car.model = "tesla";
            car.color = "red";
            car.registrationnr = "EL23400";
            sw.WriteLine(car.ToString());
                sw.Flush();
                string line = sr.ReadLine();
                Console.WriteLine($"{line}");
                Console.ReadLine();
            }

        }
    }
}

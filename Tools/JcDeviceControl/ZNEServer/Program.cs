using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace ZNEServer
{
    class Program
    {
        static void Main(string[] args)
        { 
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc), 5000);
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc), 5001);
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc), 5002);
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc), 5003);
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc), 5004);
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc), 5005);
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc), 5006);
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc), 5007);
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc), 5008);

            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc), 3003);
            while (true) ;
        }

        static void ThreadProc(object obj)
        {
            int port = (int)obj;
            TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
            Console.WriteLine("Connected! 127.0.0.1:"+port.ToString());
            // Start listening for client requests.
            server.Start(1);

            // Buffer for reading data
            Byte[] bytes = new Byte[256];
            // Enter the listening loop.
            while (true)
            {
                Console.WriteLine("Waiting for a connection... ");

                // Perform a blocking call to accept requests.
                // You could also user server.AcceptSocket() here.
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Connected! " + port.ToString());
                string infoPrint = "";
                bool packok = false; 

                while (true)
                {
                    try
                    {
                        //Console.Clear();
                        //Console.WriteLine(port.ToString() + " : Read Receive");              

                        if (port != 3003)
                        {
                            infoPrint = port.ToString() + " : ";

                            client.GetStream().Read(bytes, 0, 12);
                            client.GetStream().Write(bytes, 0, 12);

                            byte check = 0;
                            for (int i = 1; i < 11; i++)
                            {
                                check ^= bytes[i];
                            }

                            packok = (check == bytes[11]);

                            for (int i = 0; i < 12; i++)
                            {
                                infoPrint += bytes[i].ToString("X02") + " ";
                            }

                            infoPrint += "  " + packok.ToString() +" "+ System.DateTime.Now.ToLocalTime();
                        }
                        else
                        {
                            //"AT+MODE=0\r\nAT+LOGIN=88888\r\nAT+RESET=88888\r\n"
                            client.GetStream().Read(bytes, 0, 256);
                            client.Client.Close();
                            Console.WriteLine(Encoding.ASCII.GetString(bytes).Trim());
                            Thread.Sleep(200);
                        }
                        
                        Console.WriteLine(infoPrint);
                    }
                    catch
                    {                        
                        Console.WriteLine("Disconnect : "+port.ToString());
                        break;
                    }
                }
            }
        }
    }
}

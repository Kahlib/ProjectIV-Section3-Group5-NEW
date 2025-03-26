using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    class Server_Manager
    {
        private TcpListener server;
        private PacketHandler packetHandler;

        public Server_Manager()
        {
            // given ip address and port number
            server = new TcpListener(IPAddress.Parse("127.0.0.1"), 27000);
            packetHandler = new PacketHandler();
        }

        public void StartServer()
        {
            server.Start();
            Console.WriteLine("Server started on 127.0.0.1:27000");

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Client connected");
                Task.Run(() => HandleClient(client)); // to generate new thread and accept other clients 
            }
        }

        private void HandleClient(TcpClient client)
        {
            try
            {
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[2048];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);

                string receivedBase64 = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine($"Received packet (base64): {receivedBase64}");

                object parsedObj = packetHandler.ParsePacket(receivedBase64);

                if (parsedObj != null)
                {
                    Console.WriteLine("Packet parsed successfully");
                    Console.WriteLine(parsedObj.ToString());
                }

                // Echo back acknowledgment
                string ack = "Transaction received";
                string responsePacket = packetHandler.CreatePacket(ack);
                byte[] responseData = Encoding.UTF8.GetBytes(responsePacket);
                stream.Write(responseData, 0, responseData.Length);
                Console.WriteLine("Acknowledgment sent");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error handling client: " + ex.Message);
            }
        }
    }
}

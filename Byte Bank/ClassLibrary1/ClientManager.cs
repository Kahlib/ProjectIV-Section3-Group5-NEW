using System.Net.Sockets;
using System.Text;


namespace ClassLibrary1
{
    public class ClientManager
    {
        private TcpClient client;
        private NetworkStream stream;
        private string serverIP = "127.0.0.1";
        private int serverPort = 27000;
        private PacketHandler packetHandler;

        public ClientManager()
        {
            packetHandler = new PacketHandler();
        }

        public bool ConnectToServer()
        {
            // Tests to see if connection failed, if it does, print the exception message
            try {
                client = new TcpClient(serverIP, serverPort);
                stream = client.GetStream();
                Console.WriteLine("Connected to server");
                return true;
            }

            catch(Exception ex) {
                Console.WriteLine("Connection Failed: " + ex.Message);
                return false;
            }
        }

        public void SendData(string message)
        {
            // ensure that the stream is not null
            if (stream != null)
            {
                string packet = packetHandler.CreatePacket(message);
                byte[] data = Encoding.UTF8.GetBytes(packet);
                stream.Write(data, 0, data.Length);
                Console.WriteLine("Data sent");
            }
            // exit if stream is null
            else
            {
                Console.WriteLine("Stream is Null");
                return;
            }
        }

        public object ReceiveData()
        {
            // receive a byte array from the server and return its converted string
            if (stream != null)
            {
                byte[] data = new byte[1024];
                int bytesRead = stream.Read(data, 0, data.Length);
                string packet = Encoding.UTF8.GetString(data);
                return packetHandler.ParsePacket(packet);
            }
            else
            {
                return null;
            }
        }

        // disconnect from server
        void Disconnect()
        {
            stream.Close();
            client.Close();
        }
    }
}

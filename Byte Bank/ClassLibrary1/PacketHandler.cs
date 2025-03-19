using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class PacketHandler
    {
        private int PacketType;
        private int UserID;
        private double Amount;
        private byte[] Data;
        
        public string CreatePacket(object data)
        {
            // create a packet based on json data object
            try
            {
                string jsonData = JsonSerializer.Serialize(data);
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(jsonData));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error creating packet: " + ex.Message);
                return string.Empty;
            }
        }

        public object ParsePacket(string packetData)
        {
            // create a json data object based on a packet
            try
            {
                string jsonData = Encoding.UTF8.GetString(Convert.FromBase64String(packetData));
                return JsonSerializer.Deserialize<object>(jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error parsing packet: " + ex.Message);
                return null;
            }
        }
    }
}

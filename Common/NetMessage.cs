using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Common
{
    public class NetMessage
    {
        public byte[] Data { get; set; }

        public static object Deserialize(byte[] data)
        {
            return Deserialize(new NetMessage { Data = data });
        }

        public static NetMessage Serialize(object anySerializableObject)
        {
            using (var memoryStream = new MemoryStream())
            {
                new BinaryFormatter().Serialize(memoryStream, anySerializableObject);
                return new NetMessage { Data = memoryStream.ToArray() };
            }
        }

        public static object Deserialize(NetMessage message)
        {
            using (var memoryStream = new MemoryStream(message.Data))
            {
                return (new BinaryFormatter()).Deserialize(memoryStream);
            }
        }
    }
}

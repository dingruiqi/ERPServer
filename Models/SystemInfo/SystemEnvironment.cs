using System.Collections.Generic;
using System.IO;

namespace ERPServer.Models.SystemInfo
{
    public class SystemEnvironment
    {
        public List<string> MACAddress { get; set; }

        public string BoardID { get; set; }

        public byte[] Serialize()
        {
            byte[] byteArray;
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter serializer = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            System.IO.MemoryStream memStream = new System.IO.MemoryStream();

            serializer.Serialize(memStream, this);
            // Set the position to the beginning of the stream.
            memStream.Seek(0, SeekOrigin.Begin);

            // Read the first 20 bytes from the stream.
            byteArray = new byte[memStream.Length];
            memStream.Read(byteArray, 0, (int)memStream.Length);

            memStream.Close();

            return byteArray;
        }

        public SystemEnvironment Deserialize(byte[] data)
        {
            return new SystemEnvironment();
        }
    }
}
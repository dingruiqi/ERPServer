using System.Collections.Generic;
using System.IO;
using ERPServer.Bussiness.AESHelper;

namespace ERPServer.Models.SystemInfo
{
    public class SystemEnvironment
    {
        public SystemEnvironment()
        {
            MACAddress = new List<string>();
            BoardID = "UnKnown Board";
        }

        public List<string> MACAddress { get; set; }

        public string BoardID { get; set; }
    }

    public static class SystemEnvironmentHelper
    {
        public static byte[] Encrypt(this SystemEnvironment environment)
        {
            byte[] byteArray;
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter serializer = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            System.IO.MemoryStream memStream = new System.IO.MemoryStream();

            serializer.Serialize(memStream, environment);
            // Set the position to the beginning of the stream.
            memStream.Seek(0, SeekOrigin.Begin);

            // Read the first 20 bytes from the stream.
            byteArray = new byte[memStream.Length];
            memStream.Read(byteArray, 0, (int)memStream.Length);

            memStream.Close();
            //加密
            return AESHelper.AesEncrypt(byteArray, AESHelper.AESKEY);
            //return byteArray;
        }

        public static SystemEnvironment Decrypt(this byte[] data)
        {
            //return new SystemEnvironment();
            byte[] byteArray = AESHelper.AesDecrypt(data, AESHelper.AESKEY);

            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter serializer = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            System.IO.MemoryStream memStream = new System.IO.MemoryStream();

            // Set the position to the beginning of the stream.
            memStream.Seek(0, SeekOrigin.Begin);

            memStream.Write(byteArray, 0, byteArray.Length);

            memStream.Close();

            SystemEnvironment result = (SystemEnvironment)serializer.Deserialize(memStream);

            return result;
        }
    }
}
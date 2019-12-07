using System.IO;
using System.Management;
using System.Runtime.InteropServices;
using ERPServer.Bussiness.AESHelper;

namespace ERPServer.Models.SystemInfo
{
    public static class SystemEnvironmentHelper
    {
        public static void GetSystemEnvironment(this SystemEnvironment environment)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                //windows操作系统
                #region cpu

                ManagementClass mc = new ManagementClass("Win32_Processor");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    string cd = mo.Properties["ProcessorId"].Value?.ToString();
                    if (!string.IsNullOrEmpty(cd))
                    {
                        environment.CpuID.Add(cd);
                    }
                }

                #endregion

                #region board

                mc = new ManagementClass("Win32_BaseBoard");
                moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    var sn = mo.Properties["SerialNumber"].Value?.ToString();
                    if (!string.IsNullOrEmpty(sn))
                    {
                        environment.BoardID.Add(mo.Properties["SerialNumber"].Value.ToString());
                    }
                }

                #endregion

                #region driver

                mc = new ManagementClass("Win32_PhysicalMedia");
                //网上有提到，用Win32_DiskDrive，但是用Win32_DiskDrive获得的硬盘信息中并不包含SerialNumber属性。   
                moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    var dn = mo.Properties["SerialNumber"].Value?.ToString();
                    if (!string.IsNullOrEmpty(dn))
                    {
                        environment.DriverNumber.Add(dn);
                    }
                }

                #endregion

                #region mac

                mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if ((bool)mo["IPEnabled"])
                    {
                        var mac = mo["MacAddress"]?.ToString();
                        if (!string.IsNullOrEmpty(mac))
                        {
                            environment.MACAddress.Add(mac);
                        }
                    }
                }

                #endregion
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                throw new System.Exception("未实现Linux操作系统");
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                throw new System.Exception("未实现OSX操作系统");
            }
        }

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
using System;
using System.Security.Cryptography;
using System.Text;

namespace ERPServer.Bussiness.AESHelper
{
    public class AESHelper
    {
        public const string AESKEY= "C&M work group";

        #region AES加密解密 
        /// <summary>
        /// 128位处理key 
        /// </summary>
        /// <param name="keyBit">需要的key长度</param>
        /// <param name="key">处理key</param>
        /// <returns></returns>
        private static byte[] GetAesKey(AESBit keyBit, string key)
        {
            byte[] keyArray = Encoding.UTF8.GetBytes(key);

            byte length = 16;
            byte[] newArray = new byte[16];
            switch (keyBit)
            {
                case AESBit.Bit128:
                    newArray = new byte[16];
                    length = 16;
                    break;
                case AESBit.Bit192:
                    newArray = new byte[24];
                    length = 24;
                    break;
                case AESBit.Bit256:
                    newArray = new byte[32];
                    length = 32;
                    break;
                default:
                    break;
            }

            if (keyArray.Length < length)
            {
                for (int i = 0; i < newArray.Length; i++)
                {
                    if (i >= keyArray.Length)
                    {
                        newArray[i] = 0;
                    }
                    else
                    {
                        newArray[i] = keyArray[i];
                    }
                }
            }
            return newArray;
        }
        /// <summary>
        /// 使用AES加密字符串,按128位处理key
        /// </summary>
        /// <param name="toEncryptArray">加密内容</param>
        /// <param name="key">秘钥，需要128位、256位.....</param>
        /// <returns>Base64字符串结果</returns>
        public static byte[] AesEncrypt(byte[] toEncryptArray, string key, bool autoHandle = true)
        {
            byte[] keyArray = Encoding.UTF8.GetBytes(key);
            if (autoHandle)
            {
                keyArray = GetAesKey(AESBit.Bit128, key);
            }

            SymmetricAlgorithm aes = Aes.Create();
            aes.Key = keyArray;
            aes.Mode = CipherMode.ECB;
            aes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = aes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            //return Convert.ToBase64String(resultArray);
            return resultArray;
        }
        /// <summary>
        /// 使用AES解密字符串,按128位处理key
        /// </summary>
        /// <param name="toDecryptArray">内容</param>
        /// <param name="key">秘钥，需要128位、256位.....</param>
        /// <returns>UTF8解密结果</returns>
        public static byte[] AesDecrypt(byte[] toDecryptArray, string key, bool autoHandle = true)
        {
            byte[] keyArray = Encoding.UTF8.GetBytes(key);
            if (autoHandle)
            {
                keyArray = GetAesKey(AESBit.Bit128, key);
            }

            SymmetricAlgorithm aes = Aes.Create();
            aes.Key = keyArray;
            aes.Mode = CipherMode.ECB;
            aes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = aes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toDecryptArray, 0, toDecryptArray.Length);

            //return Encoding.UTF8.GetString(resultArray);
            return resultArray;
        }
        #endregion
    }

    public enum AESBit
    {
        Bit128,

        Bit192,

        Bit256
    }
}
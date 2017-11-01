using System;
using System.Text;
using System.Security.Cryptography;

namespace Classes
{
    internal sealed class Keygen
    {
        internal static string ComputeSHA512(string Input)
        {
            SHA512CryptoServiceProvider CryptoSrv = new SHA512CryptoServiceProvider();
            byte[] Bytes = CryptoSrv.ComputeHash(Encoding.ASCII.GetBytes(Input));
            return BuildString(Bytes);
        }

        internal static string ComputeSHA384(string Input)
        {
            SHA384CryptoServiceProvider CryptoSrv = new SHA384CryptoServiceProvider();
            byte[] Bytes = CryptoSrv.ComputeHash(Encoding.ASCII.GetBytes(Input));
            return BuildString(Bytes);
        }

        internal static string ComputeSHA256(string Input)
        {
            SHA256CryptoServiceProvider CryptoSrv = new SHA256CryptoServiceProvider();
            byte[] Bytes = CryptoSrv.ComputeHash(Encoding.ASCII.GetBytes(Input));
            return BuildString(Bytes);
        }

        internal static string ComputeSHA1(string Input)
        {
            SHA1CryptoServiceProvider CryptoSrv = new SHA1CryptoServiceProvider();
            byte[] Bytes = CryptoSrv.ComputeHash(Encoding.ASCII.GetBytes(Input));
            return BuildString(Bytes);
        }

        internal static string ComputeMD5(string Input)
        {
            MD5CryptoServiceProvider CryptoSrv = new MD5CryptoServiceProvider();
            byte[] Bytes = CryptoSrv.ComputeHash(Encoding.ASCII.GetBytes(Input));
            return BuildString(Bytes);
        }

        private static string BuildString(byte[] Input)
        {
            StringBuilder Output = new StringBuilder();
            for (int i = 0; i < Input.Length; i++)
            {
                Output.Append(Input[i].ToString("X2"));
            }
            return Output.ToString();
        }
    }
}

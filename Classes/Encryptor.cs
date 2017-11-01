using System.IO;
using System.Text;
using System.Security.Cryptography;
using System;

namespace Classes
{
    internal static class Encryptor
    {
        private static string Base64Encode(string InputString)
        {
            MemoryStream memoryStream = new MemoryStream();
            StreamWriter streamWriter = new StreamWriter(memoryStream, Encoding.UTF32);
            streamWriter.Write(InputString);
            streamWriter.Close();
            byte[] Bytes = memoryStream.ToArray();
            memoryStream.Close();
            return Convert.ToBase64String(Bytes);
        }
        private static string Base64Decode(string Base64String)
        {
            byte[] Bytes = Convert.FromBase64String(Base64String);
            MemoryStream memoryStream = new MemoryStream(Bytes);
            StreamReader streamReader = new StreamReader(memoryStream, Encoding.UTF32);
            Base64String = streamReader.ReadToEnd();
            streamReader.Close(); memoryStream.Close();
            return Base64String;
        }
        internal static string EncryptText(string InputText, string Password)
        {
            byte[] Input = Encrypt(InputText, Password);
            StringBuilder Output = new StringBuilder();
            for (int i = 0; i < Input.Length; i++)
            {
                Output.Append(Base64Encode(Input[i].ToString()) + "|");
            }
            return Output.ToString().Replace('=', '$');
        }
        internal static string DecryptText(string InputText, string Password)
        {
            string[] Input = InputText.Replace('$', '=').Split('|');
            byte[] Bytes = new byte[Input.Length - 1];
            for (int i = 0; i < Bytes.Length; i++)
            {
                byte ByteVal = Convert.ToByte(Base64Decode(Input[i]));
                Bytes.SetValue(ByteVal, i);
            }
            return Decrypt(Bytes, Password);
        }
        private static RijndaelManaged CryptoTransform(string @Password)
        {
            RijndaelManaged RijndaelMgd = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.PKCS7 };
            byte[] SaltKey = Encoding.ASCII.GetBytes(Keygen.ComputeMD5(@Password));
            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(@Password, SaltKey);
            RijndaelMgd.Key = rfc2898DeriveBytes.GetBytes(32);
            RijndaelMgd.IV = rfc2898DeriveBytes.GetBytes(16);
            return RijndaelMgd;
        }
        private static byte[] Encrypt(string PlainText, string @Password)
        {
            byte[] EncryptedText;
            ICryptoTransform ICrypto = CryptoTransform(@Password).CreateEncryptor();
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, ICrypto, CryptoStreamMode.Write);
            using (StreamWriter SW = new StreamWriter(cryptoStream)) { SW.Write(PlainText); }
            EncryptedText = memoryStream.ToArray();
            return EncryptedText;
        }
        private static string Decrypt(byte[] EncryptedTxt, string @Password)
        {
            string DecryptedText;
            ICryptoTransform ICrypto = CryptoTransform(@Password).CreateDecryptor();
            MemoryStream memoryStream = new MemoryStream(EncryptedTxt);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, ICrypto, CryptoStreamMode.Read);
            StreamReader SR = new StreamReader(cryptoStream);
            try { DecryptedText = SR.ReadToEnd(); SR.Close(); } catch { DecryptedText = string.Empty; }
            return DecryptedText;
        }
    }
}

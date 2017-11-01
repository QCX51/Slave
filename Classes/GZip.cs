using System.IO;
using System.IO.Compression;
using System.Text;

namespace Classes
{
    internal static class GZip
    {
        internal static byte[] Compress(string Data)
        {
            MemoryStream stream = new MemoryStream();
            GZipStream zipCompressor = new GZipStream(stream, CompressionMode.Compress, true);
            StreamWriter sWriter = new StreamWriter(zipCompressor, Encoding.UTF8);
            sWriter.Write(Data); sWriter.Close();
            byte[] CompressedData = stream.ToArray();
            stream.Close(); zipCompressor.Close();
            return CompressedData;
        }

        internal static string Decompress(byte[] Data)
        {
            MemoryStream stream = new MemoryStream(Data);
            GZipStream zipDecompressor = new GZipStream(stream, CompressionMode.Decompress, true);
            StreamReader sReader = new StreamReader(zipDecompressor, Encoding.UTF8);
            string DecompressedData = sReader.ReadToEnd();
            sReader.Close(); stream.Close(); zipDecompressor.Close();
            return DecompressedData;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Data;


namespace AppCommon
{
    public class Compress_GZip
    {
        /// <summary>
        /// 压缩文件
        /// </summary>
        /// <param name="sourceFile">源文件</param>
        /// <param name="gzFile">目标文件，*.gz </param>
        /// <param name="pFileName">压缩包内文件名</param>
        public void Compress(string sourceFile, string gzFile)
        {
            string pFileName = sourceFile.Substring(sourceFile.LastIndexOf("\\")+1);;

            //文件流 
            FileStream reader = new FileStream(sourceFile, FileMode.Open);

            FileStream writer = new FileStream(gzFile,FileMode.Create,FileAccess.Write,FileShare.Read); ;

            //压缩相关的流 
            MemoryStream ms = new MemoryStream();
            GZipStream zipStream = new GZipStream(ms, CompressionMode.Compress, true);

            //往压缩流中写数据 
            byte[] sourceBuffer = new byte[reader.Length];


            reader.Read(sourceBuffer, 0, sourceBuffer.Length);
            zipStream.Write(sourceBuffer, 0, sourceBuffer.Length);

            //一定要在内存流读取之前关闭压缩流 
            zipStream.Close();
            zipStream.Dispose();

            //从内存流中读数据 
            ms.Position = 0; //注意，不要遗漏此句 
            byte[] destBuffer = new byte[ms.Length];
            //ms.Read(destBuffer, 0, destBuffer.Length); 

            byte[] header = new byte[10];
            ms.Read(header, 0, 10);
            header[3] = 8;        //表示包含文件名信息
            byte[] fielContent = new byte[ms.Length - 10];
            ms.Read(fielContent, 0, fielContent.Length);

            byte[] filename = System.Text.Encoding.Default.GetBytes(pFileName);

            writer.Write(header, 0, header.Length);
            writer.Write(filename, 0, filename.Length);
            writer.WriteByte(0);  //文件名以0 字节结束
            writer.Write(fielContent, 0, fielContent.Length);

            //关闭并释放内存流 
            ms.Close();
            ms.Dispose();

            //关闭并释放文件流 
            writer.Close();
            writer.Dispose();
            reader.Close();
            reader.Dispose(); 

        }
        public void DeCompress(System.IO.Stream cmpStream, System.IO.Stream orgStream)
        {
             System.IO.Compression.GZipStream zipStream = new System.IO.Compression.GZipStream(cmpStream, System.IO.Compression.CompressionMode.Decompress);
             BinaryReader reader = new BinaryReader(zipStream);
             BinaryWriter writer = new BinaryWriter(orgStream);
             while (true)
             {
                byte[] buffer = reader.ReadBytes(1024);
                if (buffer == null || buffer.Length < 1)
                break;
                writer.Write(buffer);
            }
        writer.Close();
        }

    }
}

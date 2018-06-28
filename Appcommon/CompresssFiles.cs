using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using ICSharpCode.SharpZipLib.BZip2;
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace AppCommon
{
    public class CompresssFiles
    {

        /// <summary>
        /// 对目标文件夹进行压缩，将压缩结果保存为指定文件
        /// </summary>
        /// <param name="dirPath">目标文件夹</param>
        /// <param name="fileName">压缩文件</param>
        public static void Compress(string dirPath, string fileName)
        {
            ArrayList list = new ArrayList();
            foreach (string f in Directory.GetFiles(dirPath))
            {
                byte[] destBuffer = File.ReadAllBytes(f);
                SerializeFileInfo sfi = new SerializeFileInfo(f, destBuffer);
                list.Add(sfi);
            }
            IFormatter formatter = new BinaryFormatter();
            using (Stream s = new MemoryStream())
            {
                formatter.Serialize(s, list);
                s.Position = 0;
                CreateCompressFile(s, fileName);
            }
        }

        /// <summary>
        /// 对目标压缩文件解压缩，将内容解压缩到指定文件夹
        /// </summary>
        /// <param name="fileName">压缩文件</param>
        /// <param name="dirPath">解压缩目录</param>
        public static void DeCompress(string fileName, string dirPath)
        {
            using (Stream source = File.OpenRead(fileName))
            {
                using (Stream destination = new MemoryStream())
                {
                    using (GZipStream input = new GZipStream(source, CompressionMode.Decompress, true))
                    {
                        byte[] bytes = new byte[4096];
                        int n;
                        while ((n = input.Read(bytes, 0, bytes.Length)) != 0)
                        {
                            destination.Write(bytes, 0, n);
                        }
                    }
                    destination.Flush();
                    destination.Position = 0;
                    DeSerializeFiles(destination, dirPath);
                }
            }
        }

        private static void DeSerializeFiles(Stream s, string dirPath)
        {
            BinaryFormatter b = new BinaryFormatter();
            // IFormatter b = new BinaryFormatter();
            // b.Binder = new UBinder();
            //MemoryStream stream = new MemoryStream(data, offset, stringlength);
            //this.m_bodyobject = (object)formatter.Deserialize(stream); 




            ArrayList list = (ArrayList)b.Deserialize(s);
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            foreach (SerializeFileInfo f in list)
            {

                string newName = dirPath + Path.GetFileName(f.FileName);
                using (FileStream fs = new FileStream(newName, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(f.FileBuffer, 0, f.FileBuffer.Length);
                    fs.Close();
                }
            }
        }

        //public class UBinder : SerializationBinder
        //{
        //    public override Type BindToType(string assemblyName, string typeName)
        //    {
        //        Assembly ass = Assembly.GetExecutingAssembly();
        //        return ass.GetType(typeName);
        //    }
        //}

        private static void CreateCompressFile(Stream source, string destinationName)
        {
            using (Stream destination = new FileStream(destinationName, FileMode.Create, FileAccess.Write))
            {
                using (GZipStream output = new GZipStream(destination, CompressionMode.Compress))
                {
                    byte[] bytes = new byte[4096];
                    int n;
                    while ((n = source.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        output.Write(bytes, 0, n);
                    }
                }
            }
        }

        [Serializable]
        class SerializeFileInfo
        {
            public SerializeFileInfo(string name, byte[] buffer)
            {
                fileName = name;
                fileBuffer = buffer;
            }

            string fileName;
            public string FileName
            {
                get
                {
                    return fileName;
                }
            }

            byte[] fileBuffer;
            public byte[] FileBuffer
            {
                get
                {
                    return fileBuffer;
                }
            }
        }


        public string cutStr = "";
        /// <summary>
        /// 压缩文件
        /// </summary>
        /// <param name="FileToZip"></param>
        /// <param name="ZipedFile"></param>
        /// <param name="CompressionLevel"></param>
        /// <param name="BlockSize"></param>
        public static void ZipFile(string FileToZip, string ZipedFile, int CompressionLevel, int BlockSize)
        {
            //如果文件没有找到则报错。
            if (!System.IO.File.Exists(FileToZip))
            {
                throw new System.IO.FileNotFoundException("The specified file " + FileToZip + " could not be found. Zipping aborderd");
            }

            System.IO.FileStream StreamToZip = new System.IO.FileStream(FileToZip, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            System.IO.FileStream ZipFile = System.IO.File.Create(ZipedFile);
            ZipOutputStream ZipStream = new ZipOutputStream(ZipFile);
            ZipEntry ZipEntry = new ZipEntry("ZippedFile");
            ZipStream.PutNextEntry(ZipEntry);
            ZipStream.SetLevel(CompressionLevel);
            byte[] buffer = new byte[BlockSize];
            System.Int32 size = StreamToZip.Read(buffer, 0, buffer.Length);
            ZipStream.Write(buffer, 0, size);
            try
            {
                while (size < StreamToZip.Length)
                {
                    int sizeRead = StreamToZip.Read(buffer, 0, buffer.Length);
                    ZipStream.Write(buffer, 0, sizeRead);
                    size += sizeRead;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            ZipStream.Finish();
            ZipStream.Close();
            StreamToZip.Close();
        }

        //Get all DirectoryInfo
        private void direct(DirectoryInfo di, ref ZipOutputStream s, Crc32 crc)
        {
            //DirectoryInfo di = new DirectoryInfo(filenames);
            DirectoryInfo[] dirs = di.GetDirectories("*");

            //遍历目录下面的所有的子目录
            foreach (DirectoryInfo dirNext in dirs)
            {
                //将该目录下的所有文件添加到 ZipOutputStream s 压缩流里面
                FileInfo[] a = dirNext.GetFiles();
                this.writeStream(ref s, a, crc);

                //递归调用直到把所有的目录遍历完成
                direct(dirNext, ref s, crc);
            }
        }

        private void writeStream(ref ZipOutputStream s, FileInfo[] a, Crc32 crc)
        {
            foreach (FileInfo fi in a)
            {
                //string fifn = fi.FullName;
                FileStream fs = fi.OpenRead();

                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);


                //ZipEntry entry = new ZipEntry(file);    Path.GetFileName(file)
                string file = fi.FullName;
                file = file.Replace(cutStr, "");

                ZipEntry entry = new ZipEntry(file);

                entry.DateTime = DateTime.Now;

                // set Size and the crc, because the information
                // about the size and crc should be stored in the header
                // if it is not set it is automatically written in the footer.
                // (in this case size == crc == -1 in the header)
                // Some ZIP programs have problems with zip files that don't store
                // the size and crc in the header.
                entry.Size = fs.Length;
                fs.Close();

                crc.Reset();
                crc.Update(buffer);

                entry.Crc = crc.Value;

                s.PutNextEntry(entry);

                s.Write(buffer, 0, buffer.Length);
            }
        }

        /// <summary>
        /// 压缩指定目录下指定文件(包括子目录下的文件)
        /// </summary>
        /// <param name="zippath">args[0]为你要压缩的目录所在的路径 
        /// 例如：D:\\temp\\   (注意temp 后面加 \\ 但是你写程序的时候怎么修改都可以)</param>
        /// <param name="zipfilename">args[1]为压缩后的文件名及其路径
        /// 例如：D:\\temp.zip</param>
        /// <param name="fileFilter">文件过滤, 例如*.xml,这样只压缩.xml文件.</param>
        ///
        public bool ZipFileMain(string zippath, string zipfilename, string fileFilter)
        {
            try
            {
                //string filenames = Directory.GetFiles(args[0]);

                Crc32 crc = new Crc32();
                ZipOutputStream s = new ZipOutputStream(File.Create(zipfilename));

                s.SetLevel(6); // 0 - store only to 9 - means best compression

                DirectoryInfo di = new DirectoryInfo(zippath);

                FileInfo[] a = di.GetFiles(fileFilter);

                cutStr = zippath.Trim();
                //压缩这个目录下的所有文件
                writeStream(ref s, a, crc);
                //压缩这个目录下子目录及其文件
                direct(di, ref s, crc);

                s.Finish();
                s.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 解压缩文件(压缩文件中含有子目录)
        /// </summary>
        /// <param name="zipfilepath">待解压缩的文件路径</param>
        /// <param name="unzippath">解压缩到指定目录</param>
        public static void UnZip(string zipfilepath, string unzippath)
        {
            ZipInputStream s = new ZipInputStream(File.OpenRead(zipfilepath));

            ZipEntry theEntry;
            while ((theEntry = s.GetNextEntry()) != null)
            {
                string directoryName = Path.GetDirectoryName(unzippath);
                string fileName = Path.GetFileName(theEntry.Name);

                //生成解压目录
                Directory.CreateDirectory(directoryName);

                if (fileName != String.Empty)
                {
                    //如果文件的压缩后大小为0那么说明这个文件是空的,因此不需要进行读出写入
                    if (theEntry.CompressedSize == 0)
                        break;
                    //解压文件到指定的目录
                    directoryName = Path.GetDirectoryName(unzippath + theEntry.Name);
                    //建立下面的目录和子目录
                    Directory.CreateDirectory(directoryName);

                    FileStream streamWriter = File.Create(unzippath + theEntry.Name);
                    //FileStream streamWriter = File.Create(theEntry.Name);
                    int size = 2048;
                    byte[] data = new byte[2048];
                    while (true)
                    {
                        size = s.Read(data, 0, data.Length);
                        if (size > 0)
                        {
                            streamWriter.Write(data, 0, size);
                        }
                        else
                        {
                            break;
                        }
                    }
                    streamWriter.Close();
                }
            }
            s.Close();
        }
    }
}

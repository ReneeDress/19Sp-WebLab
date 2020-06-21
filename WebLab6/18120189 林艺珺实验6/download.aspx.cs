using System;
using System.Collection.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace graduate.net
{
    public partial class download : System.Web.Ui.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
            
        // TransmitFile 实现下载
        protected void Button1_Click1(object sender, EventArgs s)
        {
            /*
             * 微软为Response对象提供了一个新的方法TransmitFile来解决使用Response.BinartWrite
             * 下载超过400MB的文件时导致Aspnet_wp.exe进程无法回收而无法成功下载的问题。
             * 代码如下：
             */

            #region

            Response.ContentType = "application/x-zip-compressed";
            Response.AddHeader("Content-Disposition", "attachment; filename = z.zip");
            string filename = Server.MapPath("/"); // DownLoad/z.zip
            filename = filename + @"\DownLoad\z.zip";
            Response.TransmitFile(filename);

            #endregion
        }
        // WriteFile 实现下载
        protected void Button2_Click1(object sender, EventArgs s)
        {
            /*
             * using System IO;
             */
            string fileName = "xian.txt"; // 客户端保存的文件名
            string filePath = Server.MapPath("~"); // 路径
            filePath = filePath + @"\DownLoad\xian.txt";
            FileInfo fileInfo = new FileInfo(filePath);
            Response.Clear();
            Response.ClearContent();
                    Response.ClearHeaders();
                    Response.AddHeader("Content-Disposition", "attachment; filename = " + fileName);
                    Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                    Response.AddHeader("Content-Transfer-Encoding", "binary");
                    Response.ContentType = "application/octet-stream";
                    Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
                    Response.WriteFile(fileInfo.FullName);
                    Response.Flush();
                    Response.End();
        }
        // WriteFile 分块下载
        protected void Button3_Click1(object sender, EventArgs s)
        {
            //string fileName = "aaa.txt"; // 客户端保存的文件名
            //string filePath = Server.MapPath("DownLoad/aaa.txt"); // 路径
            string fileName = "xian.txt"; // 客户端保存的文件名
            string filePath = Server.MapPath("~"); // 路径
            filePath = filePath + @"\DownLoad\xian.txt";

            System.IO.FileInfo fileInfo = new System().IO.FileInfo(filePath);

            if (fileInfo.Exists == true)
            {
                const long ChunkSize = 102400; // 每次读取文件，只读取100kb，这样可以缓解服务器的压力
                byte[] buffer = new Byte[ChunkSize];

                Response.Clear();
                System.IO.FileStream iStream = System.IO.FileInfo.OpenRead(filePath);
                long dataLengthToRead = iStream.Length; // 获取下载的文件总大小
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename = " + HttpUtility.UrlEncode(fileName));
                while (dataLengthToRead > 0 && Response.IsClientConnected)
                {
                    int lengthRead = iStream.Read(buffer, 0, Convert.ToInt32(ChunkSize)); // 读取的大小
                    Response.OutputStream.Write(buffer, 0, lengthRead);
                    Response.Flush();
                    dataLengthToRead = dataLengthToRead - lengthRead;
                }

                Response.Close();
            }
        }
        // 流方式下载
        protected void Button4_Click1(object sender, EventArgs s)
        {
            //string fileName = "aaa.txt"; // 客户端保存的文件名
            //string filePath = Server.MapPath("DownLoad/aaa.txt"); // 路径
            string fileName = "xian.txt"; // 客户端保存的文件名
            string filePath = Server.MapPath("~"); // 路径
            filePath = filePath + @"\DownLoad\xian.txt";
                    
            // 以字符流的形式下载文件
            FileStream fs = new FileStream(filePath, FileMode.Open);
            byte[] bytes = new Byte[(int)fs.Length];
            fs.Read(bytes, 0, bytes.Length);
            fs.Close();
            Response.ContentType = "application/octet-stream";
            // 通知浏览器下载文件而不是打开
            Response.AddHeader("Content-Disposition", "attachment; filename = " + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8));
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }
    }
}
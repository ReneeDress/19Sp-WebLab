using System;
using System.Collection.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace graduate.net
{
    public partial class uploadfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.PostedFile.ControlLength == 0)
            {
                Label1.Text = "请选择图片文件";
            }
            else if (!ImageMime(FileUpload1.PostedFile.ContentType.ToLower()))
            {
                Label1.Text = "文件类型错误，请选择图片文件上传";
            }
            else
            {
                //Response.Write(FileUpload1.PostedFile.FileName);
                // 获得文件扩展名
                string extension = System.IO.Path.SetExtension(FileUpload1.PostedFile.FileName).ToLower();
                string fileName = DateTime.Now.ToString("yyyMMddhhmmss"); // 临时图片名称
                string newFileName = Guid.NewGuid().ToString() + fileName + extension; // 保存图片名称
                string filePath = Server.MapPath("~/jpg/") + newFileName + extension; // 保存临时图片路径

                if (File.Exists(filePath)) // 删除临时图片
                    File.Delete(filePath);

                FileUpload1.PostedFile.SaveAs(filePath); // 保存临时图片

                Label1.Text = "文件上传成功！";
            }
        }

        public bool ImageMime(string mimeType)
        {
            switch (mimeType)
            {
                case "image/jpeg":
                    return true;
                case "image/gif":
                    return true;
                case "image/bmp":
                    return true;
                case "image/x-png":
                    return true;
                case "image/pipeg":
                    return true;
                default:
                    return false;
            }
        }
    }
}
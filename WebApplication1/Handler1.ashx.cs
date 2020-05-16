using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace WebApplication1
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class Handler1 : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            //选取的颜色
            Color[] colors = { Color.White };
            //通过Bitmap构造Image
            Image img = new Bitmap(100, 60);
            //Graphics绘画Image
            Graphics graphics = Graphics.FromImage(img);

            Random random = new Random(DateTime.Now.Millisecond);
            //验证码的四位数
            int charNum1 = random.Next('0', '9' + 1);
            int charNum2 = random.Next('0', '9' + 1);
            int charNum3 = random.Next('0', '9' + 1);
            int charNum4 = random.Next('0', '9' + 1);
            //把生成的随机数变成字符串，通过char进行转换
            string validCode = string.Format($"{(char)charNum1}{(char)charNum2}{(char)charNum3}{(char)charNum4}");
            //放进Session进行存储，记得继承接口，否则疯狂报空指针
            context.Session["verification_Code"] = validCode;
            //字体的大小和类别
            Font font = new Font("宋体", 24);
            //随机的颜色
            Brush brush1 = new SolidBrush(colors[random.Next(0, colors.Length - 1)]);
            //DrawString的四个参数，第一个是要写的字符，第二个是字体，第三个是颜色，第四个是坐标x,y
            graphics.DrawString(((char)charNum1).ToString(), font, brush1, 7, -3);
            Brush brush2 = new SolidBrush(colors[random.Next(0, colors.Length - 1)]);
            graphics.DrawString(((char)charNum2).ToString(), font, brush2, 26, -9);
            Brush brush3 = new SolidBrush(colors[random.Next(0, colors.Length - 1)]);
            graphics.DrawString(((char)charNum3).ToString(), font, brush3, 50, 0);
            Brush brush4 = new SolidBrush(colors[random.Next(0, colors.Length - 1)]);
            graphics.DrawString(((char)charNum4).ToString(), font, brush4, 70, -7);
            //保存，格式
            context.Response.ContentType = "image/jpeg";
            img.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            //释放资源
            graphics.Dispose();
            img.Dispose(); 
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
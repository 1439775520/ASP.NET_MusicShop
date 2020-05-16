using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.BLL;
using WebApplication1.DAL;

namespace WebApplication1.Admin
{
    public partial class Add_MusicType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string music_Name = TextBox1.Text;
            string music_Detail = TextBox2.Text;

           bool flag =  MusicType.addMusicType(music_Name, music_Detail);
            if (flag)
            {
                string strUrl = "<script>alert('添加成功');window.location.href='MusicType.aspx'</script>";
                        Response.Write(strUrl);
            }
            else
            {
                string strUrl = "<script>alert('添加失败');</script>";
                        Response.Write(strUrl);
            }

            //using (OLMSDBEntities oLMSDB = new OLMSDBEntities())
            //{

            //    oLMSDB.Genres.Add(new Genres
            //    {
            //        Name = music_Name,
            //        Description = music_Detail
            //    });
            //    if (oLMSDB.SaveChanges() > 0)
            //    {
            //        string strUrl = "<script>alert('添加成功');window.location.href='MusicType.aspx'</script>";
            //        Response.Write(strUrl);
            //    }
            //    else
            //    {
            //        string strUrl = "<script>alert('添加失败');</script>";
            //        Response.Write(strUrl);
            //    }
            //}
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string strUrl = "window.location.href='MusicType.aspx'</script>";
            Response.Write(strUrl);
        }
    }
}
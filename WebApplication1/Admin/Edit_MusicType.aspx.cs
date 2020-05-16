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
    public partial class Edit_MusicType : System.Web.UI.Page
    {
        Genres data;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            int id = Convert.ToInt32(Request.QueryString["id"]);
            OLMSDBEntities oLMSDB = new OLMSDBEntities();
            if (!IsPostBack)
            {

           
              data = oLMSDB.Genres.FirstOrDefault(t => t.GenreId == id);
            TextBox1.Text = data.Name;
            TextBox2.Text = data.Description;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string strUrl = "window.location.href='MusicType.aspx'</script>";
            Response.Write(strUrl);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
     //       using (OLMSDBEntities oLMSDB = new OLMSDBEntities())
       //     {
                string music_Name = TextBox1.Text;
                string music_Detail = TextBox2.Text;
                int id = Convert.ToInt32(Request.QueryString["id"]);
            //var genres = oLMSDB.Genres.FirstOrDefault(t => t.GenreId == id);
            //genres.Name = TextBox1.Text;
            //genres.Description = TextBox2.Text;
            bool updateMusicType = MusicType.updateMusicType(id, music_Name, music_Detail);
                if (updateMusicType)
                {
                    string strUrl = "<script>alert('修改成功');window.location.href='MusicType.aspx'</script>";
                    Response.Write(strUrl);
                }
                else
                {
                    string strUrl = "<script>alert('修改失败');</script>";
                    Response.Write(strUrl);
                }
         //   }
        }
    }
}
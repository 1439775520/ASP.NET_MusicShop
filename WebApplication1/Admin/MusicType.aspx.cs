using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.DAL;

using WebApplication1.BLL;

namespace WebApplication1.Admin
{
    public partial class MusicManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (OLMSDBEntities oLMSDB = new OLMSDBEntities())
                {
                    Repeater1.DataSource = oLMSDB.Genres.ToList();
                    Repeater1.DataBind();
                }
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            string str = e.CommandName.ToString();
            //这里获取id，我的id是刚才我赋值的时候CommandArgument是赋值的id
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            //using (OLMSDBEntities oLMSDB = new OLMSDBEntities())
            //{


            // var gener = oLMSDB.Genres.FirstOrDefault(t => t.GenreId == id);
            if (str == "Delete")
            {
                //看看有没有歌曲是这个类型的,如果有证明有外键限制
                List<Albums> list = AlbumManager.getAlbumeByGenId(id);
                if (list.Count > 0)
                {
                    string strUrl = "<script>alert('歌曲有关联数据,禁止删除');</script>";
                    Response.Write(strUrl);
                }
                else
                {



                    //后面是对数据库的操作，可以忽略
                    //    oLMSDB.Genres.Remove(gener);
                    bool flag_deleteMussicType = MusicType.deleteMusicType(id);
                    if (flag_deleteMussicType)
                    {
                        string strUrl = "<script>alert('删除成功');window.location.href='MusicType.aspx'</script>";
                        Response.Write(strUrl);
                    }
                    else
                    {
                        string strUrl = "<script>alert('删除失败');</script>";
                        Response.Write(strUrl);
                    }
                }
            }
            else if (str == "Edit")
            {
                Response.Redirect($"Edit_MusicType.aspx?id={id}");

            }
            //}
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Add_MusicType.aspx");
        }
    }
}
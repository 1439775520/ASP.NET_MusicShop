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
    public partial class MusicManager1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadData();
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

                //后面是对数据库的操作，可以忽略
                //    oLMSDB.Genres.Remove(gener);
                bool flag_deleteMussicType = BLL.MusicManager.deleteMusicManager(id);


                if (flag_deleteMussicType)
                {
                    string strUrl = "<script>alert('删除成功');window.location.href='MusicManager.aspx'</script>";
                    Response.Write(strUrl);
                }
                else
                {
                    string strUrl = "<script>alert('删除失败');</script>";
                    Response.Write(strUrl);
                }
            }
            else if (str == "Edit")
            {
                Response.Redirect($"Edit_MusicManager.aspx?id={id}");

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Add_MusicManager.aspx");
        }
      

        //页码
        public int pageNumber
        {
            //取值的话，如果里面没有就说明第一次进入，然后给它赋值，下面在取值
            get
            {
                if (ViewState["page"] == null)
                {
                    return 1;
                }
                else
                {
                    return Convert.ToInt32(ViewState["page"]);
                }
            }
            set
            {
                ViewState["page"] = value;
            }
        }
        //每页的记录数
        public int pageSize
        {
            get
            {
                return 5;
            }
        }
        //总页数
        public int pageCount
        {
            get
            {
                if (ViewState["count"] == null)
                {
                    return 1;
                }
                else
                {
                    return Convert.ToInt32(ViewState["count"]);
                }
            }
            set
            {
                ViewState["count"] = value;
            }
        }


        public void LoadData()
        {
            using (OLMSDBEntities oLMSDB = new OLMSDBEntities())
            {                          //这里是某个表的列表      skip是跳过前面的多少条数据         take这是跳过前面的数据后显示多少条数据
                                       //     //这里是我需要显示第三页的数据，我们要跳过二页的数据，所以是（3-1）*一页的数据量
                Repeater1.DataSource = oLMSDB.Albums.ToList().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
                Repeater1.DataBind();
                pageCount = oLMSDB.Albums.ToList().Count;
                Label1.Text = $"每页{pageSize}条，共{pageCount}条    ";
                //我们最后剩下一行数据也要在加一页，如果有余数就要加一页
                pageCount = pageCount % pageSize == 0 ? pageCount / pageSize : pageCount / pageSize + 1;
            }
            Label1.Text += "当前页数为" + pageNumber + "/" + pageCount;
        }

        //首页
        protected void btnFirst_Click(object sender, EventArgs e)
        {
            pageNumber = 1;
            LoadData();
        }

        //上一页
        protected void btnPrev_Click(object sender, EventArgs e)
        {
            //防止到0页，如果到0页的话，我们就是到1页
            pageNumber = pageNumber - 1 < 1 ? pageNumber = 1 : pageNumber - 1;

            LoadData();
        }

        //下一页
        protected void btnNext_Click(object sender, EventArgs e)
        {
            //防止超出所有的页面总数，超出的话，就赋值页面总数
            pageNumber = pageNumber + 1 > pageCount ? pageNumber = pageCount : pageNumber + 1;
            LoadData();
        }

        //尾页
        protected void btnLast_Click(object sender, EventArgs e)
        {
            pageNumber = pageCount;
            LoadData();
        }
    }
}
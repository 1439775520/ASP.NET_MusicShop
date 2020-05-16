using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.BLL;
using WebApplication1.DAL;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                login.Visible = true;
                rex.Visible = false;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (login.Visible)
            {
                string loginId = login_id.Text;
                string loginPwd = login_pwd.Text;
                string loginCode = login_Code.Text;
                string snCode = Session["verification_Code"] as String;
                if (loginCode == snCode)
                {
                    Users users = UserService.Login(loginId, loginPwd);
                    if (users != null)
                    {
                        Session["user"] = users;
                        if (users.RoleId == 1)
                        {
                            Response.Redirect("~/Admin/AdminSite.aspx");
                        } else
                        {
                            Response.Redirect("~/User/WebForm1.aspx");
                        }
                    }
                    else
                    {
                        Response.Write("<script language='javascript'>");
                        Response.Write("alert('错误提示，账号或密码错误。单击“确定”返回网站。');");
                        Response.Write("</script>");

                    }
                }

            } else
            {
                login.Visible = true;
                rex.Visible = false;
            }
        }

        protected void btnReg_Click(object sender, EventArgs e)
        {
            if (rex.Visible)
            {
                string id = reg_id.Text;
                string pwd = reg_pwd.Text;
                string name = reg_Name.Text;
                string phone = reg_Phone.Text;
                bool bools = UserService.register(id, pwd, name, phone);
                if (bools)
                {
                    string strUrl = "<script>alert('添加成功');window.location.href='Login.aspx'</script>";
                    Response.Write(strUrl);
                    //Response.Write("<script language='javascript'>");
                    //Response.Write("alert('添加成功');");
                    //Response.Write("</script>");
                    //Response.Redirect("Login.aspx");
                }
                else
                {
                    Response.Write("<script language='javascript'>");
                    Response.Write("alert('添加失败');");
                    Response.Write("</script>");

                } 
               
            }
            else
            {
                login.Visible = false;
                rex.Visible = true;
            }
        }
    }
}
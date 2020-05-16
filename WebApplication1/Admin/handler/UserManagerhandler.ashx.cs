using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.BLL;
using WebApplication1.DAL;

namespace WebApplication1.Admin.handler
{
    /// <summary>
    /// UserManagerhandler 的摘要说明
    /// </summary>
    public class UserManagerhandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string json = "";
            if (context.Request["type"] != null)//请求中是否有type参数
            {
                var list = RoleService.QueryAll().Select(r => new {
                    RoleId = r.RoleId,
                    Name = r.Name
                }).ToList();
                json = JsonConvert.SerializeObject(list);
            }
            else
            {
                var uid = context.Request["uid"];
                var rid = context.Request["rid"];
                if (uid != null && rid != null)
                {
                    //修改用户角色
                    int userId = Convert.ToInt32(uid);
                    int roleId = Convert.ToInt32(rid);
                    UserService.changeRole(userId, roleId);
                }

                //查询用户数据
                var list = UserService.QueryALL().Select(u => new Users
                {
                    UserId = u.UserId,
                    UserName = u.UserName,
                    LoginId = u.LoginId,
                    LoginPwd = u.LoginPwd,
                    RoleId = u.RoleId,
                    UserStatus = u.UserStatus,
                    Phone = u.Phone,
                    DateCreated = u.DateCreated

                }).ToList();
                //讲list转化成json字符串 需要导入Newtonsoft包
                json = JsonConvert.SerializeObject(list);
            }

            context.Response.ContentType = "application/json";
            context.Response.Write(json);
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
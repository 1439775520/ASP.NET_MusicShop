using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using WebApplication1.DAL;

namespace WebApplication1.BLL
{
    public class UserService
    {
        public static bool register(string Id, string Pwd, string name, string phone)
        {
            Pwd = PasswordEncryption(Pwd);
            using (OLMSDBEntities db = new OLMSDBEntities())
            {
                Users users = db.Users.Add(new Users
                {
                    LoginId = Id,
                    LoginPwd = Pwd,
                    UserName = name,
                    RoleId = 2,
                    Phone = phone,
                    DateCreated = DateTime.Now,
                    UserStatus = 1

                });
                if (db.SaveChanges() > 0)
                {
                    return true;
                }
                return false;
            }
        }

         

        /// <summary>
        ///   查询所有用户列表数据
        /// </summary>
        /// <returns></returns>
        internal static List<Users> QueryALL()
        {
            using (OLMSDBEntities oLMSDB = new OLMSDBEntities())
            {
                return oLMSDB.Users.ToList();
            }
        }

        internal static bool changeRole(int userId, int roleId)
        {
            using (OLMSDBEntities oLMSDB = new OLMSDBEntities())
            {
                Users user = oLMSDB.Users.FirstOrDefault(u => u.UserId == userId);
                user.RoleId = roleId;
                return oLMSDB.SaveChanges() > 0;

            }
        }

        public static Users Login(string loginId, string loginPwd)
        {
            loginPwd = PasswordEncryption(loginPwd);
            using (OLMSDBEntities db = new OLMSDBEntities())
            {
                Users users = db.Users.FirstOrDefault(u => u.LoginId == loginId
                && u.LoginPwd == loginPwd);
                return users;
            }
        }
        private static string PasswordEncryption(string pwd)
        { //创建SHA1加密算法对象 
            SHA1 sha1 = SHA1.Create(); //将原始密码转换为字节数组 
            byte[] originalPwd = Encoding.UTF8.GetBytes(pwd); //执行加密 
            byte[] encryPwd = sha1.ComputeHash(originalPwd); //将加密后的字节数组转换为大写字符串 
            return string.Join("", encryPwd.Select(b => string.Format("{0:x2}", b)).ToArray()).ToUpper();
        }
    }

}
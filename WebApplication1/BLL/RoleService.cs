using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using WebApplication1.DAL;
using Roles = WebApplication1.DAL.Roles;

namespace WebApplication1.BLL
{
    public class RoleService
    {
        internal static List<Roles> QueryAll()
        {
            using (OLMSDBEntities oLMSDB = new OLMSDBEntities())
            {
                return oLMSDB.Roles.ToList();
            }
        }
    }
}
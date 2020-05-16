using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.DAL;

namespace WebApplication1.Admin
{
    public partial class RoleManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (OLMSDBEntities db = new OLMSDBEntities())
                {
                    Repeater1.DataSource = db.Roles.ToList();
                    Repeater1.DataBind();
                }
            }

        }
    }
}
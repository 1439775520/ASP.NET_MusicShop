using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.DAL;

namespace WebApplication1.Admin
{
    public partial class Edit_MusicManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                using (OLMSDBEntities oLMSDB = new OLMSDBEntities())
                {
                    DropDownList1.DataSource = oLMSDB.Genres.ToList();
                    DropDownList1.DataValueField = "GenreId";
                    DropDownList1.DataTextField = "Name";
                    DropDownList1.DataBind();
                    var artists = oLMSDB.Albums.FirstOrDefault(s => s.AlbumId == id);
                    MusicName.Text = artists.Title;
                    MusicCreate.Text = artists.Artists.Name;
                    DropDownList1.DataValueField = artists.GenreId.ToString();
                    MusicPrice.Text = artists.Price.ToString();
                    Image1.ImageUrl = "" + artists.AlbumArtUrl;
                }
            }
             
                 
             
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            using (OLMSDBEntities oLMSDB = new OLMSDBEntities())
            {
                string name = MusicCreate.Text;

                var MusicCreaterName = oLMSDB.Artists.FirstOrDefault(s => s.Name == name);
                if (MusicCreaterName == null)
                {
                    Artists artistss = new Artists
                    {
                        Name = name
                    };
                    oLMSDB.Artists.Add(artistss);
                    if (oLMSDB.SaveChanges() == -1)
                    {
                        string strUrl = "<script>alert('歌手添加失败');</script>";
                        Response.Write(strUrl);

                    }
                }
                  MusicCreaterName = oLMSDB.Artists.FirstOrDefault(s => s.Name == name);
                var artists = oLMSDB.Albums.FirstOrDefault(s => s.AlbumId == id);
                artists.Title = MusicName.Text;
                artists.ArtistId = MusicCreaterName.ArtistId; 
                artists.GenreId = Convert.ToInt32(DropDownList1.SelectedValue);
                artists.Price = Convert.ToDecimal(MusicPrice.Text);
                if (FileUpload1.HasFile)
                {

                    artists.AlbumArtUrl = "/Content/Images/" + FileUpload1.FileName.ToString();
                }
                
                if (oLMSDB.SaveChanges() > 0)
                {
                     
                        string strUrl = "<script>alert('修改成功');window.location.href='MusicManager.aspx'</script>";
                        Response.Write(strUrl);
                     
                }
                else
                {
                        string strUrl = "<script>alert('修改失败');</script>";
                        Response.Write(strUrl);
                     
                }
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            Response.Redirect("MusicManager.aspx");
        }
    }
}
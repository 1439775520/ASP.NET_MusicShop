using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.DAL;

namespace WebApplication1.Admin
{
    public partial class Add_MusicManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (OLMSDBEntities db = new OLMSDBEntities())
                {
                    DropDownList1.DataSource = db.Genres.ToList();
                    DropDownList1.DataValueField = "GenreId";
                    DropDownList1.DataTextField = "Name";
                    DropDownList1.DataBind();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string fileName = FileUpload1.FileName;
                string endName = Path.GetExtension(fileName).ToLower();
                if(endName != ".jpg")
                {
                    string strUrl = "<script>alert('图片格式必须是.JPG格式');</script>";
                    Response.Write(strUrl);
                }
                else
                {
                    FileUpload1.SaveAs(Server.MapPath("..\\Content\\Images\\" + fileName));
                    this.Image1.ImageUrl = "~/Content/Images/" + fileName;

                    using (OLMSDBEntities oLMSDB = new OLMSDBEntities())
                    {
                        string name = MusicCreate.Text;

                        var MusicCreaterName = oLMSDB.Artists.FirstOrDefault(s => s.Name == name);
                        if (MusicCreaterName == null)
                        {
                            Artists artists = new Artists
                            {
                                Name = name
                            };
                            oLMSDB.Artists.Add(artists);
                            if (oLMSDB.SaveChanges() == 0)
                            {
                                string strUrl = "<script>alert('歌手添加失败');</script>";
                                Response.Write(strUrl);

                            }
                        }
                        //else
                        //{
                        //    Albums albums = new Albums
                        //    {
                        //        GenreId = Convert.ToInt32(DropDownList1.SelectedValue),
                        //        ArtistId = MusicCreaterName.ArtistId,
                        //        Title = MusicName.Text,
                        //        Price = Convert.ToDecimal(MusicPrice.Text),
                        //        AlbumArtUrl = FileUpload1.FileName

                        //    };
                        //    oLMSDB.Albums.Add(albums);
                        //    if (oLMSDB.SaveChanges() > 0)
                        //    {
                        //        string strUrl = "<script>alert('添加成功');window.location.href='../HoTaiYingYYM.aspx'</script>";
                        //        Response.Write(strUrl);
                        //    }
                        //    else
                        //    {
                        //        string strUrl = "<script>alert('添加失败');</script>";
                        //        Response.Write(strUrl);
                        //    }
                        //}
                         var artistId = oLMSDB.Artists.FirstOrDefault(s => s.Name == name);
                        Albums albums = new Albums
                        {
                            GenreId = Convert.ToInt32(DropDownList1.SelectedValue),
                            ArtistId = artistId.ArtistId,
                            Title = MusicName.Text,
                            Price = Convert.ToDecimal(MusicPrice.Text),
                            AlbumArtUrl = "/Content/Images/"+FileUpload1.FileName.ToString()

                        };
                        oLMSDB.Albums.Add(albums);
                        if (oLMSDB.SaveChanges() > 0)
                        {
                            string strUrl = "<script>alert('添加成功');window.location.href='MusicManager.aspx'</script>";
                            Response.Write(strUrl);
                        }
                        else
                        {
                            string strUrl = "<script>alert('添加失败');</script>";
                            Response.Write(strUrl);
                        }


                    }
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("MusicManager.aspx");
        }
    }
}
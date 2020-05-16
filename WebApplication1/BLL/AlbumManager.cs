using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.DAL;

namespace WebApplication1.BLL
{
    public class AlbumManager
    {
        public static List<Albums> getAlbumeByGenId(int id)
        {
            using (OLMSDBEntities oLMSDBEntities = new OLMSDBEntities())
            {
                List<Albums> data = oLMSDBEntities.Albums.Where(a => a.GenreId == id).ToList();
                return data;
            }
        }
    }
}
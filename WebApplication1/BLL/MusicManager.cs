using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.DAL;

namespace WebApplication1.BLL
{
    public class MusicManager
    {
        public static bool deleteMusicManager(int id)
        {
            using (OLMSDBEntities oLMSDB = new OLMSDBEntities())
            {
                var gener = oLMSDB.Albums.FirstOrDefault(t => t.AlbumId == id);
                oLMSDB.Albums.Remove(gener);
                return oLMSDB.SaveChanges() > 0;
            }

        }
    }
}
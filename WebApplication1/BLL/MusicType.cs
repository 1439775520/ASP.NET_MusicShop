using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.DAL;

namespace WebApplication1.BLL
{
    public class MusicType
    {
        public static bool addMusicType(string name, string detail)
        {
            using (OLMSDBEntities oLMSDB = new OLMSDBEntities())
            {

                oLMSDB.Genres.Add(new Genres
                {
                    Name = name,
                    Description = detail
                });
                if (oLMSDB.SaveChanges() > 0)
                {
                    return true;
                }
                else
                { 
                    return false;
                }
            }
          
        }

        public static bool deleteMusicType(int id)
        {
            using (OLMSDBEntities oLMSDB = new OLMSDBEntities())
            {
                var gener = oLMSDB.Genres.FirstOrDefault(t => t.GenreId == id);
                oLMSDB.Genres.Remove(gener);
                return oLMSDB.SaveChanges() > 0;
            }

        }

        public static bool updateMusicType(int id, string name, string detail)
        {
            using (OLMSDBEntities oLMSDB = new OLMSDBEntities())
            {
                var genres = oLMSDB.Genres.FirstOrDefault(t => t.GenreId == id);
                genres.Name = name;
                genres.Description = detail;
                return oLMSDB.SaveChanges() > 0;
            }
        }
    }
}
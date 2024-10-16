using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AnnouncementManager : IGenericService<Announcement>


    {
        IAnnouncementDal _announcement;

        public AnnouncementManager(IAnnouncementDal announcement)
        {
            _announcement = announcement;
        }

        public void TAdd(Announcement t)
        {
            _announcement.Insert(t);
        }

        public void TDelete(Announcement t)
        {
            _announcement.Delete(t);
        }

 
        public List<Announcement> TGetbyFilter(string p)
        {
            throw new NotImplementedException();
        }

        public Announcement TGetById(int id)
        {
           return _announcement.GetById(id);
        }

        public List<Announcement> TGetList()
        {
           return _announcement.GetList();
        }

        public void TUpdate(Announcement t)
        {
            _announcement.Update(t);
        }
    }
}

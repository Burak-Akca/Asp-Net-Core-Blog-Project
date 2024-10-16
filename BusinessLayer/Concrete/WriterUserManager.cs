
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
    public class WriterUserManager : IGenericService<WriterUser>
    {
        IWriterUserDal _writerUser;

        public WriterUserManager(IWriterUserDal writerUser)
        {
            _writerUser = writerUser;
        }

        public void TAdd(WriterUser t)
        {
            _writerUser.Insert(t);
        }

        public void TDelete(WriterUser t)
        {
            _writerUser.Delete(t);
        }

        public List<WriterUser> TGetbyFilter(string p)
        {
            throw new NotImplementedException();
        }

        public WriterUser TGetById(int id)
        {
           return _writerUser.GetById(id);
        }

        public List<WriterUser> TGetList()
        {
            return _writerUser.GetList();
        }

        public void TUpdate(WriterUser t)
        {
            _writerUser.Update(t);
        }
    }
}

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
    public class WriterMessageManager : IWriterMessageService

    {
        IWriterMessageDal _writerMessage;

        public WriterMessageManager(IWriterMessageDal writerMessage)
        {
            _writerMessage = writerMessage;
        }

        public List<WriterMessage> GetListReceiverMessages(string p)
        {
                return _writerMessage.GetbyFilter(x => x.Receiver == p);
        }

        public List<WriterMessage> GetListSenderMessages(string p)
        {
                return _writerMessage.GetbyFilter(x => x.Sender == p);
        }

        public void TAdd(WriterMessage t)
        {
            _writerMessage.Insert(t);
        }

        public void TDelete(WriterMessage t)
        {
            _writerMessage.Delete(t);
        }

        public List<WriterMessage> TGetbyFilter(string p)
        {
            throw new NotImplementedException();
        }




        public WriterMessage TGetById(int id)
        {
            return _writerMessage.GetById(id);
        }

        public List<WriterMessage> TGetList()
        {
            return _writerMessage.GetList();
        }

        public void TUpdate(WriterMessage t)
        {
            _writerMessage.Update(t);
        }
    }
}

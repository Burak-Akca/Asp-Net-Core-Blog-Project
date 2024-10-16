﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class TestimonialManager : IGenericService<Testimonial>
    {
        ITestimonialDal _testimonialDal;

        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public void TAdd(Testimonial t)
        {
            _testimonialDal.Insert(t);
        }

        public void TDelete(Testimonial t)
        {
              _testimonialDal.Delete(t);    
            }

        

        public List<Testimonial> TGetbyFilter(string p)
        {
            throw new NotImplementedException();
        }

        public Testimonial TGetById(int id)
        {
          return  _testimonialDal.GetById(id);
        }

        public List<Testimonial> TGetList()
        {
           return _testimonialDal.GetList();
            }

        public void TUpdate(Testimonial t)
        {
            _testimonialDal.Update(t);  
        }
    }
}

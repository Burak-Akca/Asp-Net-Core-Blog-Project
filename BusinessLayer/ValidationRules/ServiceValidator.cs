using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class ServiceValidator:AbstractValidator<Service>
	{
		public ServiceValidator()
		{
            RuleFor(x => x.Title).NotEmpty().WithMessage("Proje adı boş geçilemez");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Görsel alanı boş geçilemez");
            
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Hizmet adı en az 5 karakterden oluşmalı");
            RuleFor(x => x.Title).MaximumLength(100).WithMessage("Hizmet adı en fazla 100 karakterden oluşmalı");

        }
	}
}

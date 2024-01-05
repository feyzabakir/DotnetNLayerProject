using DotnetNLayerProject.Core.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetNLayerProject.Service.Validations
{
    public class BlogDtoValidator : AbstractValidator<Blog>
    {
        public BlogDtoValidator() 
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog başlığı boş olamaz.")
                .NotNull().WithMessage("Blog başlığı null olamaz."); 

            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog içeriği boş olamaz.")
                .NotNull().WithMessage("Blog içeriği null olamaz.");
        }
    }
}

using DotnetNLayerProject.Core.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetNLayerProject.Service.Validations
{
    public class CategoryDtoValidator : AbstractValidator<Category>
    {
        public CategoryDtoValidator() 
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adı boş olamaz")
                  .NotNull().WithMessage("Kategori adı null olamaz.");
        }
    }
}

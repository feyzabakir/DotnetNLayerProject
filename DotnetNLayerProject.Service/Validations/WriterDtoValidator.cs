using DotnetNLayerProject.Core.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetNLayerProject.Service.Validations
{
    public class WriterDtoValidator : AbstractValidator<Writer>
    {
        public WriterDtoValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı boş olamaz.").NotNull().WithMessage("Yazar adı null olamaz.");

            RuleFor(x => x.WriterMail).NotEmpty().EmailAddress().WithMessage("Geçeri bir mail adresi giriniz.");

            RuleFor(x => x.WriterPassword).NotEmpty().MinimumLength(6).WithMessage("Şifre en az 6 karakter uzunluğunda olmalı.");
        }
    }
}

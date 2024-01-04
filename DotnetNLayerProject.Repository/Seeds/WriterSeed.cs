using DotnetNLayerProject.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetNLayerProject.Repository.Seeds
{
    public class WriterSeed : IEntityTypeConfiguration<Writer>
    {
        public void Configure(EntityTypeBuilder<Writer> builder)
        {
            builder.HasData(
                new Writer
                {
                    Id = 1,
                    WriterName = "Feyza Bakır",
                    WriterMail = "feyza@gmail.com",
                    WriterPassword = "feyza123",
                    CreatedDate = DateTime.Now,
                },
                new Writer
                {
                    Id = 2,
                    WriterName = "Ayşe Çınar",
                    WriterMail = "aysecinar@gmail.com",
                    WriterPassword = "ayse123",
                    CreatedDate = DateTime.Now
                },
                new Writer
                {
                    Id=3,
                    WriterName = "Ali Yılmaz",
                    WriterMail = "aliyilmaz@gmail.com",
                    WriterPassword = "ali123",
                    CreatedDate= DateTime.Now,
                }

                );
        }
    }
}

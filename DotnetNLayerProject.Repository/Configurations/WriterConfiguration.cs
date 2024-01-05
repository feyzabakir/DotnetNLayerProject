using DotnetNLayerProject.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetNLayerProject.Repository.Configurations
{
    public class WriterConfiguration : IEntityTypeConfiguration<Writer>
    {
        public void Configure(EntityTypeBuilder<Writer> builder)
        {
            builder.HasKey(x => x.Id); //PK

            builder.Property(x => x.Id) //1-1 artma
                  .UseIdentityColumn();

            builder.Property(x => x.WriterName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.WriterMail).HasMaxLength(250).IsRequired();
         //   builder.Property(x => x.WriterPassword).IsRequired().HasMaxLength(250);
        }
    }
}

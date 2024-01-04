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
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {

            builder.HasKey(x => x.Id); // Primary Key

            builder.Property(t => t.Id)  //Pk 1-1 arttırma işlemi
              .UseIdentityColumn();

            builder.Property(x => x.BlogTitle)
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(x => x.BlogContent)
            .IsRequired();
        }
    }
}

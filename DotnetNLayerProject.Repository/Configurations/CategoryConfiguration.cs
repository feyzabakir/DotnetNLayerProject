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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id); //PK

            builder.Property(x => x.Id) //1-1 artma
                  .UseIdentityColumn();

            builder.Property(x => x.CategoryName).IsRequired().HasMaxLength(50);
        }
    }
}

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
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category
                {
                    Id = 1,
                    CategoryName = "Teknoloji",
                    CreatedDate = DateTime.Now,
                },
                new Category
                {
                    Id= 2,
                    CategoryName = "Yazılım",
                    CreatedDate = DateTime.Now,
                },
                new Category
                {
                    Id = 3,
                    CategoryName = "Trendler",
                    CreatedDate = DateTime.Now,
                }

                );
        }
    }
}

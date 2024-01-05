using AutoMapper;
using DotnetNLayerProject.Core.DTOs;
using DotnetNLayerProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetNLayerProject.Service.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            // entity'den dto çevirme
            CreateMap<Blog,BlogDto>().ReverseMap();
            CreateMap<Category,CategoryDto>().ReverseMap();
            CreateMap<Writer,WriterDto>().ReverseMap();

            //dto'dan entity'e çevirme
            CreateMap<BlogDto, Blog>();
            CreateMap<CategoryDto, Category>();
            CreateMap<WriterDto, Writer>();
        }
    }
}

using AutoMapper;
using DotnetNLayerProject.Core.DTOs;
using DotnetNLayerProject.Core.Models;
using DotnetNLayerProject.Core.Services;
using DotnetNLayerProject.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotnetNLayerProject.API.Controllers
{
    public class BlogsController : CustomBasesController
    {
        private readonly IMapper _mapper;
        private readonly IBlogService _blogService;

        public BlogsController(IMapper mapper, IBlogService blogService)
        {
            _mapper = mapper;
            _blogService = blogService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var blogs = await _blogService.GetAllAsync();
            var blogsDto = _mapper.Map<List<BlogDto>>(blogs.ToList());
            return CreateActionResult(GlobalResultDto<List<BlogDto>>.Success(200, blogsDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blog = await _blogService.GetById(id);
            var blogDto = _mapper.Map<BlogDto>(blog);
            return CreateActionResult(GlobalResultDto<BlogDto>.Success(200, blogDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(BlogDto blogDto)
        {
            var blog = await _blogService.AddAsync(_mapper.Map<Blog>(blogDto));
            var teamDtos = _mapper.Map<BlogDto>(blog);
            return CreateActionResult(GlobalResultDto<BlogDto>.Success(201, blogDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(BlogDto blogDto)
        {
            await _blogService.UpdateAsync(_mapper.Map<Blog>(blogDto));
            return CreateActionResult(GlobalResultDto<NoContentDto>.Success(204));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var blog = await _blogService.GetById(id);
            await _blogService.RemoveAsync(blog);
            return CreateActionResult(GlobalResultDto<NoContentDto>.Success(204));
        }
    }
}

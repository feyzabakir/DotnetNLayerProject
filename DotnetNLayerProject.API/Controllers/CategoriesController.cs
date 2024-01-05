using AutoMapper;
using DotnetNLayerProject.Core.DTOs;
using DotnetNLayerProject.Core.Models;
using DotnetNLayerProject.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotnetNLayerProject.API.Controllers
{
    public class CategoriesController : CustomBasesController
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public CategoriesController(IMapper mapper, ICategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var category = await _categoryService.GetAllAsync();
            var categoryDto = _mapper.Map<List<CategoryDto>>(category.ToList());
            return CreateActionResult(GlobalResultDto<List<CategoryDto>>.Success(200, categoryDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetById(id);
            var categoryDto = _mapper.Map<CategoryDto>(category);
            return CreateActionResult(GlobalResultDto<CategoryDto>.Success(200, categoryDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CategoryDto categoryDto)
        {
            var category = await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));
            var categoryDto1 = _mapper.Map<CategoryDto>(category);
            return CreateActionResult(GlobalResultDto<CategoryDto>.Success(201, categoryDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            await _categoryService.UpdateAsync(_mapper.Map<Category>(categoryDto));
            return CreateActionResult(GlobalResultDto<NoContentDto>.Success(204));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var category = await _categoryService.GetById(id);
            await _categoryService.RemoveAsync(category);
            return CreateActionResult(GlobalResultDto<NoContentDto>.Success(204));
        }
    }
}

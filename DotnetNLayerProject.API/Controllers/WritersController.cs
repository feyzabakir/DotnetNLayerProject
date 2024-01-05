using AutoMapper;
using DotnetNLayerProject.Core.DTOs;
using DotnetNLayerProject.Core.Models;
using DotnetNLayerProject.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotnetNLayerProject.API.Controllers
{
    public class WritersController : CustomBasesController
    {
        private readonly IMapper _mapper;
        private readonly IWriterService _writerService;

        public WritersController(IMapper mapper, IWriterService writerService)
        {
            _mapper = mapper;
            _writerService = writerService;
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var writers = await _writerService.GetAllAsync();
            var writersDto = _mapper.Map<List<WriterDto>>(writers.ToList());
            return CreateActionResult(GlobalResultDto<List<WriterDto>>.Success(200, writersDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var writer = await _writerService.GetById(id);
            var writerDto = _mapper.Map<WriterDto>(writer);
            return CreateActionResult(GlobalResultDto<WriterDto>.Success(200, writerDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(WriterDto writerDto)
        {
            await _writerService.UpdateAsync(_mapper.Map<Writer>(writerDto));
            return CreateActionResult(GlobalResultDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var writer = await _writerService.GetById(id);
            await _writerService.RemoveAsync(writer);

            return CreateActionResult(GlobalResultDto<NoContentDto>.Success(204));
        }

        [HttpPost]
        public async Task<IActionResult> Save(WriterDto writerDto)
        {
            var writer = await _writerService.AddAsync(_mapper.Map<Writer>(writerDto));
            var writerrDtos = _mapper.Map<WriterDto>(writer);
            return CreateActionResult(GlobalResultDto<WriterDto>.Success(201, writerrDtos));
        }
    }
}

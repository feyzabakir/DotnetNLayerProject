using DotnetNLayerProject.Core.DTOs;
using DotnetNLayerProject.Core.DTOs.Authentication;
using DotnetNLayerProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetNLayerProject.Core.Services
{
    public interface IWriterService : IService<Writer>
    {
        string GeneratePasswordHash(string writerName, string password);
        WriterDto FindUser(string writerName, string password);
        AuthResponseDto Login(AuthRequestDto request);
        Writer SignUp(AuthRequestDto authDto);
    }
}

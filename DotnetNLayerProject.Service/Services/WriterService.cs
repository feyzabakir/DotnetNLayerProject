using AutoMapper;
using DotnetNLayerProject.Core.DTOs;
using DotnetNLayerProject.Core.DTOs.Authentication;
using DotnetNLayerProject.Core.Models;
using DotnetNLayerProject.Core.Repositories;
using DotnetNLayerProject.Core.Services;
using DotnetNLayerProject.Core.UnitOfWorks;
using DotnetNLayerProject.Service.Authorization.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DotnetNLayerProject.Service.Services
{
    public class WriterService : Service<Writer>, IWriterService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Writer> _repository;
        private readonly IWriterRepository _writerRepository;
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;

        public WriterService(IGenericRepository<Writer> repository, IUnitOfWork unitOfWork, IMapper mapper, IJwtAuthenticationManager jwtAuthenticationManager,
            IWriterRepository writerRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _jwtAuthenticationManager = jwtAuthenticationManager;
            _writerRepository = writerRepository;
        }

        public string GeneratePasswordHash(string writerName, string password)
        {
            if (string.IsNullOrEmpty(writerName))
            {
                throw new ArgumentNullException(nameof(writerName));
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(writerName));
            }

            byte[] writerBytes = Encoding.UTF8.GetBytes(writerName);
            string writerByteString = Convert.ToBase64String(writerBytes);
            string smallByteString = $"{writerByteString.Take(2)}.{writerByteString.Reverse().Take(2)}";
            byte[] smallBytes = Encoding.UTF8.GetBytes(smallByteString);
            byte[] passBytes = Encoding.UTF8.GetBytes(password);

            byte[] hashed = this.GenerateSaltedHash(passBytes, smallBytes);

            return Convert.ToBase64String(hashed);
        }

        private byte[] GenerateSaltedHash(byte[] plainText, byte[] salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes =
              new byte[plainText.Length + salt.Length];

            for (int i = 0; i < plainText.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainText[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[plainText.Length + i] = salt[i];
            }

            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }

        public WriterDto FindUser(string writerName, string password)
        {
            string passHashed = GeneratePasswordHash(writerName, password);
            var writer = _repository.Where(x => x.WriterName == writerName && x.WriterPassword == passHashed).FirstOrDefault();
            var writerDto = _mapper.Map<WriterDto>(writer);
            return writerDto;
        }

        public AuthResponseDto Login(AuthRequestDto request)
        {
            AuthResponseDto responseDto = new AuthResponseDto();
            WriterDto writer = FindUser(request.WriterName, request.WriterPassword);
            responseDto = _jwtAuthenticationManager.Authenticate(request.WriterName, request.WriterPassword);
            responseDto.Writer = writer;

            return responseDto;
        }

        public Writer SignUp(AuthRequestDto authDto)
        {
            #region Password'un hashli halini veri tabanına göndermek için güncelleme yap
            var passwordHash = GeneratePasswordHash(authDto.WriterName, authDto.WriterPassword);
            #endregion

            var writer = AddAsync(new Core.Models.Writer
            {
                WriterMail = authDto.WriterMail,
                WriterPassword = passwordHash,
                WriterName = authDto.WriterName,
            });
            return writer.Result;
        }
    }
}

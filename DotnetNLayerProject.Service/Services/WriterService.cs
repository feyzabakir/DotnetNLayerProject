using DotnetNLayerProject.Core.Models;
using DotnetNLayerProject.Core.Repositories;
using DotnetNLayerProject.Core.Services;
using DotnetNLayerProject.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetNLayerProject.Service.Services
{
    public class WriterService : Service<Writer>, IWriterService
    {
        public WriterService(IGenericRepository<Writer> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}

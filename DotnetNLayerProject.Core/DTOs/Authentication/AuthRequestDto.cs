using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetNLayerProject.Core.DTOs.Authentication
{
    public class AuthRequestDto
    {
        public string WriterMail { get; set; }
        public string WriterName { get; set; }
        public string WriterPassword { get; set; }
    }
}

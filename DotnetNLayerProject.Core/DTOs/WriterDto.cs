using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DotnetNLayerProject.Core.DTOs
{
    public class WriterDto:BaseDto
    {
        public string WriterName { get; set; }
        public string WriterMail { get; set; }
    }
}

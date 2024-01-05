using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetNLayerProject.Core.DTOs
{
    public class BlogDto:BaseDto
    {
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }

        public int WriterID { get; set; }    
        public int CategoryID { get; set; }
    }
}

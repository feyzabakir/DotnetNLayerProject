using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetNLayerProject.Core.Models
{
    public class Writer : BaseEntity
    {
        public string WriterName { get; set; }
        public string WriterMail { get; set; }
        public string WriterPassword { get; set; }

        public ICollection<Blog> Blogs { get; set; }   //navigation property
    }
}

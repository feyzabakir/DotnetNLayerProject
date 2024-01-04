using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetNLayerProject.Core.Models
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }

        public ICollection<Blog> Blogs { get; set; }   //navigation property
    }
}

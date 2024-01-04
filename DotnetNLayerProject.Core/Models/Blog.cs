using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetNLayerProject.Core.Models
{
    public class Blog : BaseEntity
    {
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }

        public int CategoryID { get; set; }       //Foreign Key
        public Category Category { get; set; }   // Navigation property

        public int WriterID { get; set; }        //Foreign Key
        public Writer Writer { get; set; }      // Navigation property
    }
}

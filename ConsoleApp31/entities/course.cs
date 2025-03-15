using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp31.entities
{
    internal class course
    {
        public int id {  get; set; }
        public string name { get; set; }
        public string? description { get; set; }
        public int? duration { get; set; }
        //public ICollection<stcourse> stcourses { get; set; }   =new HashSet<stcourse>();
        [ForeignKey(nameof(topic))]
        public int ? topic_id { get; set; }
        public topic topic { get; set; }
        //public ICollection<instcourse> instcourses { get; set; } = new HashSet<instcourse>();
    }
}

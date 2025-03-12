using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp31.entities
{
    internal class student
    {
        public int id { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public int age { get; set; }
        public string address { get; set; }
        public ICollection<stcourse> stcourses { get; set; }= new HashSet<stcourse>();
        [ForeignKey(nameof(department))]
        
        public int? dept_id { get; set; }
        public department department { get; set; }

    }
}

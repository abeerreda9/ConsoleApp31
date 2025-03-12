using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp31.entities
{
    internal class instructor
    {
        public int id {  get; set; }
        public string name { get; set; }
        public decimal salary { get; set; }
        public decimal bouns { get; set; }
        public decimal hourrate { get; set; }
        public string? address { get; set; }
        public ICollection<instcourse> instructors { get; set; }=new HashSet<instcourse>();
        [InverseProperty(nameof(department.manager))]
        public department instructordept { get; set; }

        public int? dept_id { get; set; }
        [InverseProperty(nameof(department.instructors))]
        public department workdept { get; set; }
    }
}

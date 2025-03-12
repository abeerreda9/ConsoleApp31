using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp31.entities
{
    internal class department
    {
        public int id {  get; set; }
        public string name { get; set; }
        public int hirigdate { get; set; }
        public ICollection<student> students { get; set; } = new HashSet<student>();
        [ForeignKey(nameof(manager))]
        public int? ins_id { get; set; }
        [InverseProperty(nameof(instructor.instructordept))]
        public instructor manager { get; set; }
        [InverseProperty(nameof(instructor.workdept))]
        public ICollection<instructor> instructors { get; set; }= new HashSet<instructor>();
    }
}

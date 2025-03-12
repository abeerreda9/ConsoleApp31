using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp31.entities
{
    internal class topic
    {
        public int id {  get; set; }
        public string name { get; set; }
        public ICollection<course> course { get; set; } = new HashSet<course>();
    }
}

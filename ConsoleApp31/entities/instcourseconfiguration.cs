using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp31.entities
{
    internal class instcourseconfiguration : IEntityTypeConfiguration<instcourse>
    {
        public void Configure(EntityTypeBuilder<instcourse> builder)
        {
            builder.HasKey(ic=>new {ic.ins_id,ic.crs_id});
        }
    }
}

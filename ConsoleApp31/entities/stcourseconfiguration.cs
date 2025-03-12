using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp31.entities
{
    internal class stcourseconfiguration : IEntityTypeConfiguration<stcourse>
    {
        public void Configure(EntityTypeBuilder<stcourse> builder)
        {
            builder.HasKey(sc => new {sc.st_id,sc.crs_id});
        }
    }
}

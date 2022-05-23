using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            #region Id

            builder
                .HasKey(t => t.Id);

            #endregion

            builder
                .Property(t => t.Title)
                .IsRequired();

            builder
               .ToTable("Assignments");
        }
    }
}

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
                .HasKey(a => a.Id);

            #endregion

            builder
                .Property(a => a.Title)
                .IsRequired();

            builder
                .HasOne(a => a.Organization)
                .WithMany(o => o.Assignments)
                .HasForeignKey(a => a.OrganizationId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
               .ToTable("Assignments");
        }
    }
}

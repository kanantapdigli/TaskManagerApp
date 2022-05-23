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
    public class StaffConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            #region Id

            builder
                .HasKey(s => s.Id);

            #endregion

            builder
                .Property(s => s.Fullname)
                .IsRequired();

            builder
                .HasOne(s => s.Organization)
                .WithMany(o => o.Staffs)
                .HasForeignKey(s => s.OrganizationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .ToTable("Staffs");
        }
    }
}

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
    public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            #region Id

            builder
                .HasKey(o => o.Id);

            builder
                .Property(o => o.Id)
                .UseIdentityColumn();

            #endregion

            builder
                .Property(o => o.Name)
                .IsRequired();

            builder
               .Property(o => o.Address)
               .IsRequired();

            builder
              .Property(o => o.PhoneNumber)
              .IsRequired();


            builder
                .HasOne(o => o.Owner)
                .WithOne(u => u.Organization)
                .HasForeignKey<Organization>(o => o.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
               .ToTable("Organizations");
        }
    }
}

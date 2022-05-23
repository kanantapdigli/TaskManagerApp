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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            #region Id

            builder
                .HasKey(u => u.Id);

            #endregion

            #region Fullname

            builder
                .Property(u => u.Fullname)
                .IsRequired()
                .HasMaxLength(20);

            #endregion

            builder
                .ToTable("Users");
        }
    }
}

﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Infrastructure.Configuration
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasColumnName("firstname")
                .HasMaxLength(20);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasColumnName("lastname")
                .HasMaxLength(20);

            builder.Property(e => e.MiddleName)
                .HasColumnName("middlename")
                .HasMaxLength(20);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasColumnName("email")
                .HasMaxLength(40);

            builder.Property(e => e.Password)
                .IsRequired()
                .HasColumnName("password")
                .HasMaxLength(32);
        }       
    }
}

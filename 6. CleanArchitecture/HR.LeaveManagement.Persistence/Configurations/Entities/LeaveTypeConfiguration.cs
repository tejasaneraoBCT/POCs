﻿using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Persistence.Configurations.Entities
{
    public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
            builder.HasData(
                new LeaveType
                {
                    Id = 1,
                    DefaultDays = 5,
                    Name = "Casual",
                    CreatedBy = null,
                    LastModifiedBy= null,
                },
                new LeaveType
                {
                    Id = 2,
                    DefaultDays = 18,
                    Name = "Privilege",
                    CreatedBy = null,
                    LastModifiedBy = null,
                }
            );
        }
    }
}

﻿using Hastane.Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane.DataAccess.EntityFramework.Mapping
{
    public class BaseEntityTypeConfig<T>:IEntityTypeConfiguration<T> where T :class,IBaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.CreatedTime).IsRequired(true);
            builder.Property(x => x.DeletedTime).IsRequired(false);
            builder.Property(x => x.UpdatedTime).IsRequired(false);
            builder.Property(x => x.Status).IsRequired(true);
        }
    }
}

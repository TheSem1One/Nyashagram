﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auth.Infrastructure.Persistence
{
    public class Modelcontext(DbContextOptions<Modelcontext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

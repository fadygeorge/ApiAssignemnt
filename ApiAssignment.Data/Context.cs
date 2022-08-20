using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiAssignment.Data
{
    public class Context : IdentityDbContext
    {
        public Context(DbContextOptions options) : base(options) { }
        public DbSet<Student> Students { get; set; }
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Models;

namespace UserManagement.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<user> user { get; set; }
        public DbSet<Flights> Flights { get; set; }
        public DbSet<Bookings> Bookings { get; set; }
        public DbSet<Passengers> Passengers { get; set; }
    }
}

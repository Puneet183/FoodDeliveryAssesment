using DeliveryService.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DeliveryService.Data
{
    public class DeliveryDbContext : DbContext
    {
        public DeliveryDbContext(DbContextOptions<DeliveryDbContext> options) : base(options) { }

        public DbSet<DeliveryPartner> DeliveryPartners { get; set; }
    }
}

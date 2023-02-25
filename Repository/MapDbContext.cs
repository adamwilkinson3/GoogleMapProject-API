using System;
using System.Collections.Generic;
using ApiMap.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiMap.Repository;

public partial class MapDbContext : DbContext
{
    public MapDbContext()
    {
    }

    public MapDbContext(DbContextOptions<MapDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Mapaddress> Mapaddress { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseCosmos(
            "https://azurefreedb.documents.azure.com:443/",
            "5HHcWwnfUpSvcAuk5Ua8qHhPESNgVxMMFP7H6lqtNGDnFPkOJkOsRb5bPlg3C6HFb39yUAMsv7GCACDbUV4PjQ==",
            databaseName: "azurefreedb");


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Mapaddress>()
            .ToContainer("MapAddress") // ToContainer
            .HasPartitionKey(e => e.Id) // Partition Key
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();
    }

    //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

﻿using Microsoft.EntityFrameworkCore;

internal class DataBase : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-767JKC3;Initial Catalog=master;Integrated Security=True;Trust Server Certificate=True");
    }

    public DbSet<Flowers> Flowers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Flowers>().HasKey(flower => flower.FlowerName);
    }
}

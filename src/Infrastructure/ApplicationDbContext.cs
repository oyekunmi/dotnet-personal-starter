﻿using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<ProductItem> ProductItems { get; set; } = null!;

}
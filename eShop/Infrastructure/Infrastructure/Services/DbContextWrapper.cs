﻿using Infrastructure.Services.Interfaces;

namespace Infrastructure.Services;

public class DbContextWrapper<T> : IDbContextWrapper<T>
    where T : DbContext
{
    public DbContextWrapper(
        IDbContextFactory<T> dbContextFactory)
    {
        DbContext = dbContextFactory.CreateDbContext();
    }

    public T DbContext { get; }

    public IDbContextTransaction BeginTransaction()
    {
        return DbContext.Database.BeginTransaction();
    }
}

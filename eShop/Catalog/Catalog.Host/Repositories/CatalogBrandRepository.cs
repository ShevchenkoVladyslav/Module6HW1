﻿using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;

namespace Catalog.Host.Repositories;

public class CatalogBrandRepository : ICatalogBrandRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<CatalogProductRepository> _logger;

    public CatalogBrandRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<CatalogProductRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public async Task<PaginatedItems<CatalogBrand>?> GetByPageAsync(int pageIndex, int pageSize)
    {
        var totalItems = await _dbContext.CatalogBrands
            .LongCountAsync();

        var itemsOnPage = await _dbContext.CatalogBrands
            .OrderBy(ci => ci.Brand)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedItems<CatalogBrand>() { TotalCount = totalItems, Data = itemsOnPage };
    }

    public async Task<IEnumerable<CatalogBrand>?> GetBrandsAsync()
    {
        var items = await _dbContext.CatalogBrands
            .OrderBy(cb => cb.Brand)
            .ToListAsync();

        return items;
    }

    public async Task<CatalogBrand?> GetByIdAsync(int id)
    {
        var result = await _dbContext.CatalogBrands
            .SingleOrDefaultAsync(cb => cb.Id == id);

        return result;
    }

    public async Task<CatalogBrand?> GetByBrandAsync(string brand)
    {
        var result = await _dbContext.CatalogBrands
            .SingleOrDefaultAsync(cb => cb.Brand == brand);

        return result;
    }

    public async Task<int?> AddAsync(string brand)
    {
        var item = await _dbContext.CatalogBrands.AddAsync(new CatalogBrand
        {
            Brand = brand,
        });

        await _dbContext.SaveChangesAsync();

        return item.Entity.Id;
    }

    public async Task<int?> RemoveAsync(int id)
    {
        var item = await _dbContext.CatalogBrands.SingleOrDefaultAsync(cb => cb.Id == id) ?? throw new NullReferenceException();

        _dbContext.CatalogBrands.Remove(item);

        await _dbContext.SaveChangesAsync();

        return item.Id;
    }

    public async Task<int?> RemoveByTitleAsync(string brand)
    {
        var item = await _dbContext.CatalogBrands.SingleOrDefaultAsync(cb => cb.Brand == brand) ?? throw new NullReferenceException();

        _dbContext.CatalogBrands.Remove(item);

        await _dbContext.SaveChangesAsync();

        return item.Id;
    }

    public async Task<int?> UpdateAsync(int id, string brand)
    {
        var item = await _dbContext.CatalogBrands.SingleOrDefaultAsync(cb => cb.Id == id) ?? throw new NullReferenceException();

        item.Brand = brand;

        _dbContext.CatalogBrands.Update(item);

        await _dbContext.SaveChangesAsync();

        return item.Id;
    }
}

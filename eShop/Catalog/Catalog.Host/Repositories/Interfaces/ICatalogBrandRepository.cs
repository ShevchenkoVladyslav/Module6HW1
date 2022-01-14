﻿using Catalog.Host.Data;
using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogBrandRepository
{
    Task<int?> AddAsync(string brand);
    Task<int?> RemoveAsync(int id);
    Task<int?> RemoveByTitleAsync(string brand);
    Task<int?> UpdateAsync(int id, string brand);
    Task<CatalogBrand?> GetByBrandTitleAsync(string brand);
    Task<CatalogBrand?> GetByBrandIdAsync(int id);
    Task<IEnumerable<CatalogBrand>?> GetBrandsAsync();
    Task<PaginatedItems<CatalogBrand>?> GetByPageAsync(int pageIndex, int pageSize);
}

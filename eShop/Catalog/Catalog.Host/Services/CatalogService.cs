﻿using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Responses;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogService : BaseDataService<ApplicationDbContext>, ICatalogService
{
    private readonly ICatalogBrandRepository _catalogBrandRepository;
    private readonly ICatalogProductRepository _catalogProductRepository;
    private readonly ICatalogTypeRepository _catalogTypeRepository;
    private readonly IMapper _mapper;

    public CatalogService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        IMapper mapper,
        ICatalogBrandRepository catalogBrandRepository,
        ICatalogProductRepository catalogProductRepository,
        ICatalogTypeRepository catalogTypeRepository)
        : base(dbContextWrapper, logger)
    {
        _catalogBrandRepository = catalogBrandRepository;
        _catalogProductRepository = catalogProductRepository;
        _catalogTypeRepository = catalogTypeRepository;
        _mapper = mapper;
    }

    public async Task<CatalogProductDto?> GetProductByIdAsync(int id)
    {
        return await ExecuteSafe(async () =>
        {
            var result = await _catalogProductRepository.GetByIdAsync(id);

            if (result == null)
            {
                return null;
            }

            return _mapper.Map<CatalogProductDto>(result);
        });
    }

    public async Task<IEnumerable<CatalogProductDto>?> GetProductsAsync()
    {
        return await ExecuteSafe(async () =>
        {
            var result = await _catalogProductRepository.GetProductsAsync();

            if (result == null)
            {
                return null;
            }

            return _mapper.Map<IEnumerable<CatalogProductDto>?>(result);
        });
    }

    public async Task<PaginatedItemsResponse<CatalogProductDto>?> GetProductsByPageAsync(int pageSize, int pageIndex)
    {
        return await ExecuteSafe(async () =>
        {
            var result = await _catalogProductRepository.GetByPageAsync(pageIndex, pageSize);

            if (result == null)
            {
                return null;
            }

            return new PaginatedItemsResponse<CatalogProductDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(cp => _mapper.Map<CatalogProductDto>(cp)).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize,
            };
        });
    }

    public async Task<PaginatedItemsResponse<CatalogProductDto>?> GetProductsByBrandIdAsync(int id, int pageSize, int pageIndex)
    {
        return await ExecuteSafe(async () =>
        {
            var result = await _catalogProductRepository.GetByBrandIdAsync(id, pageIndex, pageSize);

            if (result == null)
            {
                return null;
            }

            return new PaginatedItemsResponse<CatalogProductDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(cp => _mapper.Map<CatalogProductDto>(cp)).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize,
            };
        });
    }

    public async Task<PaginatedItemsResponse<CatalogProductDto>?> GetProductsByBrandTitleAsync(string brand, int pageSize, int pageIndex)
    {
        return await ExecuteSafe(async () =>
        {
            var result = await _catalogProductRepository.GetByBrandTitleAsync(brand, pageIndex, pageSize);

            if (result == null)
            {
                return null;
            }

            return new PaginatedItemsResponse<CatalogProductDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(cp => _mapper.Map<CatalogProductDto>(cp)).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize,
            };
        });
    }

    public async Task<PaginatedItemsResponse<CatalogProductDto>?> GetProductsByTypeIdAsync(int id, int pageSize, int pageIndex)
    {
        return await ExecuteSafe(async () =>
        {
            var result = await _catalogProductRepository.GetByTypeIdAsync(id, pageIndex, pageSize);

            if (result == null)
            {
                return null;
            }

            return new PaginatedItemsResponse<CatalogProductDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(cp => _mapper.Map<CatalogProductDto>(cp)).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize,
            };
        });
    }

    public async Task<PaginatedItemsResponse<CatalogProductDto>?> GetProductsByTypeTitleAsync(string type, int pageSize, int pageIndex)
    {
        return await ExecuteSafe(async () =>
        {
            var result = await _catalogProductRepository.GetByTypeTitleAsync(type, pageIndex, pageSize);

            if (result == null)
            {
                return null;
            }

            return new PaginatedItemsResponse<CatalogProductDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(cp => _mapper.Map<CatalogProductDto>(cp)).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize,
            };
        });
    }

    public async Task<IEnumerable<CatalogBrandDto>?> GetBrandsAsync()
    {
        return await ExecuteSafe(async () =>
        {
            var result = await _catalogBrandRepository.GetBrandsAsync();

            if (result == null)
            {
                return null;
            }

            return _mapper.Map<IEnumerable<CatalogBrandDto>?>(result);
        });
    }

    public async Task<PaginatedItemsResponse<CatalogBrandDto>?> GetBrandsByPageAsync(int pageSize, int pageIndex)
    {
        return await ExecuteSafe(async () =>
        {
            var result = await _catalogBrandRepository.GetByPageAsync(pageIndex, pageSize);

            if (result == null)
            {
                return null;
            }

            return new PaginatedItemsResponse<CatalogBrandDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(cp => _mapper.Map<CatalogBrandDto>(cp)).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize,
            };
        });
    }

    public async Task<IEnumerable<CatalogTypeDto>?> GetTypesAsync()
    {
        return await ExecuteSafe(async () =>
        {
            var result = await _catalogTypeRepository.GetTypesAsync();

            if (result == null)
            {
                return null;
            }

            return _mapper.Map<IEnumerable<CatalogTypeDto>?>(result);
        });
    }

    public async Task<PaginatedItemsResponse<CatalogTypeDto>?> GetTypesByPageAsync(int pageSize, int pageIndex)
    {
        return await ExecuteSafe(async () =>
        {
            var result = await _catalogTypeRepository.GetByPageAsync(pageIndex, pageSize);

            if (result == null)
            {
                return null;
            }

            return new PaginatedItemsResponse<CatalogTypeDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(cp => _mapper.Map<CatalogTypeDto>(cp)).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize,
            };
        });
    }
}

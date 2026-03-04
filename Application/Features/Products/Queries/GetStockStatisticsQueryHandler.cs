using BlazorApp1.Models.CrudModels;
using BlazorApp1.Models.Entities.DBCRUD;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Application.Features.Products.Queries;

public class GetStockStatisticsQueryHandler
    : IRequestHandler<GetStockStatisticsQuery, List<ProductModel>>
{
    private readonly DbContextCrud _context;

    public GetStockStatisticsQueryHandler(DbContextCrud context)
    {
        _context = context;
    }

    public async Task<List<ProductModel>> Handle(
        GetStockStatisticsQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.Products
            .Select(p => new ProductModel
            {
                Name = p.Name,
                Stock = p.Stock
            })
            .ToListAsync(cancellationToken);
    }
}
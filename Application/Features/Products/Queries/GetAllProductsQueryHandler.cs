using MediatR;
using Microsoft.EntityFrameworkCore;
using BlazorApp1.Models.CrudModels;
using BlazorApp1.Models.Entities.DBCRUD;

namespace BlazorApp1.Application.Features.Products.Queries;

public class GetAllProductsQueryHandler 
    : IRequestHandler<GetAllProductsQuery, List<ProductModel>>
{
    private readonly DbContextCrud _context;

    public GetAllProductsQueryHandler(DbContextCrud context)
    {
        _context = context;
    }

    public async Task<List<ProductModel>> Handle(
        GetAllProductsQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.Products
            .Select(p => new ProductModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock,
                CategoryId = p.CategoryId,
                CreatedAt = p.CreatedAt
            })
            .ToListAsync(cancellationToken);
    }
}
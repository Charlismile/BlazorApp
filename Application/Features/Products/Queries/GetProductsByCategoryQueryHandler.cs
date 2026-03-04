using BlazorApp1.Models.CrudModels;
using BlazorApp1.Models.Entities.DBCRUD;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Application.Features.Products.Queries;

public class GetProductsByCategoryQueryHandler
    : IRequestHandler<GetProductsByCategoryQuery, List<CategoryModel>>
{
    private readonly DbContextCrud _context;

    public GetProductsByCategoryQueryHandler(DbContextCrud context)
    {
        _context = context;
    }

    public async Task<List<CategoryModel>> Handle(
        GetProductsByCategoryQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.Products
            .GroupBy(p => p.CategoryId)
            .Select(g => new CategoryModel
            {
                CategoryId = g.Key,
                Count = g.Count()
            })
            .ToListAsync(cancellationToken);
    }
}
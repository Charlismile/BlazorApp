using BlazorApp1.Models;
using BlazorApp1.Models.Entities.DBCRUD;
using MediatR;
using ProductEntity = BlazorApp1.Models.Entities.DBCRUD.Products;

namespace BlazorApp1.Application.Features.Products.Commands;

public class CreateProductCommandHandler 
    : IRequestHandler<CreateProductCommand, Result<int>>
{
    private readonly DbContextCrud _context;

    public CreateProductCommandHandler(DbContextCrud context)
    {
        _context = context;
    }

    public async Task<Result<int>> Handle(
        CreateProductCommand request,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            return Result<int>.Fail("El nombre es obligatorio.");

        if (request.Price <= 0)
            return Result<int>.Fail("El precio debe ser mayor que cero.");
        
        var entity = new ProductEntity
        {
            Name = request.Name,
            Price = request.Price,
            Stock = request.Stock,
            CreatedAt = DateTime.Now
        };

        _context.Products.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return Result<int>.Ok(entity.Id);
    }
}
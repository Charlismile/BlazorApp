using BlazorApp1.Models;
using BlazorApp1.Models.Entities.DBCRUD;
using MediatR;

namespace BlazorApp1.Application.Features.Products.Commands;

public class UpdateProductCommandHandler
    : IRequestHandler<UpdateProductCommand, Result<bool>>
{
    private readonly DbContextCrud _context;

    public UpdateProductCommandHandler(DbContextCrud context)
    {
        _context = context;
    }

    public async Task<Result<bool>> Handle(
        UpdateProductCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _context.Products
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
            return Result<bool>.Fail("Producto no encontrado.");

        entity.Name = request.Name;
        entity.Price = request.Price;
        entity.Stock = request.Stock;

        await _context.SaveChangesAsync(cancellationToken);

        return Result<bool>.Ok(true);
    }
}
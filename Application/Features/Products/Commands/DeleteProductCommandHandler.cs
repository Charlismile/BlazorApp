using BlazorApp1.Models;
using BlazorApp1.Models.Entities.DBCRUD;
using MediatR;

namespace BlazorApp1.Application.Features.Products.Commands;

public class DeleteProductCommandHandler
    : IRequestHandler<DeleteProductCommand, Result<bool>>
{
    private readonly DbContextCrud _context;

    public DeleteProductCommandHandler(DbContextCrud context)
    {
        _context = context;
    }

    public async Task<Result<bool>> Handle(
        DeleteProductCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _context.Products
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
            return Result<bool>.Fail("Producto no encontrado.");

        _context.Products.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return Result<bool>.Ok(true);
    }
}
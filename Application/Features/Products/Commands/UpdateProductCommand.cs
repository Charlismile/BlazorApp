using BlazorApp1.Models;
using MediatR;

namespace BlazorApp1.Application.Features.Products.Commands;

public record UpdateProductCommand(
    int Id,
    string Name,
    decimal Price,
    int Stock
) : IRequest<Result<bool>>;
using BlazorApp1.Models;
using MediatR;

namespace BlazorApp1.Application.Features.Products.Commands;

public record DeleteProductCommand(int Id) 
    : IRequest<Result<bool>>;
using BlazorApp1.Models.CrudModels;
using MediatR;

namespace BlazorApp1.Application.Features.Products.Queries;

public record GetAllProductsQuery() 
    : IRequest<List<ProductModel>>;
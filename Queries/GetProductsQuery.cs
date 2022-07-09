using CqrsMediatrExample.Entities;
using MediatR;

namespace CqrsMediatrExample.Queries;

public record GetProductsQuery : IRequest<IEnumerable<Product>>; // this means that our request will return a list of products

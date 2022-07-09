using CqrsMediatrExample.Entities;
using CqrsMediatrExample.Persistence;
using CqrsMediatrExample.Queries;
using MediatR;

namespace CqrsMediatrExample.Handlers;

public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>> // this parameters we pass are the query/command we want to handle and the return type of the handler
{
    private readonly FakeDataStore _fakeDataStore;

    public GetProductsHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

    public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        return await _fakeDataStore.GetAllProducts();
    }
}

using CqrsMediatrExample.Commands;
using CqrsMediatrExample.Entities;
using CqrsMediatrExample.Persistence;
using MediatR;

namespace CqrsMediatrExample.Handlers;

public class AddProductHandler : IRequestHandler<AddProductCommand, Product> // Unit is a struct that represents a void type. Changed Unit to Product after adding <Product> to  AddProductCommand
{
    private readonly FakeDataStore _fakeDataStore;

    public AddProductHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

    // use this if using Unit
    //public async Task<Unit> Handle(AddProductCommand request, CancellationToken cancellationToken)
    //{
    //    await _fakeDataStore.AddProduct(request.Product);
    //    return Unit.Value; // need to return this
    //}

    public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        await _fakeDataStore.AddProduct(request.Product);
        return request.Product; // need to return this
    }
}

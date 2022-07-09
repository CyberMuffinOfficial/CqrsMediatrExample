using CqrsMediatrExample.Commands;
using CqrsMediatrExample.Persistence;
using MediatR;

namespace CqrsMediatrExample.Handlers;

public class AddProductHandler : IRequestHandler<AddProductCommand, Unit> // Unit is a struct that represents a void type
{
    private readonly FakeDataStore _fakeDataStore;

    public AddProductHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

    public async Task<Unit> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        await _fakeDataStore.AddProduct(request.Product);
        return Unit.Value; // need to return this
    }
}

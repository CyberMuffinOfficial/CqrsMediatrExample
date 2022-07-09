using CqrsMediatrExample.Persistence;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddSingleton<FakeDataStore>();

builder.Services.AddControllers(); // options => options.SuppressAsyncSuffixInActionNames = false

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


//https://www.youtube.com/watch?v=ykC3Ty-3U7g
/*
 First is to set up the fakedatastore and the products entity/model
then create folders for Queries, Commands and Handlers
FIrst define the Query to get all products
Use record for queries and commands
Then set up a handler and pass that query to the handler
Then go to the products controller and use the sender's send method with a new instance of the query that we created. this is the mediator pattern. we do not have any idea how the query is handled and no dependency on fakedatastore 

So far we have created 2 queries and 1 command, total of 3, and 3 handlers respectively.
If we want to handle a single request with multiple handlers, thats where notifications come in. for example, if we want to add a product and also send an email or invalidating a cache
(multiple independent operations that have to occur after an event)
So we will update the addproduct to publish a notification and have it handled by 2 mroe handlers
Now when we add a product it publishes a notification that triggers 2 more events, and the publisher has no idea
 */

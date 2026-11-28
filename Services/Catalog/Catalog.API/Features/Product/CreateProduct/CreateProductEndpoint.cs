namespace Catalog.API.Features.Product.CreateProduct;

public record CreateProductRequest(
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    int Price
);

public record CreateProductResponse(
    Guid Id
);

public class CreateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products", async (CreateProductRequest request, ISender sender) =>
        {
            // 1. create command request
            var command = request.Adapt<CreateProductCommand>();

            // 2. get the result of the command via MediatR
            var result = await sender.Send(command);

            // 3. Create response from result
            var response = result.Adapt<CreateProductResponse>();

            // 4. Return reponse to caller
            return Results.Created($"/products/{response.Id}", response);
        })
            .WithName("CreateProduct")
            .WithSummary("Creates a new product")
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .Produces<CreateProductResponse>(StatusCodes.Status201Created)
            .WithDescription("Creating new product with name, price, desription, ...");
    }
}

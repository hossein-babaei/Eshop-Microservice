namespace Catalog.API.Features.Product.CreateProduct;

using BuildingBlocks.CQRS;
using Catalog.API.Models;

public record CreateProductCommand(
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    int Price
) : ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);

public class CreateProductHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        //Create product entity from command
        var product = new Product
        {
            Category = command.Category,
            Description = command.Description,
            Image = command.ImageFile,
            Price = command.Price,
            Name = command.Name
        };
        //Save product entity to database

        //Return result with created product ID

        return new CreateProductResult(Guid.NewGuid());
    }
}

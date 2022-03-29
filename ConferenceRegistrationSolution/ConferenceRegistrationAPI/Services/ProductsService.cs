using ConferenceRegistrationAPI.Adapters.Mongo;

namespace ConferenceRegistrationAPI.Services;

public class ProductsService : IProductsService
{
    private readonly MarkupServiceAmountPort _amountPort;
    private readonly MongoProductsAdapter _mongoAdapter;

    public ProductsService(MarkupServiceAmountPort amountPort, MongoProductsAdapter mongoAdapter)
    {
        _mongoAdapter = mongoAdapter;
        _amountPort = amountPort;
    }

    public async Task<GetProductsReponse> GetAllProductsAsync()
    {
        var products = await _mongoAdapter.GetAllAsync();
        var markup = await _amountPort.GetMarkupAmountAsync();

        var productsConverted = products.Select(p => new ProductInformationResponse(p.Id, p.Name, p.Cost *(1 + markup))).ToList();

        return new GetProductsReponse(productsConverted);
    }

    public async Task<ProductInformationResponse> GetProductAsync(string id)
    {
        var markup = await _amountPort.GetMarkupAmountAsync();
        var item = await _mongoAdapter.GetProductById(id);
        if(item == null)
        {
            return null;
        }
        else
        {
            return new ProductInformationResponse(item.Id, item.Name, item.Cost * (1 + markup));
        }

        //return new ProductInformationResponse(id.ToString(), "Dosa", 7.99M * (1 + markup));
    }


}

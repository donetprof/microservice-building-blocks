namespace ConferenceRegistrationAPI.Services;

public class ProductsService : IProductsService
{
    private readonly MarkupServiceAmountPort _amountPort;

    public ProductsService(MarkupServiceAmountPort amountPort)
    {
        _amountPort = amountPort;
    }

    public async Task<ProductInformationResponse> GetProductAsync(int id)
    {
        var markup = await _amountPort.GetMarkupAmountAsync();

        return new ProductInformationResponse(id, "Dosa", 7.99M * (1 + markup));
    }
}

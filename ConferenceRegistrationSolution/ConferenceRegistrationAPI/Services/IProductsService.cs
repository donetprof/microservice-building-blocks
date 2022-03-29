namespace ConferenceRegistrationAPI.Services;

public interface IProductsService
{
    Task<ProductInformationResponse> GetProductAsync(string id);

    Task<GetProductsReponse> GetAllProductsAsync();
}
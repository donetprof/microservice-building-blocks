namespace ConferenceRegistrationAPI.Services;

public interface IProductsService
{
    Task<ProductInformationResponse> GetProductAsync(int id);
}
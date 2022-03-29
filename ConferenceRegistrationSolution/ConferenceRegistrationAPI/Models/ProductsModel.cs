namespace ConferenceRegistrationAPI.Models;

public record ProductInformationResponse(string id, string name, decimal price);

public record GetProductsReponse(List<ProductInformationResponse> data);   
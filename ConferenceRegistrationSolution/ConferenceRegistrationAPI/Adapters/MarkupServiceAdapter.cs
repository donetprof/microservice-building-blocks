namespace ConferenceRegistrationAPI.Adapters;

public class MarkupServiceAdapter
{
    private readonly HttpClient _httpClient;

    public MarkupServiceAdapter(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GetPricingResponse> GetPricingResponseAsync()
    {
        var response = await _httpClient.GetAsync("/markup");

        response.EnsureSuccessStatusCode();

        var getPricingReponse = await response.Content.ReadFromJsonAsync<GetPricingResponse>();

        return getPricingReponse!;
    }

}

public class GetPricingResponse
{
    public decimal amountOfMarkup { get; set; }
    public DateTime adjustedAt { get; set; }
}

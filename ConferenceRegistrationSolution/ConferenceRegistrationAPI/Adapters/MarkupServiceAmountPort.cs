﻿namespace ConferenceRegistrationAPI.Adapters;

public class MarkupServiceAmountPort
{
    private readonly MarkupServiceAdapter _adapter;

    public MarkupServiceAmountPort(MarkupServiceAdapter adapter)
    {
        _adapter = adapter;
    }

    public async Task<decimal> GetMarkupAmountAsync()
    {
        var response = await _adapter.GetPricingResponseAsync();

        return response.amountOfMarkup;
    }
}

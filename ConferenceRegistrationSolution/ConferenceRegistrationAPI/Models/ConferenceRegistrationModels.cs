namespace ConferenceRegistrationAPI.Models;

public record ConferenceRegistration
{
    public ConferenceInfo? ConferenceInfo { get; init; }
}

public record ConferenceInfo(string id, string name);

public record ConferenceConfirmationConferenceResponse(string id, string name);

public record ConferenceConfirmationForResponse(string name, string email);

public record ConferenceConfirmationPaymentRepsonse(decimal charged, string card);

public record ConferenceConfirmation(ConferenceConfirmationConferenceResponse conference, ConferenceConfirmationForResponse for_info, ConferenceConfirmationPaymentRepsonse payment);


//public class ConferenceRegistration
//{
//    public ConferenceInfo ConferenceInfo { get; set; } = new ConferenceInfo();
//}

//public class ConferenceInfo
//{
//    public string Id { get; set; } = string.Empty;
//    public string Name { get; set; } = string.Empty;
//}
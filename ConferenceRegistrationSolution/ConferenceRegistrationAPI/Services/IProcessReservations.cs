namespace ConferenceRegistrationAPI;

public interface IProcessReservations
{
    Task<ConferenceConfirmation> ProcessReservationAsync(ConferenceRegistration request);
}

namespace ConferenceRegistrationAPI.Controllers;

public class ConferenceRegistrationsController :  ControllerBase
{
    private readonly IProcessReservations _reservationProcessor;

    public ConferenceRegistrationsController(IProcessReservations reservationProcessor)
    {
        _reservationProcessor = reservationProcessor;
    }

    [HttpPost("conference-registrations")]
    public async Task<ActionResult> AddRegistration([FromBody] ConferenceRegistration request)
    {

        ConferenceConfirmation response = await _reservationProcessor.ProcessReservationAsync(request);
        return StatusCode(201, request);
    }
}


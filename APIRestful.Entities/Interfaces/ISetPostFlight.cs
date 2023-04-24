namespace APIRestful.Domain.Interfaces
{
    using APIRestful.Domain.Models.Request;
    using Microsoft.AspNetCore.Mvc;

    public interface ISetPostFlight
    {
        Task<ActionResult> SetPostFlight(RequestJourney request);
    }
}

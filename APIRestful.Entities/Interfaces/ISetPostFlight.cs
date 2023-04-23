namespace APIRestful.Entities.Interfaces
{
    using APIRestful.Entities.Models.Request;
    using Microsoft.AspNetCore.Mvc;
    public interface ISetPostFlight
    {
        Task<ActionResult> SetPostFlight(RequestJourney request);
    }
}

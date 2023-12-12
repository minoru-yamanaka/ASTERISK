using Asterisk.Domain.Commands.Temperatures;
using Asterisk.Domain.Handlers.Temperatures;
using Asterisk.Domain.Queries.Temperaturas;
using Asterisk.Shared.Commands;
using Asterisk.Shared.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Asterisk.Api.Controllers
{
    [Produces("application/json")]

    [Route("v1/temperature")]
    [ApiController]
    public class TemperaturesController : ControllerBase
    {
        [HttpPost("Create")]
        public GenericCommandResult Create(CreateTemperatureCommand command, [FromServices] CreateTemperatureHandle handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        [Route("readAll")]
        [HttpGet]
        public GenericQueryResult GetAll([FromServices] ReadTemperaturesHandle handle)
        {
            ReadTemperaturesQuery query = new ReadTemperaturesQuery();

            return (GenericQueryResult)handle.Handler(query);
        }

    }
}

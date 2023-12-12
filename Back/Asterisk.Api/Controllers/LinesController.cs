using Asterisk.Domain.Commands.Lines;
using Asterisk.Domain.Handlers.Lines;
using Asterisk.Domain.Queries.Lines;
using Asterisk.Shared.Commands;
using Asterisk.Shared.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Asterisk.Api.Controllers
{
    [Produces("application/json")]

    [Route("v1/lines")]
    [ApiController]
    public class LinesController : ControllerBase
    {
        [HttpGet]
        //[Authorize(Roles = "Administrator")]
        public GenericQueryResult GetAll([FromServices] ReadLinesHandle handle)
        {
            ReadLinesQuery query = new ReadLinesQuery();
                
            return (GenericQueryResult)handle.Handler(query);
        }


        [HttpPatch("update/{id}")]
        public GenericCommandResult Update(Guid id, EditLinePositionCommand command, [FromServices] EditLinePositionHandle handle)
        {
            command.AdicionarId(id);

            return (GenericCommandResult)handle.Handler(command);
        }
    }
}

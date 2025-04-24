using Application.AI.Chat;
using Application.Country.Create;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ChatController : ControllerBase
  {
    private readonly IMediator _mediator;

    public ChatController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AIChatParams req)
    {
      var res = await _mediator.Send(new AIChatQuery(req));
      return Ok(res);
    }
  }
}

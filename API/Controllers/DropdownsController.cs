﻿using Application.Dropdowns.Country;
using Application.Dropdowns.State;
using Application.Models.Dropdown;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
  [ApiController]
  public class DropdownsController : ControllerBase
  {
    private readonly IMediator _mediator;

    public DropdownsController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet("state")]
    public async Task<IActionResult> GetStates([FromQuery] DropdownParams req)
    {
      var res = await _mediator.Send(new StateDropdownQuery(req));
      return Ok(res);
    }

    [HttpGet("country")]
    public async Task<IActionResult> GetCountries([FromQuery] DropdownParams req)
    {
      var res = await _mediator.Send(new CountryDropdownQuery(req));
      return Ok(res);
    }
  }
}

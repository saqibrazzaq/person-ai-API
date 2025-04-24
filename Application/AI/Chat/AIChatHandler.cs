using Application.Models;
using Application.Person.GetById;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.AI.Chat
{
  public class AIChatHandler : IRequestHandler<AIChatQuery, AIChatRes>
  {
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public AIChatHandler(IMediator mediator, IMapper mapper)
    {
      this._mediator = mediator;
      _mapper = mapper;
    }

    public async Task<AIChatRes> Handle(AIChatQuery request, CancellationToken cancellationToken)
    {
      var personReq = new PersonGetByIdParams { Id = request.req.PersonId ?? 0 };
      var person = await _mediator.Send(new PersonGetByIdQuery(personReq));

      var aiQuery = $"{person.ToString()}. {request.req.Message}";

      var aiResJson = await Gpt4allApiCaller.CallLlamaApi(aiQuery);
      var aiRes = ParseAiJson(aiResJson);
      var dto = new AIChatRes() { Message = aiRes.Choices[0].Message.Content };
      return dto;
    }

    private ChatCompletionResponseDto ParseAiJson(string jsonResponse)
    {
      // Deserialize the JSON string into a ChatCompletionResponseDto object
      ChatCompletionResponseDto responseDto = JsonSerializer.Deserialize<ChatCompletionResponseDto>(jsonResponse);

      // Now you can access the properties of the DTO
      if (responseDto?.Choices != null && responseDto.Choices.Count > 0)
      {
        Console.WriteLine($"Model: {responseDto.Model}");
        Console.WriteLine($"Created At: {responseDto.Created}");
        Console.WriteLine($"First Choice Content: {responseDto.Choices[0].Message.Content}");
        Console.WriteLine($"Usage - Total Tokens: {responseDto.Usage.TotalTokens}");
      }
      else
      {
        Console.WriteLine("No choices found in the response.");
      }
      return responseDto;
    }
  }
}

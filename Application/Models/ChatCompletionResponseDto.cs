using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Models
{
  public class ChatCompletionResponseDto
  {
    [JsonPropertyName("choices")]
    public List<ChoiceDto> Choices { get; set; }

    [JsonPropertyName("created")]
    public long Created { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("model")]
    public string Model { get; set; }

    [JsonPropertyName("object")]
    public string Object { get; set; }

    [JsonPropertyName("usage")]
    public UsageDto Usage { get; set; }
  }

  public class ChoiceDto
  {
    [JsonPropertyName("finish_reason")]
    public string FinishReason { get; set; }

    [JsonPropertyName("index")]
    public int Index { get; set; }

    [JsonPropertyName("logprobs")]
    public object Logprobs { get; set; } // Could be null or a specific object

    [JsonPropertyName("message")]
    public MessageResponseDto Message { get; set; }

    [JsonPropertyName("references")]
    public object References { get; set; } // Could be null or a specific object
  }

  public class MessageResponseDto
  {
    [JsonPropertyName("content")]
    public string Content { get; set; }

    [JsonPropertyName("role")]
    public string Role { get; set; }
  }

  public class UsageDto
  {
    [JsonPropertyName("completion_tokens")]
    public int CompletionTokens { get; set; }

    [JsonPropertyName("prompt_tokens")]
    public int PromptTokens { get; set; }

    [JsonPropertyName("total_tokens")]
    public int TotalTokens { get; set; }
  }
}

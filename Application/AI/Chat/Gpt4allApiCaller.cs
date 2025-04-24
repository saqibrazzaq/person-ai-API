using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.AI.Chat
{
  public class Gpt4allApiCaller
  {
    public static async Task<string> CallLlamaApi(string message)
    {
      string apiUrl = "http://localhost:4891/v1/chat/completions";

      // Create the JSON payload as a C# object (using the DTO you created earlier)
      var requestData = new ChatRequestDto
      {
        Model = "Llama 3 8b Instruct",
        Messages = new List<MessageDto>
            {
                new MessageDto { Role = "user", Content = message }
            },
        MaxTokens = 500,
        Temperature = 0.28
      };

      // Serialize the C# object to a JSON string
      string jsonPayload = JsonSerializer.Serialize(requestData);

      using (HttpClient client = new HttpClient())
      {
        // Create the HTTP request with the POST method and JSON content
        var request = new HttpRequestMessage(HttpMethod.Post, apiUrl);
        request.Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

        try
        {
          // Send the request and get the response
          HttpResponseMessage response = await client.SendAsync(request);

          // Check if the request was successful (status code 2xx)
          if (response.IsSuccessStatusCode)
          {
            string responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine("API Response:");
            Console.WriteLine(responseContent);
            return responseContent;

            // You can now deserialize the responseContent into a C# object
            // representing the API's response structure.
          }
          else
          {
            Console.WriteLine($"API Error: {response.StatusCode} - {response.ReasonPhrase}");
            string errorContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Error Content: {errorContent}");
            return errorContent;
          }
        }
        catch (HttpRequestException ex)
        {
          Console.WriteLine($"HTTP Request Exception: {ex.Message}");
          throw new Exception(ex.Message);
        }
      }
    }
  }
}

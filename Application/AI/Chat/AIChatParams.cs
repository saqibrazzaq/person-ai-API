using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AI.Chat
{
  public class AIChatParams
  {
    [Required]
    public int? PersonId { get; set; }
    [Required, MinLength(2)]
    public string? Message { get; set; }
  }
}

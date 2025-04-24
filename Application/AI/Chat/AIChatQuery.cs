﻿using Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AI.Chat
{
  public record AIChatQuery(AIChatParams req) : IRequest<AIChatRes>;
}

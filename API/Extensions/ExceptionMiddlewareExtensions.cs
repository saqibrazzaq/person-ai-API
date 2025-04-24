﻿using Application.Models.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace API.Extensions
{
  public static class ExceptionMiddlewareExtensions
  {
    public static void ConfigureExceptionHandler(this WebApplication app,
        API.Logger.ILoggerManager logger)
    {
      app.UseExceptionHandler(appError =>
      {
        appError.Run(async context =>
        {
          context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
          context.Response.ContentType = "application/json";

          var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
          if (contextFeature != null)
          {
            context.Response.StatusCode = contextFeature.Error switch
            {
              NotFoundException => StatusCodes.Status404NotFound,
              BadRequestException => StatusCodes.Status400BadRequest,
              UnAuthorizedUserException => StatusCodes.Status401Unauthorized,
              _ => StatusCodes.Status500InternalServerError
            };
            logger.LogError($"Error: {contextFeature.Error}");

            await context.Response.WriteAsync(
              new ErrorDetails(context.Response.StatusCode, contextFeature.Error.Message)
              .ToString());
          }
        });
      });
    }
  }
}

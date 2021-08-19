//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Snakk.API.MiddelWare
{
    public class UnhandledExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; } = int.MaxValue - 5; 

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is Exception exception)
            {
                context.Result = new ObjectResult(new { 
                    StatusCode = 500,
                    ErrorMessage = exception.Message
                })
                {
                    StatusCode = 500,
                };

                context.ExceptionHandled = true;
            }
        }
    }
}

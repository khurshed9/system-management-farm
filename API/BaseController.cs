﻿using GlobalExceptionHandler.ApiConventions;
using Microsoft.AspNetCore.Mvc;

namespace SystemManagementFactory.API;

[ApiController]
[ApiConventionType(typeof(CustomApiConventions))]

public class BaseController : ControllerBase
{
    protected string? GetErrorMessage
    {
        get
        {
            return ModelState.IsValid
                ? null
                : string.Join("; ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
        }
    }
}
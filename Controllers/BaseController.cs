namespace NETCoreDemo.Controllers;

using Microsoft.AspNetCore.Mvc;
using NETCoreDemo.Services;

public class BaseController<TController, TService> : ApiControllerBase
{
    private readonly ILogger<TController> _logger;
    private readonly TService _service;

    public BaseController(ILogger<TController> logger, TService services)
    {
        _logger = logger;
        _service = services;
    }
}
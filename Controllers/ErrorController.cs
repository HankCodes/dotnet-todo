
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TodoApp.Models;
using TodoApp.Models.HttpErrors;

namespace TodoApp.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Index()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error;
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            IHttpErrorViewModel vm = new Http500ErrorViewModel();

            if (exception is Http404Error) vm = new Http404ErrorViewModel(exception.Message);

            return View("Error", vm);
        }
    }
}
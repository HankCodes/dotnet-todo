using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TodoApp.Models;
using TodoApp.Models.Enums;
using TodoApp.Models.services;
using TodoApp.ViewModel;

namespace TodoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private TodoService _service;

        public HomeController(ILogger<HomeController> logger, TodoService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                TodoIndexViewModel vm = new TodoIndexViewModel()
                {
                    MostRecent = await _service.GetMostRecent(3) ?? new List<Todo>(),
                    MostRecentOnGoing = await _service.GetMostRecentlyChangedByStatus(TodoStatus.OnGoing, 3) ?? new List<Todo>(),
                    MostRecentDone = await _service.GetMostRecentlyChangedByStatus(TodoStatus.Done, 3) ?? new List<Todo>()
                };

                return View(vm);
            }
            catch (Exception)
            {
                TodoIndexViewModel vm = new TodoIndexViewModel()
                {
                    ErrorMessage = "Could not get todo items at the moment. Please try again soon"
                };

                return View(vm);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

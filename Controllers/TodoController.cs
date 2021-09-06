using System;
using System.Diagnostics;
using TodoApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TodoApp.Data;
using System.Threading.Tasks;
using TodoApp.Models.Enums;
using TodoApp.Models.services;
using System.Collections.Generic;
using TodoApp.Models.HttpErrors;

namespace TodoApp.Controllers
{
    public class TodoController : Controller
    {
        private readonly ILogger<TodoController> _logger;
        private TodoService _service;

        public TodoController(ILogger<TodoController> logger, TodoService service)
        {
            _logger = logger;
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                List<Todo> todos = await _service.All();
                return View(todos);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Todo todo)
        {
            try
            {
                if (!ModelState.IsValid) return View();

                await _service.Add(todo);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }

        public async Task<IActionResult> Update(int id)
        {
            try
            {
                Todo todo = await _service.GetById(id);
                if (todo == null) throw new Http404Error("The item you where looking for could not be found");

                return View(todo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(Todo todo)
        {
            try
            {
                await _service.Update(todo);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Remove(id);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

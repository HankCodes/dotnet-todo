using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApp.Data;

namespace TodoApp.Models.services
{
    public class TodoService
    {
        private TodoAppContext _context;

        public TodoService(TodoAppContext context)
        {
            _context = context;
        }

        public async Task<List<Todo>> All()
        {
            List<Todo> list = await _context.Todo.ToListAsync();
            list.Reverse();
            return list;
        }

        public async Task<Todo> GetById(int id)
        {
            return await _context.Todo.FindAsync(id);
        }

        public async Task<int> Add(Todo todo)
        {
            await _context.AddAsync(todo);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(Todo todo)
        {
            _context.Update<Todo>(todo);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Remove(int id)
        {
            Todo todo = await GetById(id);
            _context.Remove<Todo>(todo);
            return await _context.SaveChangesAsync();
        }
    }
}
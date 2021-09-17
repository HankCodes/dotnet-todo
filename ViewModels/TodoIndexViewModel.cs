
using System.Collections.Generic;
using TodoApp.Models;

namespace TodoApp.ViewModel
{
    public class TodoIndexViewModel
    {
        public List<Todo> MostRecent { get; set; }
        public List<Todo> MostRecentOnGoing { get; set; }
        public List<Todo> MostRecentDone { get; set; }
    }
}
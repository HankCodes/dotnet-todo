
using System.Collections.Generic;
using TodoApp.Models;

namespace TodoApp.ViewModel
{
    public class TodoIndexViewModel
    {
        protected List<Todo> _mostRecent;
        protected List<Todo> _mostRecentOnGoing;
        protected List<Todo> _mostRecentDone;
        public List<Todo> MostRecent
        {
            get
            {
                return _mostRecent ?? new List<Todo>();
            }

            set => _mostRecent = value;
        }
        public List<Todo> MostRecentOnGoing
        {
            get
            {
                return _mostRecentOnGoing ?? new List<Todo>();
            }

            set => _mostRecentOnGoing = value;
        }
        public List<Todo> MostRecentDone
        {
            get
            {
                return _mostRecentDone ?? new List<Todo>();
            }

            set => _mostRecentDone = value;
        }
        public string ErrorMessage { get; set; }
    }
}
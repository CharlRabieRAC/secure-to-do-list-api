using secure_to_do_list_api.Handlers;
using secure_to_do_list_api.Models;
using System.Collections.Generic;

namespace secure_to_do_list_api.Queries
{
    internal class GetToDoList : RequestHandler<string, List<ToDoItem>>
    {
        public override List<ToDoItem> Handle(string request)
        {
            return new List<ToDoItem>()
            {
                new ToDoItem() {Id = "1", Description = "To-do list item 1", IsCompleted = false},
                new ToDoItem() {Id = "2", Description = "To-do list item 2", IsCompleted = false},
                new ToDoItem() {Id = "3", Description = "To-do list item 3", IsCompleted = false},
                new ToDoItem() {Id = "4", Description = "To-do list item 4", IsCompleted = false},
            };

        }
    }
}

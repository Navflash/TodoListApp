using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TodoList.Model
{
    public class TodoItem : BindableObject
    {
        private bool completed;
        public TodoItem(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public bool Completed
        {
            get => completed;
            set
            {
                completed = value;
                OnPropertyChanged();
            }
        }
        public static IEnumerable<TodoItem> GetTodoItems()
        {
            return new List<TodoItem>
            {
                new TodoItem("Go To work"),
                new TodoItem("Have Lunch"),
                new TodoItem("Gym at 7"),
                new TodoItem("Family time")
            };
        }
    }
}

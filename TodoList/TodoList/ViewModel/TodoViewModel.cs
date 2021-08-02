using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TodoList.Model;
using TodoList.Services;
using Xamarin.Forms;

namespace TodoList.ViewModel
{
    public class TodoViewModel : BindableObject
    {
        public event EventHandler<double> UpdateProgressBar;

        private IDialogMessage _dialogMessage;
        public TodoViewModel(IDialogMessage dialogMessage)
        {
            _dialogMessage = dialogMessage;
            Items = new ObservableCollection<TodoItem>(TodoItem.GetTodoItems());
            CalculateCompletedHeader();
        }

        public ObservableCollection<TodoItem> Items { get; set; }
        public string PageTitle { get; set; }

        private TodoItem _selectedItem;
        private string _completedHeader;
        private double _completedProgress;

        public TodoItem SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                PageTitle = value?.Name;
                OnPropertyChanged("PageTitle");
            }
        }
        public string CompletedHeader
        {
            get => _completedHeader;
            set
            {
                _completedHeader = value;
                OnPropertyChanged();
            }
        }

        public double CompletedProgress
        {
            get => _completedProgress;
            set
            {
                _completedProgress = value;
                OnPropertyChanged();
            }
        }
        public ICommand AddItemCommand => new Command(async () => { await AddNewItem(); });
        public ICommand MarkAsCompletedCommand => new Command<TodoItem>(MarkAsCompleted);

        private async Task AddNewItem()
        {
            string newItem = await _dialogMessage.DisplayPrompt("New Task", "Please enter a new task name");
            Items.Add(new TodoItem(newItem));
        }
        private void MarkAsCompleted(TodoItem obj)
        {
            obj.Completed = true;
            Items.Remove(obj);
            Items.Add(obj);
            CalculateCompletedHeader();
        }

        private void CalculateCompletedHeader()
        {
            CompletedHeader = $"Completed {Items.Count(x => x.Completed)}/{Items.Count}";
            CompletedProgress = (double)Items.Count(x => x.Completed) / (double)Items.Count;
            UpdateProgressBar?.Invoke(this, CompletedProgress);
        }
    }
}

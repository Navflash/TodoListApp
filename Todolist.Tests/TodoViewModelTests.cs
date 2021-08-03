using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using TodoList.ViewModel;
using TodoList.Services;

namespace Todolist.Tests
{
    public class TodoViewModelTests
    {
        [Fact]
        public void ViewModel_populates_items_correctly()
        {
            TodoViewModel viewModel = new TodoViewModel(new DialogMessageMock());

            Assert.Equal(4, viewModel.Items.Count);
        }

        [Fact]
        public void AddItemCommand_adds_new_item_to_the_list()
        {
            var dialogMessage = new DialogMessageMock();
            dialogMessage.DialogResponse = "Todo Item 5";
            var viewModel = new TodoViewModel(dialogMessage);

            viewModel.AddItemCommand.Execute(null);

            Assert.Equal(5, viewModel.Items.Count);
            Assert.Equal("Todo Item 5", viewModel.Items.Last().Name);
        }
        [Fact]
        public void MarkAsCompletedCommand_marks_item_as_completed_and_puts_it_at_the_end_of_list()
        {
            var viewModel = new TodoViewModel(new DialogMessageMock());

            viewModel.MarkAsCompletedCommand.Execute(viewModel.Items.First());

            Assert.True(viewModel.Items.Last().Completed);
        }

        [Fact]
        public void MarkAsCompletedCommand_update_progress()
        {
            var viewModel = new TodoViewModel(new DialogMessageMock());

            viewModel.MarkAsCompletedCommand.Execute(viewModel.Items.First());

            Assert.Equal("Completed 1/4", viewModel.CompletedHeader);
            Assert.Equal(0.25, viewModel.CompletedProgress);
        }

        class DialogMessageMock : IDialogMessage
        {
            public int DisplayAlertCallCount { get; set; }
            public string DialogResponse { get; set; }

            public Task DisplayAlert(string title, string message, string cancel)
            {
                DisplayAlertCallCount++;
                return Task.CompletedTask;
            }

            public Task<string> DisplayActionSheet(string title, string destruction, params string[] buttons)
            {
                return Task.FromResult(DialogResponse);
            }


            public Task<string> DisplayPrompt(string title, string message)
            {
                return Task.FromResult(DialogResponse);
            }
        }
    }
}

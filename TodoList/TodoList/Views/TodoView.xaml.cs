using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Services;
using TodoList.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoList.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoView : ContentPage
    {
        public TodoView()
        {
            InitializeComponent();
            TodoViewModel todoViewModel = new TodoViewModel(new DialogMessage());
            BindingContext = todoViewModel;
            todoViewModel.UpdateProgressBar += TodoViewModel_UpdateProgressBar;
        }

        private async void TodoViewModel_UpdateProgressBar(object sender, double e)
        {
            await progressBar.ProgressTo(e, 300, Easing.Linear);
        }
    }
}
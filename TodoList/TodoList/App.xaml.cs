using System;
using TodoList.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoList
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TodoView());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

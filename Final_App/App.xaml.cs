﻿namespace Final_App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var page = new NavigationPage(new HomePage())
            {

            };

            MainPage = page;
        }
    }
}
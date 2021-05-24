using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using InstagramApp.Models;
using InstagramApp.ViewModels;
using SQLite;
using SQLiteNetExtensions.Extensions;
using Xamarin.Forms;

namespace InstagramApp
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            (this.BindingContext as PostsViewModel)?.RefreshList();
        }



        private async void AddNewPostBtn_Clicked(object sender, EventArgs e)
        {
            var user = base.Parent.BindingContext as User;

            await Navigation.PushAsync(new AddPostPage
            {
                BindingContext = user
            });
        }

        private async void PostImage_Tapped(object sender, EventArgs e)
        {
            var image = sender as Image;
            var post = image.BindingContext as Post;

            if (post == null)
            {
                return;
            }

            await Navigation.PushAsync(new PostDetailsPage
            {
                BindingContext = post,
            });

        }

    }
}

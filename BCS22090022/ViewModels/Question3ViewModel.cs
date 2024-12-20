using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCS22090022.Models;
using BCS22090022.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BCS22090022.ViewModels
{
    public partial class Question3ViewModel : ObservableObject
    {
        public ObservableCollection<PostRecord> Posts { get; set; } = new ObservableCollection<PostRecord>();
         public List<PostRecord> PostList { get; set; }
        [ObservableProperty] public string title;
        [ObservableProperty] public string body;
        [ObservableProperty] public string newTitle;
        [ObservableProperty] public string newBody;
        [ObservableProperty] public bool isAddPostAvailable = false;
        [ObservableProperty] public bool isLoading = false;
        private readonly ApiService _apiService;

        public Question3ViewModel(ApiService apiService)
        {
            _apiService = apiService;
            GetPosts();

        }

        [RelayCommand]
        private async void GetPosts()
        {
            isLoading = true;
            var posts = await _apiService.GetPostsAsync();
            Posts.Clear(); // Clear the existing items in the collection
            foreach (var post in posts)
            {
                Posts.Add(post); // Add new items to the existing ObservableCollection
            }
            isLoading = false;
        }

        [RelayCommand]
        private async void DeletePost(PostRecord post)
        {
            if (post == null) return;

            bool isConfirmed = await Shell.Current.DisplayAlert(
                "Delete Post",
                $"Are you sure you want to delete the post titled '{post.Title}'?",
                "Yes",
                "No");

            if (isConfirmed)
            {
                Posts.Remove(post);
                // Optionally, call the API to delete the post on the server
                // await _apiService.DeletePostAsync(post.Id);
            }
        }

        [RelayCommand]
        private async void AddPost()
        {
            IsAddPostAvailable = !IsAddPostAvailable;
        }

        [RelayCommand]
        private async void SaveAddedPost()
        {
            var newPost = new PostRecord
            {
                Title = NewTitle,
                Body = NewBody
            };
            await _apiService.CreatePostAsync(newPost);
            IsAddPostAvailable = false;
            Title = string.Empty;
            Body = string.Empty;
            Posts.Insert(0, newPost);
        }

    }
}

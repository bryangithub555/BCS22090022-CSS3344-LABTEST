using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BCS22090022.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty] private int count = 0;

        [RelayCommand]
        private void Click()
        {
            Count++;
        }

        [RelayCommand]
        private void GoToQuestion3Page()
        {
            Shell.Current.GoToAsync(nameof(Question3));
        }

        [RelayCommand]
        private void GoToQuestion1Page()
        {
            Shell.Current.GoToAsync(nameof(Question1));
        }
    }
}

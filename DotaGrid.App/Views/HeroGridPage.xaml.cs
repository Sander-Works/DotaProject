using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using DotaGrid.App.Services;
using DotaGrid.App.ViewModels;
using Microsoft.Toolkit.Uwp.UI.Animations;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace DotaGrid.App.Views
{
    public sealed partial class HeroGridPage : Page
    {
        public HeroViewModel ViewModel { get; } = new HeroViewModel();

        public HeroGridPage()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            await ViewModel.LoadHeroesAsync();
        }

    }
}

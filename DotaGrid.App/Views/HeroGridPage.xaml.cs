using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Dota.Views;
using DotaGrid.App.Services;
using DotaGrid.App.ViewModels;
using Microsoft.Toolkit.Uwp.UI.Animations;
using Windows.UI.Xaml;
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
            Loaded += HeroGridPage_Loaded; 
        }
        /*
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            await ViewModel.LoadHeroesAsync();
        }
        */

        private async void HeroGridPage_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadHeroesAsync();
        }

     

        private void Add(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(typeof(AddNewHeroPage));
        }
        private void Edit(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(typeof(DeleteAndEditPage));
        }
    }
}

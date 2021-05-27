using System;
using System.ComponentModel;
using System.Linq;
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
    public sealed partial class HeroGridDetailPage : Page
    {
        public HeroDetailViewModel ViewModel { get; } = new HeroDetailViewModel();

        public HeroGridDetailPage()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.RegisterElementForConnectedAnimation("animationKeyClasses", itemHero);
            if (e.Parameter is int heroId)
            {
                await ViewModel.LoadHeroesAsync(heroId);
            }
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
            if (e.NavigationMode == NavigationMode.Back)
            {
                NavigationService.Frame.SetListDataItemForNextConnectedAnimation(ViewModel.Item);
            }
        }
    }
}

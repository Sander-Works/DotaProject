using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using DotaGrid.App.DataAccess;
using DotaGrid.App.Helpers;
using DotaGrid.App.Services;
using DotaGrid.App.ViewModels;
using DotaGrid.Model;
using Microsoft.Toolkit.Uwp.UI.Animations;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace DotaGrid.App.Views
{
    public sealed partial class MainAttributeGridPage : Page
    {

        private ICommand _itemClickCommand;

        public ICommand ItemClickCommand => _itemClickCommand ?? (_itemClickCommand = new RelayCommand<Hero>(OnItemClick));

        private void OnItemClick(Hero obj)
        {
            throw new NotImplementedException();
        }

        public MainAttributesViewModel ViewModel { get; } = new MainAttributesViewModel();

            public MainAttributeGridPage()
            {
                InitializeComponent();
            }

            protected override async void OnNavigatedTo(NavigationEventArgs e)
            {
                base.OnNavigatedTo(e);

                await ViewModel.LoadMainAttributesAsync();
            }
       
    }
    
}

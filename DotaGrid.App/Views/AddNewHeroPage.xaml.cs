
using DotaGrid.App.Services;
using DotaGrid.App.ViewModels;
using DotaGrid.App.Views;
using DotaGrid.Model;
using Microsoft.Toolkit.Uwp.UI.Animations;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Dota.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddNewHeroPage : Page, INotifyPropertyChanged
    {

        public HeroDetailViewModel ViewModel { get; } = new HeroDetailViewModel();

        private Hero _item;

        public Hero Item
        {
            get { return _item; }
            set { Set(ref _item, value); }
        }

        public AddNewHeroPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
            if (e.NavigationMode == NavigationMode.Back)
            {
                NavigationService.Frame.SetListDataItemForNextConnectedAnimation(Item);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Set<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return;
            }

            storage = value;
            OnPropertyChanged(propertyName);
        }

        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
       
        private void Cancel(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(typeof(HeroGridPage));
        }
    }
}

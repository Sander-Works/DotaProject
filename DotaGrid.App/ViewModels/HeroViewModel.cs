using DotaGrid.App.DataAccess;
using DotaGrid.App.Helpers;
using DotaGrid.App.Services;
using DotaGrid.App.Views;
using DotaGrid.Model;
using Microsoft.Toolkit.Uwp.UI.Animations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;

namespace DotaGrid.App.ViewModels
{
    public class HeroViewModel : Observable
    {
        private ICommand _itemClickCommand;

        public ICommand ItemClickCommand => _itemClickCommand ?? (_itemClickCommand = new RelayCommand<Hero>(OnItemClick));

        public ObservableCollection<Hero> Heroes { get; set; } = new ObservableCollection<Hero>();
        private readonly HeroesDataAccess heroesDataAccess = new HeroesDataAccess();

        private Hero _item;

        public Hero Item
        {
            get { return _item; }
            set { Set(ref _item, value); }
        }

        public RelayCommand<Hero> DeleteCommand { get; set; }


        public HeroViewModel()
        {

            DeleteCommand = new RelayCommand<Hero>(async param =>
            {
                if (await heroesDataAccess.DeleteHeroAsync(param))
                {
                    Heroes.Remove(param);
                }
            }, param => param != null);
        }
    

      
        public async Task LoadHeroesAsync()
        {
            var heroes = await heroesDataAccess.GetHeroesAsync();
            foreach (Hero hero in heroes)
            {
                Heroes.Add(hero);
            }
        }

        private void OnItemClick(Hero clickedHero)
        {
            if (clickedHero != null)
            {
                NavigationService.Frame.SetListDataItemForNextConnectedAnimation(clickedHero);
                NavigationService.Navigate<HeroGridDetailPage>(clickedHero.HeroId);

                Debug.WriteLine(clickedHero.Name);
            }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(typeof(HeroGridPage));
        }
        private void Cancel(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(typeof(MainAttributeGridPage));
        }
    }
}

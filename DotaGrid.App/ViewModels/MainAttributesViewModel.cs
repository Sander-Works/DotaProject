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

namespace DotaGrid.App.ViewModels
{
    public class MainAttributesViewModel : Observable
    {

        private ICommand _itemClickCommand;

        public ICommand ItemClickCommand => _itemClickCommand ?? (_itemClickCommand = new RelayCommand<Mainattribute>(OnItemClick));

        
        private Mainattribute _selected;
        public Mainattribute Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                Set(ref _selected, value);
                LoadListedHeroesAsync(((Mainattribute)value).MainattributeId);
            }
        }
        

      

        public ObservableCollection<MainAttributesDataAccess> MainAttributes { get; } = new ObservableCollection<MainAttributesDataAccess>();
        private readonly MainAttributesDataAccess mainAttributesDataAccess = new MainAttributesDataAccess();
        public ObservableCollection<Hero> ListedHeroes { get; private set; } = new ObservableCollection<Hero>();


        public MainAttributesViewModel()
        {
        }

        public async Task LoadMainAttributesAsync()
        {
            var data = await mainAttributesDataAccess.GetMainAttributesAsync();
            foreach (var @mainAttribute in data)
            {
                MainAttributes.Add(mainAttribute);
            }
        }

        
        private void OnItemClick(Mainattribute clickedItem)
        {
            if (clickedItem != null)
            {
                NavigationService.Frame.SetListDataItemForNextConnectedAnimation(clickedItem);
                NavigationService.Navigate<HeroGridDetailPage>(clickedItem.MainattributeId);

                Debug.WriteLine(clickedItem.MainAttributeType);
            }
        }
        

        internal async void LoadListedHeroesAsync(int mainAttributeId)
        {
            var heroes = await mainAttributesDataAccess.GetListedHeroesAsync(mainAttributeId);
            ListedHeroes.Clear();
            foreach (Hero @hero in heroes)
                ListedHeroes.Add(@hero);
        }
    }
}

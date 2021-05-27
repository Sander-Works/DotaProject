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


        public ObservableCollection<Mainattribute> MainAttributes { get; } = new ObservableCollection<Mainattribute>();
        private readonly MainAttributesDataAccess mainAttributesDataAccess = new MainAttributesDataAccess();

        public MainAttributesViewModel()
        {
        }

        public async Task LoadMainAttributesAsync()
        {
            var data = await mainAttributesDataAccess.GetMainAttributesAsync();

            foreach (Mainattribute mainAttribute in data)
            {
                MainAttributes.Add(mainAttribute);
            }
        }



        private void OnItemClick(Mainattribute clickedItem)
        {
            if (clickedItem != null)
            {
                NavigationService.Frame.SetListDataItemForNextConnectedAnimation(clickedItem);
                NavigationService.Navigate<HeroGridPage>(clickedItem.MainattributeId);
            }
        }
    }
}

using DotaGrid.App.DataAccess;
using DotaGrid.App.Helpers;
using DotaGrid.App.Services;
using DotaGrid.App.Views;
using DotaGrid.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace DotaGrid.App.ViewModels
{
    public class HeroDetailViewModel : Observable
    {
        private readonly HeroesDataAccess heroDetailDataAccess = new HeroesDataAccess();
        public ObservableCollection<Hero> Heroes { get; set; } = new ObservableCollection<Hero>();


        private Hero _item;

        public Hero Item
        {
            get { return _item; }
            set { Set(ref _item, value); }
        }
        
        private Mainattribute _MainAttribute;

        public Mainattribute MainAttribute
        {
            get => _MainAttribute;
            set
            {
                if (Equals(_MainAttribute, value))
                {
                    return;
                }

                _MainAttribute = value;

                OnPropertyChanged(nameof(Mainattribute));
            }
        }
        
        private string _Name;

        public string Name
        {
            get => _Name;
            set
            {
                if (Equals(_Name, value))
                {
                    return;
                }

                _Name = value;

                OnPropertyChanged(nameof(Name));
            }
        }

        private string _Q;

        public string Q
        {
            get => _Q;
            set
            {
                if (Equals(_Q, value))
                {
                    return;
                }

                _Q = value;

                OnPropertyChanged(nameof(Q));
            }
        }

        private string _W;

        public string W
        {
            get => _W;
            set
            {
                if (Equals(_W, value))
                {
                    return;
                }

                _W = value;

                OnPropertyChanged(nameof(W));
            }
        }

        private string _E;

        public string E
        {
            get => _E;
            set
            {
                if (Equals(_E, value))
                {
                    return;
                }

                _E = value;

                OnPropertyChanged(nameof(E));
            }
        }
        private string _Ultimate;

        public string Ultimate
        {
            get => _Ultimate;
            set
            {
                if (Equals(_Ultimate, value))
                {
                    return;
                }

                _Ultimate = value;

                OnPropertyChanged(nameof(Ultimate));
            }
        }
        private int _Ms;

        public int Ms
        {
            get => _Ms;
            set
            {
                if (Equals(_Ms, value))
                {
                    return;
                }

                _Ms = value;

                OnPropertyChanged(nameof(Ms));
            }
        }
        private int _Hp;

        public int Hp
        {
            get => _Hp;
            set
            {
                if (Equals(_Hp, value))
                {
                    return;
                }

                _Hp = value;

                OnPropertyChanged(nameof(Hp));
            }
        }
        private int _Mana;

        public int Mana
        {
            get => _Mana;
            set
            {
                if (Equals(_Mana, value))
                {
                    return;
                }

                _Mana = value;

                OnPropertyChanged(nameof(Mana));
            }
        }
        private int _Armor;

        public int Armor
        {
            get => _Armor;
            set
            {
                if (Equals(_Armor, value))
                {
                    return;
                }

                _Armor = value;

                OnPropertyChanged(nameof(Armor));
            }
        }
        private string _Playstyle;
        public string Playstyle
        {
            get => _Playstyle;
            set
            {
                if (Equals(_Playstyle, value))
                {
                    return;
                }

                _Playstyle = value;

                OnPropertyChanged(nameof(Playstyle));
            }
        }

        internal RelayCommand AddCommand { get; set; }
        public RelayCommand<Hero> EditCommand { get; set; }
        public RelayCommand<Hero> DeleteCommand { get; set; }
       


        public HeroDetailViewModel()
        {
            AddCommand = new RelayCommand(AddHeroAsync);

            EditCommand = new RelayCommand<Hero>(async param =>
            {
                int index = Heroes.IndexOf(param);
                Hero editedHero = new Hero()
                {
                    HeroId = param.HeroId,
                    Mainattribute = param.Mainattribute,
                    Name = param.Name,
                    Q = param.Q,
                    W = param.W,
                    E = param.E,
                    Ultimate = param.Ultimate,               
                    Hp = param.Hp,
                    Mana = param.Mana,
                    Ms = param.Ms,
                    Armor = param.Armor,
                    Playstyle = param.Playstyle
                };
                if (await heroDetailDataAccess.PutHeroAsync(editedHero))
                {
                    Heroes.RemoveAt(index);
                    Heroes.Insert(index, editedHero);
                }
            }, param => param != null);


                DeleteCommand = new RelayCommand<Hero>(async param =>
                {
                    if (await heroDetailDataAccess.DeleteHeroAsync(param))
                    {
                        Heroes.Remove(param);
                    }
                }, param => param != null);
            }

    
        internal async Task LoadHeroesAsync(int heroId)
        {
            // TODO WTS: Replace this with your actual data
            var heroes = await heroDetailDataAccess.GetHeroesAsync();
            Item = heroes.First(i => i.HeroId == heroId);

        }

        internal async Task LoadHeroesAsync()
        {
            // TODO WTS: Replace this with your actual data
            Hero[] heroes = await heroDetailDataAccess.GetHeroesAsync();
            foreach (Hero hero in heroes)
            {
                Heroes.Add(hero);
            }

        }

        
        internal async void AddHeroAsync()
        {
            Hero newHero = new Hero() {
                Name = Name,
                //Mainattribute = MainAttribute,
                Q = Q,
                W = W,
                E = E,
                Ultimate = Ultimate,
                Ms = Ms,
                Hp = Hp,
                Mana = Mana,
                Armor = Armor,
                Playstyle = Playstyle };
            await heroDetailDataAccess.PostHeroAsync(newHero);
            Heroes.Add(newHero);
        }
    }   
}

﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using AdminRURS;
using AdminRURS.Annotations;
using AdminRURS.View;


namespace RURS.HamburgerMenu
{
    class MenuViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<NavigationViewItemBase> NavigationItems { get; set; }

        private NavigationViewItemBase _selectedItem;

        public NavigationViewItemBase SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        public MenuViewModel()
        {
            NavigationItems = new ObservableCollection<NavigationViewItemBase>();

            GetNagivationItems();

            SelectedItem = NavigationItems.First(x => x.GetType() == typeof(NavigationViewItem));

        }

        private void GetNagivationItems()
        {
            NavigationItems.Add(new NavigationViewItem { Content = "Home", Icon = new SymbolIcon(Symbol.Home), Tag = typeof(MainPage) });
            //tilføj sider under her, ligesom oppeover
            NavigationItems.Add(new NavigationViewItem
            {
                Content = "Tilføj/Ændre Ansat", Icon = new SymbolIcon(Symbol.AddFriend), Tag = typeof(TilføjAnsatPage)});
            NavigationItems.Add(new NavigationViewItem { Content = "Tilføj Færdigvare", Icon = new SymbolIcon(Symbol.PreviewLink), Tag = typeof(NyFaerdigVare) });
            NavigationItems.Add(new NavigationViewItem { Content = "Se Processordrer", Icon = new SymbolIcon(Symbol.Admin), Tag = typeof(AdminProcessOrdreView) });
            NavigationItems.Add(new NavigationViewItem {Content = "ResourceDictionary Eksempel", Icon = new SymbolIcon(Symbol.Important), Tag = typeof(EksempelResourceDictionaryView)});
            NavigationItems.Add(new NavigationViewItem {Content = "ResourceDictionary Eksempel 2", Icon = new SymbolIcon(Symbol.Library), Tag = typeof(EksempelResourceDictionaryView2)});

        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

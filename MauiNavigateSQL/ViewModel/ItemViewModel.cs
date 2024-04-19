using MauiNavigateSQL.Model;
using MauiNavigateSQL.Services;
using MauiNavigateSQL.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiNavigateSQL.ViewModel
{
    public class ItemViewModel : BindableObject
    {
        private ItemDatabase database = null;
        public ItemViewModel(ItemDatabase ItemDatabase)
        {
            database = ItemDatabase;
        }
      


        public ObservableCollection<Item> items = null;

        //public ObservableCollection<Item> Items
        //{
        //    get { return items; }
        //    set { items = value; OnPropertyChanged(); }
        //}

        private int Simpel = 42;

        private Item item = new Item();

        public Item ItemProp
        {
            get { return item; }
            set { item = value; OnPropertyChanged(); }
        }

        public ICommand AddItem => new Command(async () =>
        {
            
            //var navigationParameter = new Dictionary<string, object>
            //{
            //    { "ItemProp", ItemProp}
            //};
            //await Shell.Current.GoToAsync(nameof(ShoppingListView), navigationParameter);
            
            await database.SaveItemAsync(item);

            Preferences.Set(App.MY_VALUE, item.Description);    //Transient state

            //MessagingCenter.Send<ItemViewModel, Item>(this, MessengerKeys.AddItem, item);
            await Shell.Current.GoToAsync(nameof(ShoppingListView));

        });

        public ICommand AddSimpleItem => new Command(async () =>
        {
            //items.Add(item);    
            //await App.Current.MainPage.Navigation.PopAsync(true);

            
            await Shell.Current.GoToAsync($"{nameof(ShoppingListView)}?Simpel={Simpel}");

        });


        public ICommand BackToList => new Command(async () =>
        {

            await Shell.Current.GoToAsync($"{nameof(ShoppingListView)}");

        });
    }
}

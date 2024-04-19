using MauiNavigateSQL.Model;
using MauiNavigateSQL.ViewModel;
using System.ComponentModel;


namespace MauiNavigateSQL.View;


[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class ShoppingListView : ContentPage, INotifyPropertyChanged
{ 
    
    public ShoppingListView(ShoppingListViewModel slvm)
	{
        
		
		InitializeComponent();
        
        BindingContext = slvm;



    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        ((ShoppingListViewModel)BindingContext).NavigatedTooCMD.Execute(null);
    }




}
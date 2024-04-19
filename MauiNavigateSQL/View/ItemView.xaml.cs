using MauiNavigateSQL.Model;
using MauiNavigateSQL.ViewModel;
using System.Collections.ObjectModel;

namespace MauiNavigateSQL.View;

public partial class ItemView : ContentPage
{
   
    public ItemView(ItemViewModel ivm)
	{
        InitializeComponent();

        
        BindingContext = ivm;
        

    }
}
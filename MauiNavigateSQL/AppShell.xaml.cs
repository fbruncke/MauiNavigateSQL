using MauiNavigateSQL.View;

namespace MauiNavigateSQL;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(ItemView), typeof(ItemView));
        Routing.RegisterRoute(nameof(ShoppingListView), typeof(ShoppingListView));
    }
}

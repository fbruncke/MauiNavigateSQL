using MauiNavigateSQL.Services;
using MauiNavigateSQL.View;
using MauiNavigateSQL.ViewModel;

namespace MauiNavigateSQL;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddSingleton<ShoppingListViewModel>();
        builder.Services.AddTransient<ItemViewModel>();

        builder.Services.AddTransient<ShoppingListView>();
        builder.Services.AddTransient<ItemView>();

        builder.Services.AddSingleton<ItemDatabase>();

        return builder.Build();
	}
}

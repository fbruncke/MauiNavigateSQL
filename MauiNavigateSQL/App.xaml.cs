namespace MauiNavigateSQL;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}

    

	/// <summary>
	/// Transient state
	/// </summary>

    public const string MY_VALUE = "lastCMD";
    protected override void OnResume() {
		string value = "None";
        value = Preferences.Get(MY_VALUE, value);
		System.Diagnostics.Debug.WriteLine("Value is: " + value);
	}
	protected override void OnSleep()
	{ 
		
		//Here a value can be stored so the user can continue from last workflow	
	}
}

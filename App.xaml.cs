using TAsk.Viwes;

namespace TAsk;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		MainPage = new NavigationPage(new Login());       

    }
}

using CommunityToolkit.Mvvm.Messaging;
using TAsk.Models;
using TAsk.Repositories;

namespace TAsk;

public partial class NewTask : ContentPage
{
	private TaskRepository _task;
	public NewTask()
	{
		_task = new TaskRepository();
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
    }

	private void Button_Clicked(object sender, EventArgs e)
	{
		Tasks task = new Tasks
		{
			Description = lblDescri.Text,
			start = DateTimeOffset.Now.Date.ToShortDateString(),
			finish = DateTimeOffset.Now.Date.ToShortDateString(),
			IdUser = 0,
		};

		_task.AddTask(task);
        WeakReferenceMessenger.Default.Send<string>("send");
		lblDescri.Text = "";
		DisplayAlert("Show", "Tarefa criada", "OK");
		
    }
}
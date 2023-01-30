using CommunityToolkit.Mvvm.Messaging;
using System.Collections;
using System.Globalization;
using TAsk.Models;
using TAsk.Repositories;

namespace TAsk;

public partial class MainPage : ContentPage
{
    private TaskRepository _tasks;
   

    public MainPage()
    {          
        InitializeComponent();

        _tasks = new TaskRepository();
        collectionTask.ItemsSource = _tasks.get();

        var data = DateTimeOffset.Now.Date.ToString("dddd, dd MMMM yyyy");
        lblData.Text = data.ToString(CultureInfo.CurrentCulture);

        WeakReferenceMessenger.Default.Register<string>(this, (e, msg) =>
        {
            if (msg == "send") 
            {
                RefreshCollection();
            }            
        });
    }

    private void RefreshCollection()
    {
        collectionTask.ItemsSource = _tasks.get();
    }

    private void OnTapGestureRecognizerTapped(object sender, EventArgs e)
    {
        DisplayAlert("Atenção", "Deletar Task? ", "OK ");
    }   
    private void TapImageSair(object sender, EventArgs e)
    {          
        App.Current.MainPage = new Login();
    }   

    private void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
    {
        DisplayAlert("","","OK");
    }

    private async void SwipeItem_Invoked(object sender, EventArgs e)
    {
        bool msg = await DisplayAlert("Atenção", "Deseja realmente excluir a tarefa?", "Sim", "Não");

        if (msg)
        {           
            var swipe = (SwipeItem)sender;
            var task = (Tasks)swipe.CommandParameter;

            _tasks.Delete(task);
            RefreshCollection();
        }
    }

    private async void onTapPlay(object sender, EventArgs e)
    {
        var img = (Image)sender;
        await img.RelRotateTo(360, 1500);
        img.IsVisible = false;
        await DisplayAlert("Atenção", "tarefa iniciada", "OK");
    }

    private void onTapConclui(object sender, EventArgs e)
    {
        DisplayAlert("Atenção", "tarefa concluida", "OK");
    }

    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        //DisplayAlert("Atenção", "tarefa iniciada", "OK");
    }
}


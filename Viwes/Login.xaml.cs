using System.Globalization;
using TAsk.Models;
using TAsk.Repositories;
using TAsk.Repositories.interfaces;
using TAsk.Viwes;

namespace TAsk;

public partial class Login : ContentPage
{
    private UserRepository _repository;
    private UsuarioLogadoRepository _usuarioLogado;
    public Login()
    {
        this._usuarioLogado = new UsuarioLogadoRepository();
        this._repository = new UserRepository();
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);

        //Task.Run(() =>
        //{
        //    Thread.Sleep(5000);
        //    if (_usuarioLogado.user().Item2)
        //    {
        //        clicked(_usuarioLogado.user().Item1);
        //    }
        //});  
    }

    private void clicked(UserLogado item1)
    {
        EventArgs e = new EventArgs();
        object sender = new object();

        txtEmail.Text = item1.email;
        txtSenha.Text = item1.senha;

        Button_Clicked(sender, e);
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtSenha.Text))
        {
            if (_repository.GetUsers(txtEmail.Text, txtSenha.Text))
            {
                if (checkLog.IsChecked)
                {
                    var retorno = _repository.GetUserManterLogado(txtEmail.Text, txtSenha.Text);

                    UserLogado user = new UserLogado
                    {
                        Nome = retorno.Nome,
                        email = retorno.email,
                        senha = retorno.senha,
                        IdUser = retorno.Id,
                    };
                    _usuarioLogado.Add(user);
                }

                App.Current.MainPage = new AppShell();
            }
            else
            {
                msgerro.IsVisible = true;
            }
        }
        else
        {
            DisplayAlert("Erro", "Preencha todos os campos", "OK");
        }
    }
    private void Button_Clicked_1(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new Registre());
    }

    private void RedefinirSenha(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new RedefinirSenha());
    }
    private void txtSenha_Completed(object sender, TextChangedEventArgs e)
    {
        msgerro.IsVisible = false;
    }

    private void txtEmail_Completed(object sender, TextChangedEventArgs e)
    {
        msgerro.IsVisible = false;
    }
}

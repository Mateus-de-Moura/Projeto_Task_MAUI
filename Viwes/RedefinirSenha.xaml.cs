using CommunityToolkit.Mvvm.Messaging;
using System.Globalization;
using TAsk.Models;
using TAsk.Services;

namespace TAsk.Viwes;

public partial class RedefinirSenha : ContentPage
{
    private string codigo;
    private string email;
    public RedefinirSenha()
    {
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);

        WeakReferenceMessenger.Default.Register<string>(this, (e, msg) =>
        {
            ClearSession();
        });
    }

    private void ClearSession()
    {
        Navigation.PopModalAsync();
    }
    private void Button_Clicked(object sender, EventArgs e)
    {
        
        if (string.IsNullOrEmpty(codigo))
        {
            this.email = txtEmail.Text;
            var send = new ServiceSendMail();
            Task.Run(() =>
            {
                var retorno = send.SendMail(txtEmail.Text);
                this.codigo = retorno;
            });

            lblinfoRequest.Text = "Digite o codigo enviado por e-mail";
            txtEmail.Text = "";

            btnEnviar_Confirmar.Text = "Confirmar";
        }
        else
        {
            if (codigo == txtEmail.Text)
            {                
                Navigation.PushModalAsync(new RedefinicaoDeSenha(email));
            }
            else
            {
                DisplayAlert("erro", "O codigo informado esta errado", "OK");
            }
        }
    }
    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {       
        Navigation.PopModalAsync();
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        var send = new ServiceSendMail();
        Task.Run(() =>
        {
            var retorno = send.SendMail(email);
            this.codigo = retorno;
        });
    }
}
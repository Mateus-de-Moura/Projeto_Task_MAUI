
using CommunityToolkit.Mvvm.Messaging;
using System.Globalization;
using TAsk.Models;
using TAsk.Repositories;

namespace TAsk.Viwes;

public partial class RedefinicaoDeSenha : ContentPage
{
    private UserRepository _repository;
    private string Email;
    public RedefinicaoDeSenha(string email)
    {
        this.Email = email;
        this._repository = new UserRepository();
        InitializeComponent();
    }
    public void setEmail(string email)
    {
        this.Email = email;
    }
    private void btnRedef_Clicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtSenha.Text) && !string.IsNullOrEmpty(txtSenhaConfirm.Text))
        {
            try
            {
                if (txtSenha.Text == txtSenhaConfirm.Text)
                {
                    var userDb = _repository.get(Email);
                    userDb.senha = txtSenha.Text;

                    _repository.UpdateUser(userDb);

                    DisplayAlert("Sucess", "Senha Atualizada", "OK");
                    Navigation.PopModalAsync();
                    WeakReferenceMessenger.Default.Send<string>("");
                }
                else
                {
                    DisplayAlert("ERROR", "As senhas não são iguais", "OK");
                }
            }
            catch (Exception)
            {                
            }
        }
        else
        {
            DisplayAlert("ERROR", "Preencha todos os campos", "OK");
            Navigation.PopModalAsync();
        }
    }
}
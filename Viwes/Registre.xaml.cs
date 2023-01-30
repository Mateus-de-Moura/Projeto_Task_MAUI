using TAsk.Models;
using TAsk.Repositories;

namespace TAsk.Viwes;

public partial class Registre : ContentPage
{
	private UserRepository _repository;
	public Registre()
	{
		this._repository = new UserRepository();

        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
    }

	private void OnTapGestureRecognizerTapped(object sender, EventArgs e)
	{
		Navigation.PopModalAsync();
	}

	private void Button_Clicked(object sender, EventArgs e)
	{
		Users user = new Users
		{
			Nome = txtNome.Text,
			email = txtEmail.Text,
			telefone = txtTelefone.Text,
			senha = txtSenha.Text,
		};

		_repository.AddUser(user);

        Navigation.PopModalAsync();
    }
}
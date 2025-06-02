

namespace Chiusino.Views;

public partial class Home : ContentPage
{
    Utente Selecteduser;
    public Home()
	{
		InitializeComponent();

        UsersListView.ItemsSource = UserManager.Users;

        // Gestore selezione
        UsersListView.ItemSelected += (sender, e) =>
        {
            if (e.SelectedItem != null)
            {
                DisplayAlert("Utente", $"Selezionato: {e.SelectedItem.ToString()}", "OK");
                Selecteduser = e.SelectedItem as Utente;
                UsersListView.SelectedItem = null;
            }
        };
    }

    private async void ProfileButton_Clicked(object sender, EventArgs e)
    {
        if (Selecteduser == null)
        {
            await DisplayAlert("Errore", "Nessun utente selezionato", "OK");
            return;
        }
        await Navigation.PushAsync(new ProfilePage(Selecteduser));
    }

    private async void CreateUserButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddProfilePage());
    }

    private async void PlayButton_Clicked(object sender, EventArgs e)
    {
        if (Selecteduser == null)
        {
            await DisplayAlert("Errore", "Nessun utente selezionato", "OK");
            return;
        }
        await Navigation.PushAsync(new PreGamePage(Selecteduser));
    }
}
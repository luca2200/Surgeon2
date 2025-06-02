using System.Collections.ObjectModel;

namespace Chiusino.Views;

public partial class AddProfilePage : ContentPage
{
    
    public AddProfilePage()
    {
        InitializeComponent();

        SaveButton.Clicked += OnSaveClicked;
        CancelButton.Clicked += OnCancelClicked;
    }
    private async void OnSaveClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(ProfileNameEntry.Text))
        {
            await DisplayAlert("Attenzione", "Il nome profilo è obbligatorio", "OK");
            await Navigation.PopAsync();
            return;
        }
        var nuovoUtente = new Utente
        {
            Nome = ProfileNameEntry.Text,
            Descrizione = DescriptionEditor.Text
        };
        UserManager.AddUser(nuovoUtente);
        await Navigation.PopAsync();
    }
    private async void OnCancelClicked(object sender, EventArgs e)
    {
        bool confirm = await DisplayAlert("Conferma", "Annullare la creazione del profilo?", "Sì", "No");
        if (confirm)
        {
            await Navigation.PopAsync();
        }
    }

}
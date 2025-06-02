namespace Chiusino.Views;

public partial class ProfilePage : ContentPage
{
    public Utente SelectedUser = new Utente();
	public ProfilePage(Utente Selecteduser)
	{
		InitializeComponent();
        if(Selecteduser == null)
        {
            DisplayAlert("Errore", "Nessun utente selezionato", "OK");
            return;
        }
        SelectedUser = Selecteduser;
        lblName.Text = SelectedUser.Nome;
        lblPoints.Text =SelectedUser.Punti.ToString();
        lblDataCreazione.Text =SelectedUser.DataCreazione.ToShortDateString();
		lblDescrizione.Text=SelectedUser.Descrizione;
    }

    private void ViewRolesButton_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Ruoli Utente", string.Join(", ", SelectedUser.Ruoli), "OK");
    }
}
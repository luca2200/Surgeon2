namespace Chiusino.Views;

public partial class GamePage : ContentPage
{
	Utente CurrentUser=new Utente();
	int puntigioco = 0;
    public GamePage(Utente user)
	{
		InitializeComponent();
		CurrentUser = user;
    }
    private void GenerateNextWord(object sender, EventArgs e)
	{
		RandomWordLabel.Text = WordGenerator.GeneraParola();
		CurrentUser.Punti++;
		puntigioco++;
		ScoreLabel.Text = puntigioco.ToString();
        Task.Delay(2000);
		return;
    }
    private async void EndGame(object sender, EventArgs e)
	{
        //Salva risultati
        UserManager.UpdateUser(CurrentUser);
        await Navigation.PopAsync();
    }
}

using Microsoft.Maui.ApplicationModel.DataTransfer;
namespace Chiusino.Views;

public partial class PreGamePage : ContentPage
{
    Utente SelectedUser=new Utente();
    public PreGamePage(Utente Selecteduser)
	{
		InitializeComponent();
        SelectedUser = Selecteduser;
        JobLabel.Text = SelectedUser.Ruoli[new Random().Next(SelectedUser.Ruoli.Count)];
    }
    private void GeneratePhoneNumber(object sender, EventArgs e)
	{
        Random rnd = new Random();
        // Fissiamo il prefisso internazionale
        string countryCode = "#31#";
        // Lista di prefissi mobili comuni (con duplicati per ponderare quelli più frequenti)
        string[] prefixes = { "340", "375", "345", "377", "351", "349", "379", "379", "351", "370", "371", "320", "327" };
        string prefix = prefixes[rnd.Next(prefixes.Length)];
        // --- Generazione della seconda tripletta (BBB) ---
        // Impostiamo una probabilità per applicare un pattern in questa tripletta (ad es. 40%)
        double middlePatternProbability = 0.4;
        bool middleHasPattern = rnd.NextDouble() < middlePatternProbability;
        int b1, b2, b3;

        if (middleHasPattern)
        {
            // Genera b1 in [1,9]
            b1 = rnd.Next(1, 10);
            // Scegli casualmente uno dei pattern per la tripletta:
            // Pattern 1: b2 uguale a b1, b3 casuale (con b3 poco propenso a 0)
            // Pattern 2: b3 uguale a b1, b2 casuale (con b2 poco propenso a 0)
            // Pattern 3: b2 e b3 uguali (entrambi uguali a un numero in [1,9])
            int patternChoice = rnd.Next(3);
            switch (patternChoice)
            {
                case 0:
                    b2 = b1;
                    b3 = (rnd.NextDouble() < 0.1) ? 0 : rnd.Next(1, 10);
                    break;
                case 1:
                    b2 = (rnd.NextDouble() < 0.1) ? 0 : rnd.Next(1, 10);
                    b3 = b1;
                    break;
                case 2:
                    b2 = rnd.Next(1, 10);
                    b3 = b2;
                    break;
                default:
                    b2 = (rnd.NextDouble() < 0.1) ? 0 : rnd.Next(1, 10);
                    b3 = (rnd.NextDouble() < 0.1) ? 0 : rnd.Next(1, 10);
                    break;
            }
        }
        else
        {
            // Generazione "normale" per la tripletta
            b1 = rnd.Next(1, 10); // nessuno 0 per il primo
            b2 = (rnd.NextDouble() < 0.1) ? 0 : rnd.Next(1, 10);
            b3 = (rnd.NextDouble() < 0.1) ? 0 : rnd.Next(1, 10);
        }
        string middleTriple = $"{b1}{b2}{b3}";

        // --- Generazione dell'ultima quadripletta (CCCC) ---
        int[] lastDigits = new int[4];
        for (int i = 0; i < 4; i++)
        {
            lastDigits[i] = rnd.Next(0, 10);
        }

        // Imposta la probabilità di applicare un pattern nella quadripletta:
        // Se nella tripletta è stato applicato un pattern, abbassa la probabilità (es. 20%),
        // altrimenti usa una probabilità più alta (es. 50%).
        double lastPatternProbability = middleHasPattern ? 0.1 : 0.6;
        if (rnd.NextDouble() < lastPatternProbability)
        {
            int pattern = rnd.Next(4); // scegli tra 4 possibili pattern
            switch (pattern)
            {
                case 0:
                    // Pattern A: imposta il secondo numero uguale al primo
                    lastDigits[1] = lastDigits[0];
                    break;
                case 1:
                    // Pattern B: imposta il quarto numero uguale al terzo
                    lastDigits[3] = lastDigits[2];
                    break;
                case 2:
                    // Pattern C: imposta il terzo numero uguale al primo
                    lastDigits[2] = lastDigits[0];
                    break;
                case 3:
                    // Pattern D: imposta il quarto numero uguale al secondo
                    lastDigits[3] = lastDigits[1];
                    break;
            }
        }
        string lastQuadruple = string.Join("", lastDigits);

        // Combiniamo tutte le parti
        string phoneNumber = $"{countryCode} {prefix} {middleTriple} {lastQuadruple}";
        // Mostriamo il numero generato
        PhoneNumberLabel.Text = phoneNumber;
    }
    private async void StartWordGame(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new GamePage(SelectedUser));
    }

    private async void CopyPhoneNumberBtn_Clicked(object sender, EventArgs e)
    {
        try
        {
            await Clipboard.Default.SetTextAsync(PhoneNumberLabel.Text);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Errore", $"Impossibile copiare il numero: {ex.Message}", "OK");
        }
    }
}
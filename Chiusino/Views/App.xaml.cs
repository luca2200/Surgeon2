using Chiusino.Views;
namespace Chiusino
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Home());
        }
    }
}


namespace TutorMe
{
    public partial class PageAccueil : ContentPage
    {

        public PageAccueil()
        {
            InitializeComponent();
        }
        private void BoutonChangerTuteur(object sender, EventArgs e)
        {
            var database = new Database();
            Navigation.PushAsync(new AvoirTuteur(database));
        }


        private void BoutonDevenirTuteur(object sender, EventArgs e)
        {
            var database = new Database();
            Navigation.PushAsync(new DevenirTuteur(database));
        }


        private void BoutonCandid(object sender, EventArgs e)
        {
            var database = new Database();
            Navigation.PushAsync(new EvalSeance(database));
        }

        private void BoutonChercherTuteur(object sender, EventArgs e)
        {
            var database = new Database();
            Navigation.PushAsync(new RapportSession(database));
        }

        private void BoutonRessource(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Ressource());
        }

    }
}
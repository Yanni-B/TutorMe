
namespace ProjetDevEntreprise
{
    public partial class PageAccueil : ContentPage
    {

        public PageAccueil()
        {
            InitializeComponent();
        }
        private void BoutonChangerTuteur(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DevenirTuteur());
        }

    }
}

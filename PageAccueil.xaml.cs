
using TutorMe.Models;

namespace TutorMe
{
    public partial class PageAccueil : ContentPage

    {

        

        public PageAccueil(Utilisateur user)
        {
            InitializeComponent();

            

            lblWelcomeMessage.Text = $"Bonjour {user.Username}";

            // Method to check if the user is a tutor

            // Toggle visibility of buttons based on whether the user is a tutor or not
            if (user.isTutor)
            {
                // Show the button for tutor evaluation and hide the button for session evaluation
                etud.IsVisible = false;
                tut.IsVisible = true;
            }
            else
            {
                // Show the button for session evaluation and hide the button for tutor evaluation
                etud.IsVisible = true;
                tut.IsVisible = false;
            }

          

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

        private async void SignOut_Clicked(object sender, EventArgs e)
        {
            // Déconnecter l'utilisateur (par exemple, effacer les informations de connexion)
            // Vous pouvez implémenter votre propre logique pour déconnecter l'utilisateur

            // Naviguer vers la page de connexion
            await Navigation.PushAsync(new LoginPage());

            // Supprimer toutes les pages de la pile de navigation, sauf la page de connexion
            foreach (Page page in Navigation.NavigationStack.ToList())
            {
                if (page.GetType() != typeof(LoginPage))
                {
                    Navigation.RemovePage(page);
                }
            }
        }
    }
}

using TutorMe.Models;

namespace TutorMe
{
    public partial class RapportSession : ContentPage
    {

        private readonly Database database;
        private int editRapportId;
        public RapportSession(Database dbService)
        {
            InitializeComponent();
            database = dbService;
        }

        private async void save_Rapport(object sender, EventArgs e)
        {
            if (editRapportId == 0)
            {
                await database.Create(new Rapport
                {
                    NomTuteur = nomTuteur.Text,
                    NomEleve = nomEleve.Text,
                    NoteAvant = NoteAvantSession.Text,
                    NoteApres = NoteApresSession.Text,
                    Session = Session.Text,
                    Cours = Cours.Text,
                    Commentaire = commentaireTuteur.Text
                });
                await DisplayAlert("Succès", "Évaluation bien envoyée.", "OK");

                await Navigation.PopAsync();
            }


        }



    }



}



/*
   SOURCE :
   https://learn.microsoft.com/fr-fr/training/modules/store-local-data/4-exercise-store-data-locally-with-sqlite
   https://youtu.be/VziMUc-VQko?si=FeJ1QJWf-yCqF44P
*/
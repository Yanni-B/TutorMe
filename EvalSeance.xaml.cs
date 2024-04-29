
using TutorMe.Models;

namespace TutorMe
{
    public partial class EvalSeance : ContentPage
    {

        private readonly Database database;
        private int editEvalTuteurtId;
        public EvalSeance(Database dbService)
        {
            InitializeComponent();
            database = dbService;
        }

        private async void saveButton_Clicked(object sender, EventArgs e)
        {
            if (editEvalTuteurtId == 0)
            {
                await database.Create(new Eval
                {
                    NomTuteur = nomTuteur.Text,
                    NomEleve = nomEleve.Text,
                    Date = date.Text,
                    Cours = cours.Text,
                    Session = session.Text,
                    Note = noteSeance.Text,
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
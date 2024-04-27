
using TutorMe.Models;

namespace TutorMe
{
    public partial class DevenirTuteur : ContentPage
    {

        private readonly Database database;
        private int editTuteurId;
        public DevenirTuteur(Database dbService)
        {
            InitializeComponent();
            database = dbService;
        }

        private async void saveButton_Clicked(object sender, EventArgs e)
        {
            if (editTuteurId == 0)
            {
                await database.Create(new Tuteur
                {
                    Name = newPerson.Text,
                    Note = Note.Text,
                    Horaire1 = Horaire1.Text,
                    Horaire2 = Horaire2.Text,
                    Horaire3 = Horaire3.Text
                });

                await DisplayAlert("Succès", "Votre candidature a bien été envoyé", "OK");

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
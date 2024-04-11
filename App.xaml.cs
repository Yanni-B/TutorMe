using TutorMe;

namespace TutorMe
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }
    }
}


/*
   SOURCE :
   https://learn.microsoft.com/fr-fr/training/modules/store-local-data/4-exercise-store-data-locally-with-sqlite
   https://youtu.be/VziMUc-VQko?si=FeJ1QJWf-yCqF44P
*/
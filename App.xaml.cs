using TutorMe;

namespace TutorMe
{
    public partial class App : Application
    {
       
        public App()
        {
            InitializeComponent();



            
            
            MainPage = new NavigationPage(new LoginPage());

        }

        protected override async void OnStart()
        {
            base.OnStart();

            // Asynchronously initialize the database and add the user
            await InitializeDatabaseAsync();
        }

        private async Task InitializeDatabaseAsync()
        {
           

        }
    }
}


/*
   SOURCE :
   https://learn.microsoft.com/fr-fr/training/modules/store-local-data/4-exercise-store-data-locally-with-sqlite
   https://youtu.be/VziMUc-VQko?si=FeJ1QJWf-yCqF44P
*/
using TutorMe.Models;

namespace TutorMe
{
    public partial class AfficherRencontres : ContentPage
    {
        private readonly Database database;

        public AfficherRencontres(Database dbService)
        {
            InitializeComponent();
            database = dbService;

        }

       
    }
}
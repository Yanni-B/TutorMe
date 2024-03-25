namespace ProjetDevEntreprise
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }
        private void BoutonChangerDePage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageAccueil());
        }
    }

}



using TutorMe.Models;

namespace TutorMe;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void OnLoginButtonClicked(object sender, EventArgs e)

    {

        Database database = new Database();



        // Perform authentication process (replace this with your actual authentication logic)
        bool isAuthenticated = await database.AuthenticateUser(username.Text, password.Text);
        if (isAuthenticated)
        {

            

            Utilisateur user = await database.GetUserByUsername(username.Text);
            // Navigate to the PageAccueil page
            await Navigation.PushAsync(new PageAccueil(user));
            Navigation.RemovePage(this);
        }
        else
        {
            // Display error message or handle unsuccessful login
            await DisplayAlert("Login Failed", "Invalid username or password", "OK");
        }
    }

    private async void OnRegisterNowTapped(object sender, EventArgs e)
    {
        // Navigate to the sign-up page
        await Navigation.PushAsync(new SignUpPage());
    }


}
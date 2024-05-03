using TutorMe.Models;

namespace TutorMe;

public partial class SignUpPage : ContentPage
{
    public SignUpPage()
    {
        InitializeComponent();
    }

    private async void OnSignUpButtonClicked(object sender, EventArgs e)
    {
        // Retrieve username and password from the Entry fields
        string username = user.Text;
        string password = pass.Text;

        // Retrieve tutor status from the selected radio button
        bool isTutor = YesRadioButton.IsChecked;

        // Validate if username, password, and tutor status are not empty
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || !YesRadioButton.IsChecked && !NoRadioButton.IsChecked)
        {
            await DisplayAlert("Error", "Please fill out all fields.", "OK");
            return; // Exit the method if validation fails
        }

        // Create a new User object with the entered data
        var newUser = new Utilisateur
        {
            Username = username,
            Password = password,
            isTutor = isTutor,
            
        };

        // Here you can perform any necessary actions with the newUser object,
        // such as saving it to a database or performing validation.
        Database database = new Database();
        database.AddUser(username,password,isTutor);

        // For demonstration purposes, let's assume we just display a message.
        await DisplayAlert("Sign Up", "User signed up successfully!", "OK");

        // You might want to navigate back to the login page after signing up
        // This line assumes that you've implemented navigation properly.
        await Navigation.PopAsync();
    }
}
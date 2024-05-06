
using System.Windows.Input;

namespace TutorMe
{
    public partial class Ressource : ContentPage
    {
        public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));
        public Ressource()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
}
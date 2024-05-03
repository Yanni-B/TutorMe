using System.Text;
using TutorMe.Models;

namespace TutorMe;

public partial class AdminPage : ContentPage
{
    private readonly Database database;
	public AdminPage()
	{
		InitializeComponent();
        database = new Database();
	}

    private async void SignOut_Clicked(object sender, EventArgs e)
    {
        // Déconnecter l'utilisateur (par exemple, effacer les informations de connexion)
        // Vous pouvez implémenter votre propre logique pour déconnecter l'utilisateur

        // Naviguer vers la page de connexion
        await Navigation.PushAsync(new LoginPage());

        // Supprimer toutes les pages de la pile de navigation, sauf la page de connexion
        foreach (Page page in Navigation.NavigationStack.ToList())
        {
            if (page.GetType() != typeof(LoginPage))
            {
                Navigation.RemovePage(page);
            }
        }
    }


    private async void LoadHorairesButton_Clicked(object sender, EventArgs e)
    {
        // Récupérer les horaires des étudiants depuis la base de données
        List<Person> etudiants = await database.GetAllEtudiants();

        // Récupérer les horaires des tuteurs depuis la base de données
        List<Tuteur> tuteurs = await database.GetAllTuteurs();

        // Afficher les horaires sous le label
        DisplayHoraires("Horaires des étudiants et disponibilités des tuteurs :", etudiants, tuteurs);
    }


    private void DisplayHoraires(string titre, List<Person> etudiants, List<Tuteur> tuteurs)
    {
        // Construire une chaîne pour afficher les horaires
        StringBuilder horairesBuilder = new StringBuilder();
        horairesBuilder.AppendLine(titre);

        if (etudiants != null && etudiants.Any())
        {
            // Afficher les horaires des étudiants
            horairesBuilder.AppendLine("Horaires des étudiants :");
            foreach (var etudiant in etudiants)
            {
                horairesBuilder.AppendLine($"Nom : {etudiant.Name}.");
                horairesBuilder.AppendLine($" Disponibilité1 : {etudiant.choix1jour} {etudiant.choix1heureDebut}h-{etudiant.choix1heureFin}h.");
                horairesBuilder.AppendLine($" Disponibilité2 : {etudiant.choix2jour} {etudiant.choix2heureDebut}h-{etudiant.choix2heureFin}h.");
                horairesBuilder.AppendLine($" Disponibilité3 : {etudiant.choix3jour} {etudiant.choix3heureDebut}h-{etudiant.choix3heureFin}h.");

            }
        }
        else
        {
            horairesBuilder.AppendLine("Aucun étudiant trouvé.");
        }

        if (tuteurs != null && tuteurs.Any())
        {
            // Afficher les disponibilités des tuteurs
            horairesBuilder.AppendLine("Disponibilités des tuteurs :");
            foreach (var tuteur in tuteurs)
            {
                horairesBuilder.AppendLine($"Nom : {tuteur.Name}.");
                horairesBuilder.AppendLine($" Disponibilité1 : {tuteur.choix1jour} {tuteur.choix1heureDebut}h-{tuteur.choix1heureFin}h.");
                horairesBuilder.AppendLine($" Disponibilité2 :  {tuteur.choix2jour} {tuteur.choix2heureDebut}h-{tuteur.choix2heureFin}h.");
                horairesBuilder.AppendLine($" Disponibilité3 :  {tuteur.choix3jour} {tuteur.choix3heureDebut}h-{tuteur.choix3heureFin}h.");
            }
        }
        else
        {
            horairesBuilder.AppendLine("Aucun tuteur trouvé.");
        }

        // Mettre à jour le texte du label avec les horaires
        infoLabel.Text += Environment.NewLine + horairesBuilder.ToString();
    }





    private async void MatchButton_Clicked(object sender, EventArgs e)
    {
        // Récupérer les étudiants et les tuteurs depuis la base de données
        List<Person> etudiants = await database.GetAllEtudiants();
        List<Tuteur> tuteurs = await database.GetAllTuteurs();

        // Parcourir tous les étudiants et les tuteurs pour trouver des correspondances
        foreach (var etudiant in etudiants)
        {
            foreach (var tuteur in tuteurs)
            {
                // Vérifier si les choix de disponibilité de l'étudiant correspondent à ceux du tuteur
                if (ChoixDisponibiliteCorrespond(etudiant, tuteur))
                {
                    // Afficher le match
                    infoLabel.Text = $"Match trouvé: Étudiant - {etudiant.Name}, Tuteur - {tuteur.Name}";
                    return;
                }
            }
        }
            
        infoLabel.Text = "Aucun match trouvé";
    }

    private bool ChoixDisponibiliteCorrespond(Person etudiant, Tuteur tuteur)
    {
        // Comparer les neuf combinaisons possibles de choix de disponibilité
        return ComparerChoixDisponibilite(etudiant.choix1jour, etudiant.choix1heureDebut, etudiant.choix1heureFin,
                                          tuteur.choix1jour, tuteur.choix1heureDebut, tuteur.choix1heureFin) ||
               ComparerChoixDisponibilite(etudiant.choix1jour, etudiant.choix1heureDebut, etudiant.choix1heureFin,
                                          tuteur.choix2jour, tuteur.choix2heureDebut, tuteur.choix2heureFin) ||
               ComparerChoixDisponibilite(etudiant.choix1jour, etudiant.choix1heureDebut, etudiant.choix1heureFin,
                                          tuteur.choix3jour, tuteur.choix3heureDebut, tuteur.choix3heureFin) ||
               ComparerChoixDisponibilite(etudiant.choix2jour, etudiant.choix2heureDebut, etudiant.choix2heureFin,
                                          tuteur.choix1jour, tuteur.choix1heureDebut, tuteur.choix1heureFin) ||
               ComparerChoixDisponibilite(etudiant.choix2jour, etudiant.choix2heureDebut, etudiant.choix2heureFin,
                                          tuteur.choix2jour, tuteur.choix2heureDebut, tuteur.choix2heureFin) ||
               ComparerChoixDisponibilite(etudiant.choix2jour, etudiant.choix2heureDebut, etudiant.choix2heureFin,
                                          tuteur.choix3jour, tuteur.choix3heureDebut, tuteur.choix3heureFin) ||
               ComparerChoixDisponibilite(etudiant.choix3jour, etudiant.choix3heureDebut, etudiant.choix3heureFin,
                                          tuteur.choix1jour, tuteur.choix1heureDebut, tuteur.choix1heureFin) ||
               ComparerChoixDisponibilite(etudiant.choix3jour, etudiant.choix3heureDebut, etudiant.choix3heureFin,
                                          tuteur.choix2jour, tuteur.choix2heureDebut, tuteur.choix2heureFin) ||
               ComparerChoixDisponibilite(etudiant.choix3jour, etudiant.choix3heureDebut, etudiant.choix3heureFin,
                                          tuteur.choix3jour, tuteur.choix3heureDebut, tuteur.choix3heureFin);
    }

    private bool ComparerChoixDisponibilite(string jourEtudiant, int heureDebutEtudiant, int heureFinEtudiant,
                                             string jourTuteur, int heureDebutTuteur, int heureFinTuteur)
    {
        // Comparer le jour, l'heure de début et l'heure de fin
        return jourEtudiant == jourTuteur &&
               heureDebutEtudiant == heureDebutTuteur &&
               heureFinEtudiant == heureFinTuteur;
    }




}
using TutorMe.Models;

namespace TutorMe
{
    public partial class AfficherRencontres : ContentPage
    {
        private readonly Database database;
        Utilisateur user2;

        public AfficherRencontres(Utilisateur user, Database database)
        {
            InitializeComponent();
            callShow(user);
             
        }

        public void callShow(Utilisateur user)
        {
            showRencontres(user);
        }
        async void showRencontres(Utilisateur user)
            {
            // Récupérer les étudiants et les tuteurs depuis la base de données
            MatchingInfo match = await database.GetByIdMatch(user.Id);
                try
                {
                    showMatchings.Text = "Date = " + match.jour + " HeureDebut = " + match.heureDebut;
                }
                catch (Exception ex) { showMatchings.Text = "Aucune rencontres trouvées" + ex; }
                finally
                {
                    await Navigation.PushAsync(new PageAccueil(user));
                    Navigation.RemovePage(this);
                }
            }







        // Parcourir tous les étudiants et les tuteurs pour trouver des correspondances
        //private async void MatchButton_Clicked(object sender, EventArgs e)
        //{
        //    // Récupérer les étudiants et les tuteurs depuis la base de données
        //    List<Person> etudiants = await database.GetAllEtudiants();
        //    List<Tuteur> tuteurs = await database.GetAllTuteurs();

        //    // Parcourir tous les étudiants et les tuteurs pour trouver des correspondances
        //    foreach (var etudiant in etudiants)
        //    {
        //        foreach (var tuteur in tuteurs)
        //        {
        //            int heureDebutMatch;
        //            int heureFinMatch;
        //            string jourMatch;

        //                // Afficher le match
        //                infoLabel.Text = $"Match trouvé: Étudiant - {etudiant.Name}, Tuteur - {tuteur.Name}";

        //                // Ajouter le match à la liste des correspondances
        //                MatchingInfo.MatchingList.Add(new MatchingInfo
        //                {
        //                    TutorName = tuteur.Name,
        //                    StudentName = etudiant.Name,
        //                    jour = jourMatch,
        //                    heureDebut = heureDebutMatch,
        //                    heureFin = heureFinMatch,

        //                });

        //                // Afficher les correspondances pour toutes les semaines
        //                StringBuilder matchingsBuilder = new StringBuilder();

        //                // Afficher les semaines
        //                matchingsBuilder.AppendLine($"Voici les rendez-vous planifié pour cette session entre le tuteur {tuteur.Name} et l'étudiant {etudiant.Name}:");
        //                matchingsBuilder.AppendLine();

        //                for (int semaine = 1; semaine <= 10; semaine++)
        //                {
        //                    matchingsBuilder.AppendLine($"Semaine {semaine}:");
        //                    foreach (var matching in MatchingInfo.MatchingList)
        //                    {
        //                        matchingsBuilder.AppendLine($"Date : {matching.jour} de {matching.heureDebut}h à {matching.heureFin}h \nTuteur: {matching.TutorName} \nÉtudiant: {matching.StudentName} \nCours de français #{matching.Cours}");
        //                    }
        //                    matchingsBuilder.AppendLine(); // Ajoute une ligne vide entre chaque semaine
        //                }

        //                // Mettre à jour le texte du label avec les matchings pour toutes les semaines
        //                infoLabel.Text = matchingsBuilder.ToString();
        //                return;
        //            }
        //        }
        //    }

        //    infoLabel.Text = "Aucun match trouvé";
        //}
    }
}


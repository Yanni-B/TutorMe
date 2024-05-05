
using SQLite;


namespace TutorMe.Models;

[Table("people")]
public class Person : Utilisateur
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [MaxLength(250)]
    public string Name { get; set; } = "";

    [MaxLength(250)]
    public string Prenom { get; set; } = "";


    [MaxLength(250)]
    public string DA { get; set; } = "";

    [MaxLength(250)]
    public string choix1jour { get; set; }

    [MaxLength(250)]
    public int choix1heureDebut { get; set; }

    [MaxLength(250)]
    public int choix1heureFin { get; set; }

    [MaxLength(250)]
    public string choix2jour { get; set; }

    [MaxLength(250)]
    public int choix2heureDebut { get; set; }

    [MaxLength(250)]
    public int choix2heureFin { get; set; }

    [MaxLength(250)]
    public string choix3jour { get; set; }

    [MaxLength(250)]
    public int choix3heureDebut { get; set; }

    [MaxLength(250)]
    public int choix3heureFin { get; set; }

    [MaxLength(250)]
    public int choixCours { get; set; }


}
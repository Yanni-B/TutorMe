using SQLite;

namespace TutorMe.Models;

[Table("tuteur")]
public class Tuteur
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [MaxLength(250), Unique]
    public string Name { get; set; } = "";

    [MaxLength(250), Unique]
    public string Note { get; set; } = "";
    [MaxLength(250), Unique]
    public string choix1jour { get; set; }

    [MaxLength(250), Unique]
    public int choix1heureDebut { get; set; }

    [MaxLength(250), Unique]
    public int choix1heureFin { get; set; }

    [MaxLength(250), Unique]
    public string choix2jour { get; set; }

    [MaxLength(250), Unique]
    public int choix2heureDebut { get; set; }

    [MaxLength(250), Unique]
    public int choix2heureFin { get; set; }

    [MaxLength(250), Unique]
    public string choix3jour { get; set; }

    [MaxLength(250), Unique]
    public int choix3heureDebut { get; set; }

    [MaxLength(250), Unique]
    public int choix3heureFin { get; set; }

    //[MaxLength(250), Unique]
    //public string Horaire1 { get; set; } = "";

    //[MaxLength(250), Unique]
    //public string Horaire2 { get; set; } = "";

    //[MaxLength(250), Unique]
    //public string Horaire3 { get; set; } = "";

}
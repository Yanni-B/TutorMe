using SQLite;


namespace TutorMe.Models;

[Table("rapport")]
public class Rapport
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [MaxLength(250), Unique]
    public string NomTuteur { get; set; } = "";

    [MaxLength(250), Unique]
    public string NomEleve { get; set; } = "";


    [MaxLength(250), Unique]
    public string NoteAvant { get; set; } = "";

    [MaxLength(250), Unique]
    public string NoteApres { get; set; } = "";

    [MaxLength(250), Unique]
    public string Session { get; set; } = "";

    [MaxLength(250), Unique]
    public string Cours { get; set; } = "";

    [MaxLength(250), Unique]
    public string Commentaire { get; set; } = "";

}
using SQLite;

namespace TutorMe.Models;

[Table("Eval")]
public class Eval
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [MaxLength(250), Unique]
    public string NomTuteur { get; set; } = "";

    [MaxLength(250), Unique]
    public string NomEleve { get; set; } = "";


    [MaxLength(250), Unique]
    public string Date { get; set; } = "";

    [MaxLength(250), Unique]
    public string Cours { get; set; } = "";

    [MaxLength(250), Unique]
    public string Session { get; set; } = "";


    [MaxLength(250), Unique]
    public string Note { get; set; } = "";


    [MaxLength(250), Unique]
    public string Commentaire { get; set; } = "";

}
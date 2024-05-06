using SQLite;


namespace TutorMe.Models;

[Table("rencontres")]

public class Rencontres
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public int idTutored {  get; set; }
    public int idTuteur { get; set; }
    [MaxLength(8)]
    public string dateRencontre { get; set; } = "";
    [MaxLength(2)]
    public int heureDebutRencontre { get; set; }
    [MaxLength(2)]
    public int heureFinRencontre { get; set; }

    



}

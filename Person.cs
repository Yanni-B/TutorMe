using SQLite;

namespace TutorMe.Models;

[Table("people")]
public class Person
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [MaxLength(250), Unique]
    public string Name { get; set; } = "";

    [MaxLength(250), Unique]
    public string Prenom { get; set; } = "";


    [MaxLength(250), Unique]
    public string DA { get; set; } = "";

    [MaxLength(250), Unique]
    public string Horaire1 { get; set; } = "";

    [MaxLength(250), Unique]
    public string Horaire2 { get; set; } = "";

    [MaxLength(250), Unique]
    public string Horaire3 { get; set; } = "";

}
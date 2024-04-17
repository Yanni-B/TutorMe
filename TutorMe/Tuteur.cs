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
    public int heureDebut { get; set; }


    //[MaxLength(250), Unique]
    //public string Horaire1 { get; set; } = "";

    //[MaxLength(250), Unique]
    //public string Horaire2 { get; set; } = "";

    //[MaxLength(250), Unique]
    //public string Horaire3 { get; set; } = "";

}
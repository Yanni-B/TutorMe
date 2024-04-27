using SQLite;


namespace TutorMe.Models;

[Table("User")]
public class Utilisateur
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [MaxLength(250), Unique]
    public string Username { get; set; } 

    public string Password { get; set; }

    public bool isTutor { get; set; }


    public static List<Utilisateur> Users { get; set; } = new List<Utilisateur>();

    
}

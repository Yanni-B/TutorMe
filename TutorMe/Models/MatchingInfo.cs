
using SQLite;

namespace TutorMe.Models
{
    [Table("Matching")]
    public class MatchingInfo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string TutorName { get; set; }
        public string StudentName { get; set; }
        public int heureDebut { get; set; }
        public int heureFin { get; set; }
        public string jour { get; set; }
        public int Cours { get; set; }

        public static List<MatchingInfo> MatchingList { get; set; } = new List<MatchingInfo>();
    }

}


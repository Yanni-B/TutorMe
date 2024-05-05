
using SQLite;

namespace TutorMe.Models
{
    [Table("Matching")]
    public class MatchingInfo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int IdTutor { get; set; }
        public int IdTutored { get; set; }
        public int heureDebut { get; set; }
        public int heureFin { get; set; }
        public string jour { get; set; }
        public int cours { get; set; }

        public static List<MatchingInfo> MatchingList { get; set; } = new List<MatchingInfo>();
    }

}


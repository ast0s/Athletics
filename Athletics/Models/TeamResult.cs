using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Athletics.Models
{
    [PrimaryKey("TeamId", "CompetitionId")]
    public class TeamResult
    {
        public float Score { get; set; }
        [Key]
        public int TeamId { get; set; }
        public virtual Team? Team { get; set;}
        [Key]
        public int CompetitionId { get; set; }
        public virtual Competition? Competition { get; set; }
    }
}

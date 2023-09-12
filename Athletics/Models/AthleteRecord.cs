using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Athletics.Models
{
    [PrimaryKey("AthleteId", "DisciplineId")]
    public class AthleteRecord
    {
        [Key]
        public int AthleteId { get; set; }
        public virtual Athlete? Athlete { get; set; }
        [Key]
        public int DisciplineId { get; set; }
        public virtual Discipline? Discipline { get; set; }
        public float Score { get; set; }
    }
}

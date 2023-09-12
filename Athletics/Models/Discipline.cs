using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Athletics.Models
{
    [Table("Discipline")]
    public class Discipline
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public virtual AthleteRecord? AthleteRecord { get; set; }
        public virtual IList<CompetitionDiscipline>? CompetitionDisciplines { get; set; }
    }
}

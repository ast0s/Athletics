using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Athletics.Models
{
    public class Contender
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AthleteId { get; set; }
        public virtual Athlete? Athlete { get; set;}
        public int TeamId { get; set; }
        public virtual Team? Team { get; set;}
        public virtual IList<ContenderDiscipline>? ContenderDisciplines { get; set; }
    }
}

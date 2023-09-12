using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Athletics.Models
{
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CoachId { get; set; }
        public virtual Coach? Coach { get; set; }
        public string? Name { get; set; }
        public virtual IList<Contender>? Contenders { get; set; }
    }
}

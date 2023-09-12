using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Athletics.Models
{
    public class Requirement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Sex { get; set; }
        public byte MinAge { get; set; }
        public byte MaxAge { get; set; }
        public string? Country { get; set; }
        public virtual IList<CompetitionDiscipline>? CompetitionDisciplines { get; set; }
        public override string ToString()
        {
            return $"{Sex} {MinAge}-{MaxAge} {Country}";
        }
    }
}

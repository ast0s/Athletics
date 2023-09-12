using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Athletics.Models
{
    public class CompetitionDiscipline
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CompetitionId { get; set; }
        public virtual Competition? Competition { get; set; }
        public int DisciplineId { get; set; }
        public virtual Discipline? Discipline { get; set; }
        public virtual IList<ContenderDiscipline>? ContenderDisciplines { get; set; }
        public virtual IList<Referee>? Referees { get; set; }
        public virtual IList<Requirement>? Requirements { get; set; }
        [NotMapped]
        public string RequirementsInfo
        {
            get
            {
                if (Requirements == null)
                {
                    return string.Empty;
                }

                return string.Join("\n", Requirements);
            }
        }
    }
}

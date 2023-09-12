using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Athletics.Models
{
    [PrimaryKey("ContenderId", "ContenderResultId")]
    public class ContenderDiscipline
    {
        [Key]
        public int ContenderId { get; set; }
        public virtual Contender? Contender { get; set; }
        [Key]
        public int CompetitionDisciplineId { get; set; }
        public virtual CompetitionDiscipline? CompetitionDiscipline { get; set; }
        public virtual ContenderResult? ContenderResult { get; set; }
        [NotMapped]
        public string RefereeInfo
        {
            get
            {
                if (CompetitionDiscipline.Referees == null)
                {
                    return string.Empty;
                }

                return string.Join("\n", CompetitionDiscipline.Referees.Select(x => x.Person.GetShortInfo()));
            }
        }
    }
}

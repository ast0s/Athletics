using Athletics.Models.Enums;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Athletics.Models
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Middlename { get; set; }
        public string? Surname { get; set; }
        public string? Sex { get; set; }
        [Column(TypeName = "Date")]
        public DateTime BirthDate { get; set; }
        [NotMapped]
        public string FormattedBirthDate
        {
            get
            {
                return BirthDate.ToString("dd.MM.yyyy");
            }
        }
        public string? Country { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public virtual Referee? Referee { get; set; }
        public virtual Coach? Coach { get; set; }
        public virtual Athlete? Athlete { get; set; }

        public string GetShortInfo()
        {
            return $"{Surname} {Name}";
        }
    }
}

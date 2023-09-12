using Athletics.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace Athletics.Models
{
    [Table("Competition")]
    public class Competition
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [NotMapped]
        public StatusType StatusType 
        {
            get
            {
                return (StatusType)Enum.Parse(typeof(StatusType), Status ?? throw new InvalidDataException("Status cannot be null"), true);
            }
            set 
            { 
                Status = ((StatusType)value).ToString();
            }
        }
        public string? Status { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public string? Country { get; set; }
        public DateTime BegginingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public string? Protocol { get; set; }
    }
}

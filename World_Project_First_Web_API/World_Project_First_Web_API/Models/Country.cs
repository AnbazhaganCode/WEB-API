using System.ComponentModel.DataAnnotations;

namespace World_Project_First_Web_API.Models
{
    public class Country
    {
        [Key]
        public int id {  get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        [MaxLength(5)]
        public string shortName { get; set; }
        [Required]
        [MaxLength(10)]
        public string code { get; set; }
    }
}

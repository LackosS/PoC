using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PoC.Microservice.Database
{
    [Table("Haromszog")]
    public class HaromszogRecord
    {
        [Key]
        public int Id { get; set; }
        public string Guid { get; set; }
        public string Pont1 { get; set; }
        public string Pont2 { get; set; }
        public string Pont3 { get; set; }
        public string Irany { get; set; }
        public string Color { get; set; }
    }
}
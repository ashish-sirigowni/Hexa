// MultiplexInfo entity
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookMyShowProjectNewAPI.Entity
{
    public class MultiplexInfo
    {
        [Key]
        public long MulID { get; set; }

        [Required]
        [MaxLength(30)]
        [Column(TypeName = "nvarchar(30)")]
        public string MulName { get; set; }

        [ForeignKey("City")]
        public long CityID { get; set; }

        public int ScreenNumber { get; set; }

        //public City City { get; set; } // Reference to the City entity
    }
}

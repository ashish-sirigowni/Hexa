using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookMyShowProjectNewAPI.Entity
{
    public class Movie
    { 
            [Key]
            public long MovID { get; set; }

            [Required]
            [MaxLength(50)]
            [Column(TypeName = "nvarchar(50)")]
            public string MovName { get; set; }

            [Required]
            [Column(TypeName = "date")]
            public DateTime ReleaseDate { get; set; }
        }

    }

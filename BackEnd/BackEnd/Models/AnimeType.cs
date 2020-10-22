using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class AnimeType
    {
        [Key]

        public int AnimeTypeID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string AnimeTypeName { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string AnimeTypeDescription { get; set; }
    }
}

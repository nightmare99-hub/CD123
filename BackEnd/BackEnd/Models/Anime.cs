using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Anime
    {
        [Key]
        public int AnimeID { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string AnimeName { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string EpsodesToTal { get; set; }

        [Required]
        public int AnimeTypeID { get; set; }

        [Required]
        public int ViewCount { get; set; }

        public int Status { get; set; }

        public int CommentID { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string AnimeImg { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string AnimeVideo { get; set; }
    }
}

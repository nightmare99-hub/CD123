using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Comment
    {
        [Key]

        public int CommentID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Content { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public DateTime CmtDate { get; set; }

        [Required]
        public int ViewerID { get; set; }
    }
}

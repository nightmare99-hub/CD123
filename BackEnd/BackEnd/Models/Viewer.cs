using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Viewer
    {
        [Key]
        public int ViewerID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string ViewerName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Password { get; set; }
    }
}

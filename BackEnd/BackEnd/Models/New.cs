using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class New
    {
        [Key]


        public int NewsID { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string NewName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string NewContent { get; set; }
    }
}

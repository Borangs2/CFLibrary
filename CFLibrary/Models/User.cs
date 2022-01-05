using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CFLibrary.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "First name required")]
        [Column(TypeName = "nvarchar(25)")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name required")]
        [Column(TypeName = "nvarchar(40)")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Password required")]
        [Column(TypeName = "nvarchar(40)")]
        public string Password { get; set; }
        [Column(TypeName = "bit")]
        
        public bool IsAdmin { get; set; }

    }
}

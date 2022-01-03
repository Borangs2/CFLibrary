using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CFLibrary.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        [Column(TypeName = "nvarchar(25)")]
        [Required(ErrorMessage = "Name is missing")]
        [DisplayName("First name")]
        public string FirstName { get; set; }
        [Column(TypeName = "nvarchar(40)")]
        [Required(ErrorMessage = "Name is missing")]
        [DisplayName("Last name")]
        public string LastName { get; set; }




    }
}

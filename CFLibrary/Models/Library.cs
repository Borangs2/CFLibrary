using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CFLibrary.Models
{
    public class Library
    {
        [Key]
        public int LibraryId { get; set; }
        [Required(ErrorMessage = "Name is missing")]
        public string Name { get; set; }
        [Required(ErrorMessage = "City is missing")]
        public string City { get; set; }

    }
}

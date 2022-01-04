using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CFLibrary.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required(ErrorMessage = "Insert a title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Insert an author")]
        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        [Required(ErrorMessage = "Insert a category")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public string ImgUrl { get; set; }

        //Null if not on sale
        [Column(TypeName = "int")]
        public int? Price { get; set; }
        //Null if not specified
        [Column(TypeName = "nvarchar(50)")]
        public string Edition { get; set; }
    }
}

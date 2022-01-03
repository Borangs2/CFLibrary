using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CFLibrary.Models
{
    public class LibraryBooks
    {
        [ForeignKey("Library")]
        public int LibraryId { get; set; }
        public virtual Library Library { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}

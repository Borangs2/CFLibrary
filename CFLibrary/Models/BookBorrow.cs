using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CFLibrary.Models
{
    public class BookBorrow
    {
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }
        public virtual Book Book { get; set; }

        public DateTime ReturnDate { get; set; }

        public BookBorrow(int userId, int bookId)
        {
            UserId = userId;
            BookId = bookId;
            DateTime Date = DateTime.Now;
            
            ReturnDate = new DateTime(Date.Year, Date.Month + 1, Date.Day);
        }

    }
}
